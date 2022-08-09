using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testvelocidad : MonoBehaviour
{

    Vector position;
    //[SerializeField] Vector displacement;
    private Vector displacement;
    [SerializeField] Vector velocity;

    private void Start()
    {
        //displacement = velocity * (1f / 60f); //calcula el movimiento por frame, pierdee precision
        displacement = velocity * (Time.deltaTime); //es mas preciso
        position = transform.position; //new MyVector(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        //Debug vectors
        position.Draw(Color.red);
        displacement.Draw2(position, Color.green);
        Move();
    }
    public void Move()
    {
        //calculate displacement and new position
        position += displacement;
        //check bounds
        if (Mathf.Abs(position.x) >= 5)
        {
            position.x = Mathf.Sign(position.x) * 5;
            displacement.x *= -1;
        }
        if (Mathf.Abs(position.y) >= 5)
        {
            position.y = Mathf.Sign(position.y) * 5;
            displacement.y *= -1;
        }
        //update position
        transform.position = position;

    }
}
