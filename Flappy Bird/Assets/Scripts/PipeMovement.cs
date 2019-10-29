using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PipeMovement : MonoBehaviour
{
    Rigidbody rb;
    float deathtimer = 0;
    void Start()
    {
        // Puts the pipes in movement towards the player
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-7, 0, 0);
    }
    //Destroys the pipe after 10 seconds
    
    private void DestroyObjectDelayed()
    {
        Destroy(rb.gameObject, 2);
        print("dead");
    }

    
}
