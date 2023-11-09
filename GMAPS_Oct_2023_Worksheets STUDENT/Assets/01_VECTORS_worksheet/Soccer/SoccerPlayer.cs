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
        //stores 10 random numbers in an array
        float[] test = new float[10]; 
        for(int i = 0; i <10; i ++)
        {
            float height = Random.Range(5f,20f);
            Debug.Log(height);
            test[i] = height;
        }
        //Mathf.Min used to determine smallest out of the numbers in the array
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
            //creates a vector from main player to otherplayer its pointing to
            Vector3 toPlayer = OtherPlayers[i].transform.position - transform.forward;
            toPlayer = Normalise(toPlayer);
            float dot = Dot(toPlayer, transform.forward);
            //calculate the angle between the two vectors
            float angle = Mathf.Acos(dot/(Magnitude(transform.forward) * Magnitude(toPlayer)));
            angle = angle * Mathf.Rad2Deg;
            //if the angle is less than the current minimum angle, it means the line is closer to this otherplayer instance
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
            //draws a vector from the gameobject to the other player in the array
            Vector3 OtherVector = other.transform.position - transform.position;
            Debug.DrawRay(transform.position, OtherVector, Color.black);
       }
    }

    void Update()
    {
        DebugExtension.DebugArrow(transform.position, transform.forward, Color.red);

        if(IsCaptain)
        {
            //rotates the player, since the ray always goes to player's forward here, the ray will follow player rotation
            angle += Input.GetAxis("Horizontal") * rotationSpeed;
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
            SoccerPlayer targetPlayer = FindClosestPlayerDot();
            //if the line is close enough to another player, it turns them green, otherwise it turns everything else white
            targetPlayer.GetComponent<Renderer>().material.color = Color.green;
            //note: a seperate function can be placed here to store the code below that is run only when the code above is run for efficiency
            foreach(SoccerPlayer other in OtherPlayers.Where(t => t != targetPlayer))
            {
                other.GetComponent<Renderer>().material.color = Color.white;
            }
        }

        DrawVectors();


        
    }
}


