using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testvelocidad : MonoBehaviour
{

    private Vector position;
    private Vector displacement;
    private Vector velocity;
    [SerializeField] Vector acceleration;
    private int currentIndex = 0;
    Vector[] accelerations =
    {
        new Vector(0,-9.8f),
        new Vector(9.8f,0f),
        new Vector(0,9.8f),
        new Vector(-9.8f,0f),
    };


    private void Start()
    {
        position = transform.position; //new MyVector(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        //Debug vectors
        position.Draw(Color.red);
        displacement.Draw2(position, Color.green);
        acceleration.Draw2(position, Color.blue);
        velocity.Draw2(position, Color.cyan);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity *= 0;
            acceleration = accelerations[(++currentIndex) % accelerations.Length];
        }

    }
    public void Move()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        position= position + velocity * Time.fixedDeltaTime;
        //check bounds
        if (Mathf.Abs(position.x) >= 5)
        {
            position.x = Mathf.Sign(position.x) * 5;
            velocity.x *= -1;
        }
        if (Mathf.Abs(position.y) >= 5)
        {
            position.y = Mathf.Sign(position.y) * 5;
            velocity.y *= -1;
        }
        //update position
        transform.position = position;
        

    }
}



