using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BirdMovement : MonoBehaviour
{
    public static Rigidbody birdRb;

    [SerializeField]
    private Rigidbody cameraRb;

    public static bool isAlive = false;
    bool hasStarted = false;
    float notJumpingTimer = 0f;
    public static int score; // Makes an public variable for the score

    private void Start()
    {
        hasStarted = false;
        isAlive = false;
        score = 0;
        birdRb = gameObject.GetComponent<Rigidbody>();
        //Freezes the movement of the Player 
        birdRb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void Update()
    {

        #region Startup
        // Jump To Start The Game
        if (hasStarted == false && Input.GetKeyDown(KeyCode.Space))
        {
            //Unfreezes everything then freezes the position and rotation of Z, it's a 2d game, is useless
            birdRb.constraints = RigidbodyConstraints.None;
            birdRb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;

            //Jumps
            BirdJump(birdRb);

            hasStarted = true;
            isAlive = true;

        }
        #endregion

        
        #region Gravity

        birdRb.velocity += new Vector3(0, -0.23f, 0);

        #endregion

        #region Normal Jump
        if (isAlive == true && Input.GetKeyDown(KeyCode.Space))
        {
            BirdJump(birdRb);
        }
        #endregion

        #region Rotation

        //increases the rotation timer
        notJumpingTimer += Time.deltaTime;

        //Dropps the bird if a jump has not been performed during the last 0.8 seconds

        if (gameObject.transform.eulerAngles.z > 0 && gameObject.transform.eulerAngles.z < 100 && notJumpingTimer > 0.8f)
        {
            gameObject.transform.eulerAngles -= new Vector3(0, 0, 3.5f);
        }
        else if (gameObject.transform.eulerAngles.z > 300 && notJumpingTimer > 0.8f)
        {
            gameObject.transform.eulerAngles -= new Vector3(0, 0, 3f);

        }

        #endregion

    }


    private void OnTriggerEnter(Collider collision)
    {
        //Points
        if (collision.gameObject.CompareTag("PointArea"))
        {
            score++; // Increases the score with every trigger
            
        }

        // Death
        if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Wall"))
        {
            BirdyDies();
        }

    }

    //Makes the Jump And Rotation
    private void BirdJump(Rigidbody rb)
    {
        int jumpForce = 7;

        rb.velocity = new Vector3(0, jumpForce, 0);

        //Rotation
        gameObject.transform.eulerAngles = new Vector3(0, 0, 33);
        notJumpingTimer = 0f;
    }

    public static void BirdyDies()
    {
        isAlive = false;
        birdRb.velocity = new Vector3(0, -10, 0); // Dropps the bird after death
        Time.timeScale = 0;

        if (score >= PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", score);
        }

        Instantiate(Resources.Load("DeathScorePanel"), GameObject.Find("Canvas").transform);
    }
}