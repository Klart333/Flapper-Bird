using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class BirdMovement : MonoBehaviour
{
    Rigidbody birdRb;
    [SerializeField]
    Rigidbody cameraRb;

    bool isAlive = false;
    //bool isJumping = false;

    void Start()
    {
        birdRb = gameObject.GetComponent<Rigidbody>();
        //Freezes the movement of the Player
        birdRb.constraints = RigidbodyConstraints.FreezeAll;
    }

    void Update()
    {
        // To Start The Game
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

        if (isAlive == true && Input.GetKeyDown(KeyCode.Space))
        { 
            BirdJump(birdRb);
        }
        //Returns the rotation to normal
        if (gameObject.transform.eulerAngles.z > 1)
        {
            gameObject.transform.eulerAngles -= new Vector3(0, 0, 2);
        }

    }
    //Death
    private void OnCollisionEnter(Collision collision)
    {
        isAlive = false;

    }

    //Makes the Jump And Rotation
    void BirdJump(Rigidbody rb)
    {
        int jumpForce = 8;

        rb.velocity = new Vector3(0, jumpForce, 0);

        //Rotation
        gameObject.transform.eulerAngles = new Vector3(0, 0, 46);

    }
}


