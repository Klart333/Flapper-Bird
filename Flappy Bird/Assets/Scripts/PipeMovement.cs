using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PipeMovement : MonoBehaviour
{
    Rigidbody rb;
    
    void Start()
    {
        // Puts the pipes in movement towards the player
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-8, 0, 0); 

        Destroy(rb.gameObject, 7); //Destroys the pipe after 7 seconds
    }
   
    
}
