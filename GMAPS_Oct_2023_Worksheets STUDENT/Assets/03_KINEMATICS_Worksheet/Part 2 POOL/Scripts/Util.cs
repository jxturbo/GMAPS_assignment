using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        //formula for distance based on vector created from p1 and p2
        //followed by using opposite as y value and adjacent as a value.
        //a square plus b square equals to c square being one such formula
        //note: c represents the hypothenus in this case
        float a = p2.x - p1.x;
        float b = p2.y - p1.y;
        return Mathf.Sqrt(a * a + b * b);
    }
}

