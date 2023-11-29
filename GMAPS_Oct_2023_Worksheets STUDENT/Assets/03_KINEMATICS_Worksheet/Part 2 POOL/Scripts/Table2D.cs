using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table2D : MonoBehaviour
{
    public List<Ball2D> balls;

    private void Start()
    {

    }

    bool CheckBallCollision(Ball2D toCheck)
    {
        //looks through each ball against the first ball
        //cueball
        for (int i = 0; i < balls.Count; i++)
        {
            Ball2D ball = balls[i];
            //check if the ball in i position is close enough to cue ball
            //and also making sure that the ball in i is NOT cueball
            if (ball.IsCollidingWith(toCheck) && toCheck != ball)
            {
                return true;
            }
        }

        return false;
    }

    private void FixedUpdate()
    {
        //check if cueball if close enough to any ball
        if (CheckBallCollision(balls[0]))
        {
            Debug.Log("COLLISION!");
        }
    }
}
