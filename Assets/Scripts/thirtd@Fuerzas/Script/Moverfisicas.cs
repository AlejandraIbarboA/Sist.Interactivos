using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moverfisicas : MonoBehaviour
{
    private Vector position;
    private Vector displacement;
    private Vector velocity;
    private Vector acceleration;
    [SerializeField]private bool useFluidfriction = false;
    [SerializeField] private Vector wind;
    [SerializeField] private float mass = 1;
    [Range(0, 1)][SerializeField] private float damping;
    [SerializeField] private float gravedad;
    [SerializeField] float frictionCoefficient=0.5f;
    



    private void Start()
    {
        position = transform.position;
    }

    private void FixedUpdate()
    {
        acceleration *= 0f;
        //apply gravity
        float pesoescalar = mass * gravedad;
        Vector peso = new Vector(0, pesoescalar);
        ApplyForce(peso);    

        // aply fluid friction
        if (useFluidfriction)
        {
            if (transform.position.y <= 0)
            {
                float frontalArea = transform.localScale.x;
                float velocityMagnitude = velocity.magnitude;
                Vector FluidFriction = velocity.normalized * frontalArea * velocityMagnitude*velocityMagnitude*-0.5f;
                ApplyForce(FluidFriction);
            }
         
        }
        else      //apply friction
        {
            float N = -mass * gravedad;
            Vector friction = velocity.normalized * frictionCoefficient * N * -1;
            ApplyForce(friction);
            //ApplyForce(wind);
            friction.Draw2(position, Color.green);

        }


        Move();

      
    }

    private void Update()
    {
        //Debug vectors
        //position.Draw(Color.red);
        //displacement.Draw2(position, Color.green);
        //acceleration.Draw2(position, Color.blue);
        velocity.Draw2(position, Color.red);

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
