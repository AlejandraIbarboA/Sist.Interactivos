using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moverconfuerzas : MonoBehaviour
{
    private Vector position;
    private Vector displacement;
    private Vector velocity;
    private Vector acceleration;
    [SerializeField] private Vector wind;
    [SerializeField] private Vector gravity;
    [SerializeField] private float mass = 1;
    [Range(0, 1)][SerializeField] private float damping;
    

    private void Start()
    {
        position = transform.position;
    }

    private void FixedUpdate()
    {
        acceleration *= 0f;
        ApplyForce(wind + gravity);
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
        position = position + velocity * Time.fixedDeltaTime;
        //check bounds
        if (Mathf.Abs(position.x) >= 5)
        {
            position.x = Mathf.Sign(position.x) * 5;
            velocity.x *= -1;
            velocity *= damping;
        }
        if (Mathf.Abs(position.y) >= 5)
        {
            position.y = Mathf.Sign(position.y) * 5;
            velocity.y *= -1;
            velocity *= damping;
        }
        transform.position = position;

    }
    void ApplyForce (Vector Force)
    {
        acceleration += Force / mass;
    }
}
