using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 Velocity;

    void FixedUpdate()
    {
        float dt = Time.deltaTime;
        //moves the object's position by constatnly changing one part of the vector like the
        //Velocity.x with time.deltatime, making sure it constatnly changes and mimics movement in this way
        //no force is applied in this instance
        float dx = Velocity.x * dt;
        float dy = Velocity.y;
        float dz = Velocity.z;

        transform.Translate(new Vector3(dx,dy,dz));
    }
}
