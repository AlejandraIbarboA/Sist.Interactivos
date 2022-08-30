using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttraction : MonoBehaviour
{
    [SerializeField] private GravityAttraction target;
    [SerializeField] private Vector velocity;
    [SerializeField] private Vector acceleration;
    [SerializeField] private float mass = 1f;
    private Vector position;

    private  void Start()
    {
        position = transform.position;
    }
    private void FixedUpdate()
    {
        Vector r = target.transform.position - transform.position;
        float rmagntude =r.magnitude;
        Vector f = r.normalized* (target.mass * mass/rmagntude*rmagntude);
        ApplyForce(f);
        f.Draw2(position, Color.blue);

        Move();
    }

    void Update()
    {
        velocity.Draw2(position, Color.red);
    }
    public void Move()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;
        transform.position = position;
        if (velocity.magnitude > 10)
        {
            velocity.Normalize();
            velocity *= 10;
        }



    }
    void ApplyForce(Vector Force)
    {
        acceleration += Force / mass;

    }
}

