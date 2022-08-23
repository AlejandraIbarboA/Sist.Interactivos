using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public struct Vector
{
    public float x;
    public float y;

    public Vector(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public void Normalize()
    {
        float magnitudeCache = magnitude;
        if(magnitudeCache < 0.0001)
        {
            x = 0;
            y = 0;
            
        }
        else
        {
            x /= magnitudeCache;
            y /= magnitudeCache;
        }
     
    }
    public float magnitude =>Mathf.Sqrt(x * x + y * y);

    public Vector normalized
    {
        get
        {

            float distance = magnitude;
            if (distance < 0.0001)
            {              
                return new Vector(0, 0);
            }
            return new Vector(x / magnitude, y / magnitude);

        }
    }

    public override string ToString()
    {
        return $"[{x},{y}]";
    }
    public void Draw(Color color)
    {
        Debug.DrawLine(new Vector3(0, 0, 0), new Vector3(x, y, 0), color, 0);
    }
    public void Draw2(Vector3 origin, Color color)
    {
        Debug.DrawLine(new Vector3(origin.x, origin.y, 0), new Vector3(x + origin.x, y + origin.y, 0), color, 0);
    }
    public static implicit operator Vector3(Vector a)
    {
        return new Vector3(a.x, a.y, 0);
    }

    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector(a.x + b.x, a.y + b.y);
    }
    public static Vector operator -(Vector a, Vector b)
    {
        return new Vector(a.x - b.x, a.y - b.y);
    }

    public static Vector operator *(Vector a , float f)
    {
        return new Vector(a.x * f, a.y * f);
    }
    static public Vector operator /(Vector a, float b)
    {
        return new Vector(a.x / b, a.y / b);
    }
    static public Vector operator /(float b, Vector a)
    {
        return new Vector(a.x / b, a.y / b);
    }
    public Vector learp(Vector b, float t)
    {
        return this + ((b - this) * t);
    }

    public static implicit operator Vector(Vector3 a)
    {
        return new Vector(a.x, a.y);
    }




}
