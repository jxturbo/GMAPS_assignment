using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsCaptain = true;
    public Player OtherPlayer;

    float Magnitude(Vector3 vector)
    {
       return Mathf.Sqrt(vector.x * vector.x + vector.z * vector.z);
    }

    Vector3 Normalise(Vector3 vector)
    {
        float mag = Magnitude(vector);
        vector.x /= mag;
        vector.z /= mag;
        return vector;
    }

    float Dot(Vector3 vectorA, Vector3 vectorB)
    {
       return vectorA.x * vectorB.x + vectorA.z * vectorB.z;
    }

    float AngleToPlayer(Vector3 vectorA, Vector3 vectorB)
    {
        return (float)Mathf.Acos(Dot(vectorA, vectorB)/(Magnitude(vectorB) * Magnitude(vectorA)));
    }

    void Update()
    {
        if (IsCaptain)
        {
            //vector from captain to target vector
            Vector3 toOtherPlayer = OtherPlayer.transform.position - transform.position;
            //draws the vector from captain to target
            DebugExtension.DebugArrow(transform.position, toOtherPlayer, Color.black);
            //draws the captain's forward vector
            DebugExtension.DebugArrow(transform.position, transform.forward, Color.blue);
            //find angles creates a radian, not degree. 
            //we need degree so we use rad2deg
             float angle = AngleToPlayer(toOtherPlayer, transform.forward) * Mathf.Rad2Deg;
             Debug.Log(angle);
        }
    }
}
