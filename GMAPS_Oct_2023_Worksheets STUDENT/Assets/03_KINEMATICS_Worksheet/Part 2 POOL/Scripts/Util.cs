using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        //formula for distance based on magnitude on pythagorous theorem and magnitude of vectors
        //a square plus b square equals to c square being one such formula
        return Mathf.Sqrt(Mathf.Sqrt(p1.x * p1.x + p1.y * p1.y) + Mathf.Sqrt(p2.x * p2.x + p2.y * p2.y));
    }
}

