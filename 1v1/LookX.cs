using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField]
    float _horizontalSensitivity;

    void Update()
    {
        float _mouseX = Input.GetAxis("Mouse X");
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += _mouseX * _horizontalSensitivity;
        transform.localEulerAngles = newRotation;
    }
}
