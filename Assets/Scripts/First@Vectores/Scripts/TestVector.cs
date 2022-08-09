using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestVector : MonoBehaviour
{
    [SerializeField] Slider valor;
    [SerializeField] Vector myFirstVector = new Vector();
    [SerializeField] Vector mySecondVector = new Vector();
    [SerializeField] float f;
    [SerializeField][Range (0,1)] float d;
    //float pmediox, pmedioy;
    Vector SumRes, RestRes, MultRes, vectormedio;

    void Start()
    {

    }
    void Update()
    {
        //vectores
        myFirstVector.Draw(Color.blue);
        mySecondVector.Draw(Color.red);
        //suma
        SumRes = (myFirstVector + mySecondVector);
        SumRes.Draw(Color.green);
        //Resta
        RestRes = (myFirstVector - mySecondVector) * -1;
        RestRes.Draw2(myFirstVector, Color.yellow);
        //multi
        MultRes = (myFirstVector * f);
        MultRes.Draw(Color.white);
        //slider
       // pmediox = (myFirstVector.x + mySecondVector.x) / 2;
       // pmedioy = (myFirstVector.y + mySecondVector.y) / 2;

        vectormedio= myFirstVector.learp(mySecondVector,d);
        //vectormedio.Draw(Color.black);
      
    }
     void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(vectormedio, 0.05f);
    }


}
