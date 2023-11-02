using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoccerPlayer : MonoBehaviour
{
    public bool IsCaptain = false;
    public SoccerPlayer[] OtherPlayers;
    public float rotationSpeed = 1f;

    float angle = 0f;

    private void Start()
    {
        OtherPlayers = FindObjectsOfType<SoccerPlayer>().Where(t => t != this).ToArray();
        if(IsCaptain)
        {
            FindMinimum();
        }

       
    }
    void FindMinimum()
    {
        float[] test = new float[10]; 
        for(int i = 0; i <10; i ++)
        {
            float height = Random.Range(5f,20f);
            Debug.Log(height);
            test[i] = height;
        }
        //Debug.Log("The minimum height is " + Mathf.Min(test));
    }
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

    SoccerPlayer FindClosestPlayerDot()
    {
        SoccerPlayer closest = null;
        float minAngle = 180f;
        

        for(int i = 0; i < OtherPlayers.Length; i ++)
        {
            Vector3 toPlayer = OtherPlayers[i].transform.position - transform.forward;
            toPlayer = Normalise(toPlayer);
            float dot = Dot(toPlayer, transform.forward);
            float angle = Mathf.Acos(dot/(Magnitude(transform.forward) * Magnitude(toPlayer)));
            angle = angle * Mathf.Rad2Deg;
            if(angle < minAngle)
            {
                minAngle = angle;
                closest = OtherPlayers[i];
            }
        }
        return closest;
    }

    void DrawVectors()
    {
       foreach (SoccerPlayer other in OtherPlayers)
       {
            Vector3 OtherVector = other.transform.position - transform.position;
            Debug.DrawRay(transform.position, OtherVector, Color.black);
       }
    }

    void Update()
    {
        DebugExtension.DebugArrow(transform.position, transform.forward, Color.red);

        if(IsCaptain)
        {
            angle += Input.GetAxis("Horizontal") * rotationSpeed;
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
            SoccerPlayer targetPlayer = FindClosestPlayerDot();
            targetPlayer.GetComponent<Renderer>().material.color = Color.green;
            foreach(SoccerPlayer other in OtherPlayers.Where(t => t != targetPlayer))
            {
                other.GetComponent<Renderer>().material.color = Color.white;
            }
        }

        DrawVectors();


        
    }
}


