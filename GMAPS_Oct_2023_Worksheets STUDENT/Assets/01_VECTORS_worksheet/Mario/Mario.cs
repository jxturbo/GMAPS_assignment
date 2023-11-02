using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private Vector3 gravityDir, gravityNorm;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //defines the direction of gravity and where the astronaut is moving
        gravityDir = planet.position - transform.position;
        moveDir = new Vector3(gravityDir.y ,-gravityDir.x, 0f);

        //determines where the astronaut go
        moveDir = moveDir.normalized * -1f;
        rb.AddForce(force * moveDir);

        //determines where the astronaut is pulled towards
        gravityNorm = gravityDir.normalized;
        rb.AddForce(gravityNorm * gravityStrength);
        float angle = Vector3.SignedAngle(Vector3.right,moveDir,Vector3.forward);

        // Assume that 'angle' should be applied around the Z axis
        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        rb.MoveRotation(rotation);

        //arrow displaying gravity 
        DebugExtension.DebugArrow(transform.position, gravityNorm * gravityStrength, Color.red);
        //arrow displaying astronaut direction
        DebugExtension.DebugArrow(transform.position, moveDir, Color.blue);
    }
}


