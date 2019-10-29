using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpsideDownMovement : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void OnAwake()
    {
        rb = GetComponent<Rigidbody>();
        rb.gameObject.transform.eulerAngles = new Vector3(0, 0, 180);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.gameObject.transform.eulerAngles = new Vector3(0, 0, 180);
    }
}
