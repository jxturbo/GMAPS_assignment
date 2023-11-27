using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D 
{
    public float[,] entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        // your code here
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int y = 0; y < multiArray.GetLength(0); y++)
        {
            for(int x = 0; x < multiArray.GetLength(1); x++)
            {
                entries[y, x] = multiArray[y, x];
            }
        }
    }
    //fills in the following matrix using 9 floats for 9 slots
    //00 01 02
    //10 11 12
    //20 21 22
    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        entries[0,0] = m00;
        entries[0,1] = m01;
        entries[0,2] = m02;
        entries[1,0] = m10;
        entries[1,1] = m11;
        entries[1,2] = m12;
        entries[2,0] = m20;
        entries[2,1] = m21;
        entries[2,2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();
        for (int y = 0; y < left.entries.GetLength(0); y++)
        {
            for(int x = 0; x < left.entries.GetLength(1); x++)
            {
                //takes the values stored in the 00 position(example) from both left and right and adds them together
                //to form 1 number and sets it to the same position in the result matrix
                result.entries[y, x] = left.entries[y, x] + right.entries[y, x];
            }
        }
        return result; // your code here
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();
        for (int y = 0; y < left.entries.GetLength(0); y++)
        {
            for(int x = 0; x < left.entries.GetLength(1); x++)
            {
                //takes the values stored in the 00 position(example) from both left and right and deducts one from the other
                //to form 1 number and sets it to the same position in the result matrix
                result.entries[y, x] = left.entries[y, x] - right.entries[y, x];
            }
        }
        return result; // your code here
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D result = new HMatrix2D();
        for (int y = 0; y < left.entries.GetLength(0); y++)
        {
            for(int x = 0; x < left.entries.GetLength(1); x++)
            {
                //takes the values stored in the 00 position(example) from both left and right and multiples one with the other
                //to form 1 number and sets it to the same position in the result matrix
                result.entries[y, x] = left.entries[y, x] * scalar;
            }
        }
        return result; 
    }

    // // Note that the second argument is a HVector2D object
    // // Also note that HVector2D has three values, h is just rarely used in most cases
    //and has a natural number of 1
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D
        (
            left.entries[0, 0] * right.x + left.entries[0, 1] * right.y + left.entries[0, 2] * right.h, 
            left.entries[1, 0] * right.x + left.entries[1, 1] * right.y + left.entries[0, 2] * right.h

        ); 
    }

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
	    /* 
            00 01 02    00 xx xx
            xx xx xx    10 xx xx
            xx xx xx    20 xx xx
            */
            left.entries[0, 0] * right.entries[0, 0] + left.entries[0, 1] * right.entries[1, 0] + left.entries[0, 2] * right.entries[2, 0],

	    /* 
            00 01 02    xx 01 xx
            xx xx xx    xx 11 xx
            xx xx xx    xx 21 xx
            */
            left.entries[0, 0] * right.entries[0, 1] + left.entries[0, 1] * right.entries[1, 1] + left.entries[0, 2] * right.entries[2, 1],

            left.entries[0, 0] * right.entries[0, 2] + left.entries[0, 1] * right.entries[1, 2] + left.entries[0, 2] * right.entries[2, 2],

            left.entries[1, 0] * right.entries[0, 0] + left.entries[1, 1] * right.entries[1, 0] + left.entries[1, 2] * right.entries[2, 0],

            left.entries[1, 0] * right.entries[0, 1] + left.entries[1, 1] * right.entries[1, 1] + left.entries[1, 2] * right.entries[2, 1],

            left.entries[1, 0] * right.entries[0, 2] + left.entries[1, 1] * right.entries[1, 2] + left.entries[1, 2] * right.entries[2, 2],

            left.entries[2, 0] * right.entries[0, 0] + left.entries[2, 1] * right.entries[1, 0] + left.entries[2, 2] * right.entries[2, 0],

            left.entries[2, 0] * right.entries[0, 1] + left.entries[2, 1] * right.entries[1, 1] + left.entries[2, 2] * right.entries[2, 1],

            left.entries[2, 0] * right.entries[0, 2] + left.entries[2, 1] * right.entries[1, 2] + left.entries[2, 2] * right.entries[2, 2]




	    // and so on for another 7 entries
	    );
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < left.entries.GetLength(0); y++)
        {
            for(int x = 0; x < left.entries.GetLength(1); x++)
            {
                 //takes the values stored in the 00 position(example) from both left and right
                 //and checks if these values are not the same
                 //keeps checking until the values are no longer the same or all the positions have
                 //been looked through
                if(left.entries[y, x] != right.entries[y, x])
                {
                    return false;
                }
            }
        }
        return true;
        
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < left.entries.GetLength(0); y++)
        {
            for(int x = 0; x < left.entries.GetLength(1); x++)
            {
                //takes the values stored in the 00 position(example) from both left and right
                 //and checks if these values are  the same
                //keeps checking until the values are the same or all the positions have
                 //been looked through
                if(left.entries[y, x] != right.entries[y, x])
                {
                    return true;
                }
            }
        }
        return false;
        // your code here
    }

    // public override bool Equals(object obj)
    // {
    //     // your code here
    // }

    // public override int GetHashCode()
    // {
    //     // your code here
    // }

    // public HMatrix2D transpose()
    // {
    //     return; // your code here
    // }

    // public float getDeterminant()
    // {
    //     return; // your code here
    // }

    public void setIdentity()
    {
        for (int y = 0; y < entries.GetLength(0); y++)
        {
            //00 01 02
            //10 11 12
            //20 21 22
            for(int x = 0; x < entries.GetLength(1); x++)
            {
                //for 00 position, set the value to 1 for example
                //checks if x and y position values are the same
                entries[y, x] = x == y ? 1:0;
            }
        }
    }

    public void setTranslationMat(float transX, float transY)
    {
        //1 0 transX
        //0 1 transY
        //0 0 1
        setIdentity();
        entries[0,2] = transX;
        entries[1,2] = transY; 
    }

    public void setRotationMat(float rotDeg)
    {
        //cos(rad) -sin(rad) 0
        //sin(rad) cos(rad)  0
        //0        0         1
        setIdentity();
        float rad = rotDeg * (Mathf.PI / 180.0f);
        entries[0,0] =  Mathf.Cos(rad);
        entries[0,1] =  -Mathf.Sin(rad);
        entries[1,0] =  Mathf.Sin(rad);
        entries[1,1] =  Mathf.Cos(rad);
    }

    public void setScalingMat(float scaleX, float scaleY)
    {
        //scaleX 0      0
        //0      scaleY 0
        //0      0      1
        // your code here
        setIdentity();
        entries[0,0] =  scaleX;
        entries[1,1] =  scaleY;
    }

    public void Print()
    {
        //extracts the values of each position and prints them out with a space
        //after the third position of each row is reached, it moves to the next line
        //repeating the process
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}