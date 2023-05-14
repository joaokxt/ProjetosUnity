using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design.Serialization;
using System.Security.Permissions;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] //isto é para que possamos modificar a variável no editor
    private float _speed;

    [SerializeField]
    public Vector3 startPosition;

    public static Action onSpeedLimit;

    public bool feito = false;
    /*
    [SerializeField]                             
    private float _horizontalInput;

    [SerializeField]
    private float _verticalInput;
    */

    void Start()
    {
        startPosition = new Vector3(0, 0, 0);
        transform.position = startPosition;
        _speed = 0.0f;
        GetComponent<Renderer>().material.color = Color.green;
        Player.onSpeedLimit += ChangeColor;
        Player.onSpeedLimit += LimitMessage;
    }

    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if(Input.GetKey(KeyCode.D))
        {
            _speed += 0.5f;
        }

        if(Input.GetKey(KeyCode.A) && _speed >= 1)
        {
            _speed -= 0.5f;
        }

      
        //  Isto é igual a: new Vector3(1, 0, 0)* 5 * tempo real
        transform.Translate(new Vector3(horizontalInput, 0, 0) * _speed * Time.deltaTime);

        if (_speed >= 10)
        {
            if (feito == false)
            {
                Debug.Log("You're going too fast, slow down!!");
                SpeedLimit();
                feito = true;
            }
        }
        else
        {
            feito = false;
            GetComponent<Renderer>().material.color = Color.green;
        }

        if (_speed <= 1)
        {
            _speed = 1;
        }

        //Se tivessemos escrito:
        //transform.Translate(Vector3.left * _speed * Time.deltaTime);
        //seria igual a:  new Vector3(-1, 0, 0)* 5 * tempo real

        //float verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(new Vector3(0, verticalInput, 0) * _speed * Time.deltaTime);
    }

    public void SpeedLimit()
    {
        if (onSpeedLimit != null)
            onSpeedLimit();
    }

    public void ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void LimitMessage()
    {
        Debug.Log("Hey, slow down!!");
    }

}
