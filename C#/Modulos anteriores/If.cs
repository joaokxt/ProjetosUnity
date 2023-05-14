using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.NetworkInformation;
using UnityEngine;

public class If : MonoBehaviour
{
    public GameObject cubo;
    public float speed;
    public float horizontalAxis;
    private bool feito = false;


    void Start() 
    {
        speed = 0;
        cubo.GetComponent<Renderer>().material.color = Color.red;
    }


    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");

        

        if (Input.GetKey(KeyCode.D))
        {
            speed += 0.1f;
        }


        if (Input.GetKey(KeyCode.A) && speed > 0)
        {
            speed -= 0.1f;
        }

        cubo.transform.Translate(new Vector3(horizontalAxis, 0, 0) * speed * Time.deltaTime);

        if (speed > 20) 
        {
            cubo.GetComponent<Renderer>().material.color = Color.blue;

            if(feito == false)
            {
                Debug.Log("Slow Down!");
                feito = true;
            }
        }
        else
        {
            feito = false;
            cubo.GetComponent<Renderer>().material.color = Color.green;
        }

        if (speed < 0)
        {
            speed = 0;
        }
        

    }
}
