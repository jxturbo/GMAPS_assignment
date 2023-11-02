using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX = 5, maxY = 5;

    private void Start()
    {
        CalculateGameDimensions();
        if (Q2a)
        {
            Question2a();
        }
            
        if (Q2b)
        {

            Question2b(20);
        }

        if (Q2d)
        {
            Question2d();
        }

        if (Q2e)
        {
            Question2e(20);
        }
        if (Q3a)
        {
            Question3a();
        }

        if (Q3b)
        {
            Question3b();
        }

        if (Q3c)
        {
            Question3c();  
        }

        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight;

        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minX = -maxX;
        minY = -maxY;
    }

    void Question2a()
    {
        startPt = new Vector2(0,0);
        endPt = new Vector2(2,3);

        //initialises and activates a line with the specified data input.
        //note: if the number of lines already initialised is at the max number of lines,
        //any new initialised lines replces the ones already initialised.
        //note1: startPt is the line's start position, endPt is the line's end position
        //0.02f is the line's width and Color.black is the line's colour
        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);
        drawnLine.EnableDrawing(true);

        //vector of the line created from the start to endpoint
        Vector2 vec2 = endPt - startPt;
        Debug.Log("Magnitude = " + vec2.magnitude);
    }

    void Question2b(int n)
    {
        for(int i = 1; i <= n; i++)
        {
            startPt = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));
            endPt = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));
            Debug.Log(startPt);
            Debug.Log(endPt);
            drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);
            drawnLine.EnableDrawing(true);

        }
    }

    void Question2d()
    {
        DebugExtension.DebugArrow(new Vector3(0,0,0), new Vector3(5,5,0),Color.red, 60f);
    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            // Your code here
            endPt = new Vector2(
                Random.Range(-maxX, maxX), 
                Random.Range(-maxY, maxY));
            DebugExtension.DebugArrow(
               new Vector3(0, 0, 0),
               new Vector3(endPt.x,endPt.y,Random.Range(-maxX, maxX)),
               Color.white,
               60f);
        }  
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = new HVector2D(a.x + b.x, a.y + b.y);
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        // Your code here
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), -b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, -b.ToUnityVector3() + a.ToUnityVector3() , Color.white, 60f);
        // Your code here

        Debug.Log("Magnitude of a = " +  a.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of b = " +  b.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of c = " +  c.Magnitude().ToString("F2"));
        // Your code here
        // ...
    }

    public void Question3b()
    {
        // Your code here
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = a*2;


        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.right, b.ToUnityVector3(), Color.green, 60f);
        b = a/2;
        DebugExtension.DebugArrow(Vector3.left, b.ToUnityVector3(), Color.green, 60f);
        // Your code here
    }

    public void Question3c()
    {
        HVector2D a = new HVector2D(3, 5);
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        a.Normalize();
        HVector2D b = new HVector2D(a.x, a.y);
        
        DebugExtension.DebugArrow(Vector3.right, b.ToUnityVector3(), Color.green, 60f);
        Debug.Log("Magnitude of a = " +  a.Magnitude().ToString("F2"));
    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        HVector2D v1 = b - a;
        // Your code here
        HVector2D v2 = c - a;

        HVector2D proj = v2.Projection(v1);

        DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
