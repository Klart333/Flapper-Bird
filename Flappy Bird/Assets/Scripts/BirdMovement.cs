using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BirdMovement : MonoBehaviour
{
    private Rigidbody birdRb;

    [SerializeField]
    private Rigidbody cameraRb;

    private bool isAlive = false;
    float notJumpingTimer = 0f;

    private void Start()
    {
        birdRb = gameObject.GetComponent<Rigidbody>();
        //Freezes the movement of the Player 
        birdRb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void Update() 
    {
        #region Startup
        // Jump To Start The Game
        if (isAlive == false && Input.GetKeyDown(KeyCode.Space))
        {
            //Unfreezes everything then freezes the position and rotation of Z, it's a 2d game, is useless
            birdRb.constraints = RigidbodyConstraints.None;
            birdRb.constraints = RigidbodyConstraints.FreezePositionZ;
            birdRb.constraints = RigidbodyConstraints.FreezeRotationZ;

            //Jumps
            BirdJump(birdRb);

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
            gameObject.transform.eulerAngles -= new Vector3(0, 0, 3);
        }
        else if (gameObject.transform.eulerAngles.z > 300 && notJumpingTimer > 0.8f)
        {
            gameObject.transform.eulerAngles -= new Vector3(0, 0, 2.5f);

        }

        #endregion


    }

    //Death
    private void OnCollisionEnter(Collision collision)
    {
        isAlive = false;
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
}