using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Main : MonoBehaviour
{
    
    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Espaço");
        }

        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("Segurando E");
        }
        
        if(Input.GetKeyUp(KeyCode.F))
        {
            Debug.Log("Levantou F");
        }
    }
}