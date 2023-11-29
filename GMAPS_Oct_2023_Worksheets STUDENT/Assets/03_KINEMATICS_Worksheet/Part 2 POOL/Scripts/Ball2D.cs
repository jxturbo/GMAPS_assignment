using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);
    
    [HideInInspector]
    public float Radius;

    private void Start()
    {
        //stores the ball's position in a vector
        Position.x = transform.position.x;
        Position.y = transform.position.y;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        //reference used for detecting if mouse is in ball
        Radius = local_sprite_size.x / 2f;
    }

    public bool IsCollidingWith(float x, float y)
    {
        //done by using Vector2 method distance, which calculates the distance between two points
        float distance = Vector2.Distance(transform.position, new Vector2(x,y));
        return distance <= Radius;
    }

    public bool IsCollidingWith(Ball2D other)
    {
        //done using HVector2D instead of distance
        float distance = Util.FindDistance(Position, other.Position);
        return distance <= Radius + other.Radius;
    }

    public void FixedUpdate()
    {
        UpdateBall2DPhysics(Time.deltaTime);
    }

    private void UpdateBall2DPhysics(float deltaTime)
    {
        //determines the change in value of x and y over time
        float displacementX = Velocity.x * deltaTime;
        float displacementY = Velocity.y * deltaTime;
        //add those values to the position vector
        Position.x += displacementX;
        Position.y += displacementY;
        //sets those values to the transform.position
        //since these values are affected by deltaTime, they will continue to keep moving in the direction 
        //of the vector created by Position influenced by the displacement variables
        transform.position = new Vector2(Position.x, Position.y);
    }
}

