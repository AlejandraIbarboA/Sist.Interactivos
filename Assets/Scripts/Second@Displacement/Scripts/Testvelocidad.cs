using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testvelocidad : MonoBehaviour
{

    private Vector position;
    private Vector displacement;
    private Vector velocity;
    [SerializeField] Vector acceleration;
    private int state;


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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (state)
            {
                case 0: 
                    acceleration.x = -acceleration.y;
                    velocity.y = 0;
                    acceleration.y *= 0;
                    state = 1;
                    break;
                case 1:
                    acceleration.y = acceleration.x;
                    velocity.x = 0;
                    acceleration.x *= 0;
                    state = 2;
                    break;
                case 2:
                    acceleration.x = -acceleration.y;
                    velocity.y = 0;
                    acceleration.y *= 0;
                    state=3;
                    break;
                case 3:
                    acceleration.y = acceleration.x;
                    velocity.y = 0;
                    acceleration.y *= 0;
                    state = 1;
                    break;
            }
        }

    }
}
