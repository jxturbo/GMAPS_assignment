using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
	public LineFactory lineFactory;
	public GameObject ballObject;

	private Line drawnLine;
	private Ball2D ball;

	private void Start()
	{
		ball = ballObject.GetComponent<Ball2D>();
	}

	void Update()
	{
        //start line pos is a vector3 in this case
        //its also where the mouse is found in the game world
        var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Start line drawing
		if (Input.GetMouseButtonDown(0))
		{
			//checks if the mouse is inside the ba;;
			if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y))
			{
                //has the line factory draw the appropriate line 
				drawnLine = lineFactory.GetLine(startLinePos, ball.transform.position, 1f, Color.black);
                //shows the line and makes it visible for the player
				drawnLine.EnableDrawing(true);
			}
		}
		else if (Input.GetMouseButtonUp(0) && drawnLine != null)
		{
			drawnLine.EnableDrawing(false);

			//update the velocity of the white ball.
            //the vector of direction is from the end of the line to the ball
			HVector2D v = new HVector2D(ball.transform.position.x - drawnLine.transform.position.x, ball.transform.position.y - drawnLine.transform.position.y);
            //sets the velocity, a vector to this value to determine direction of movement
			ball.Velocity = v;
			drawnLine = null; // End line drawing            
		}

		if (drawnLine != null)
		{
            //allows the player to drag the end of the line anywhere so long as mouse button 1 is held
			drawnLine.end = startLinePos; // Update line end
		}
	}

	/// <summary>
	/// Get a list of active lines and deactivates them.
	/// </summary>
	public void Clear()
	{
		var activeLines = lineFactory.GetActive();

		foreach (var line in activeLines)
		{
			line.gameObject.SetActive(false);
		}
	}
}
