using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarMover : MonoBehaviour
{
    [SerializeField] Vector3 polarpoint;
    [SerializeField] float angularSpeed;
    [SerializeField] float radialSpeed;
    [SerializeField] float radialAcceleration;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Increment Radius
        polarpoint.x += Time.deltaTime * radialSpeed;

        //Increment Theta
        polarpoint.y += Time.deltaTime * angularSpeed;

        //Convert to cartesian
        Vector cartesianPoint = Polar2Cartesian(polarpoint);


        //Draw
        cartesianPoint.Draw(Color.cyan);

        //update position
        transform.position = cartesianPoint;

        //check bounds
        CheckBounds();


    }
    Vector Polar2Cartesian(Vector polar)
    {
        float x = Mathf.Cos(polar.y * Mathf.Deg2Rad) * polar.x; //x es el radio y "y" es el angulo
        float y = Mathf.Sin(polar.y * Mathf.Deg2Rad) * polar.x;
        Vector unitdir = new Vector(x, y);
        return unitdir;
    }
    void CheckBounds()
    {
        if (Mathf.Abs(polarpoint.x) >= 5)
        {
            polarpoint.x = Mathf.Sign(polarpoint.x) * 5;
            //check if radius is inside the screen
            if (Mathf.Abs(radialAcceleration) > 0)
            {
                radialAcceleration = -radialAcceleration; //invertimos la aceleracion radial
            }
            else //invertimos si no hay aceleracion
            {
                radialSpeed = -radialSpeed; //inverimos la velocidad  
            }

        }
       
    }
}
