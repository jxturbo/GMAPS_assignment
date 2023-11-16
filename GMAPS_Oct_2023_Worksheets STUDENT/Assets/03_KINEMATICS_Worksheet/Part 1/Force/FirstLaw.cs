using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
{
    public Vector3 force;
    Rigidbody rb;

    void Start()
    {
        //pushes the object's rigidbody with a force determined by a vector
        //eg (0,1,0) pushes it up
        rb = GetComponent<Rigidbody>();
        rb.AddForce(force);
    }

    void FixedUpdate()
    {
        Debug.Log(transform.position);
    }
}

