using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioHVector2D : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private HVector2D gravityDir, gravityNorm;
    private HVector2D moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //defines the direction of gravity and where the astronaut is moving
        gravityDir = new HVector2D(planet.position - transform.position);
        gravityNorm = gravityDir;
        moveDir = new HVector2D(gravityDir.y, -gravityDir.x);

        //determines where the astronaut go
        moveDir.Normalize();
        moveDir = moveDir * -1;
        rb.AddForce(force * moveDir.ToUnityVector3());

        //determines where the astronaut is pulled towards
        gravityNorm.Normalize();
        Debug.Log(gravityNorm);
        Debug.Log(gravityDir);
        rb.AddForce(gravityNorm.ToUnityVector3() * gravityStrength);
        float angle = Vector3.SignedAngle(Vector3.right,moveDir.ToUnityVector3(),Vector3.forward);

         // Assume that 'angle' should be applied around the Z axis
        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        rb.MoveRotation(rotation);
        //arrow displaying gravity 
        DebugExtension.DebugArrow(transform.position, gravityNorm.ToUnityVector3() * gravityStrength, Color.red);
        //arrow displaying astronaut direction
        DebugExtension.DebugArrow(transform.position, moveDir.ToUnityVector3(), Color.blue);
    }
}
