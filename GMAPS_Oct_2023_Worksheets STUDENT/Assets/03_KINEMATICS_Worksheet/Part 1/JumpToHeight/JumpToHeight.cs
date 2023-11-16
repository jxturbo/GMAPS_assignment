using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToHeight : MonoBehaviour
{
    public float Height = 1f;
    Rigidbody rb;

    private void Start()
    {
        rb =  GetComponent<Rigidbody>();
    }

    void Jump()
    {
        // v*v = u*u + 2as
        // u*u = v*v - 2as
        // u = sqrt(v*v - 2as)
        // v = 0, u = ?, a = Physics.gravity, s = Height
        //Mathf.Abs used here since physics,gravity is a vector and we need to convert it into a float
        //note: [Physics.gravity] The gravity applied to all rigid bodies in the Scene.(in the form of a vector)
        float u = Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.y) * Height);
        //sets its velocity to the new vector which in this case is going up by u
        rb.velocity = new Vector3(0,u,0);

        // float jumpForce = Mathf.Sqrt(-2 * Physics2D.gravity.y * Height);
        // rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}

