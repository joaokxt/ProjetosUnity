using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField]
    private float _xSensitivity = 2.0f;

    void Start()
    {
        
    }

    void Update()
    {
        float _mouseX = Input.GetAxis("Mouse X");
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += _mouseX * _xSensitivity;
        transform.localEulerAngles = newRotation;       
    }


}
