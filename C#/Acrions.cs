using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class Acrions : MonoBehaviour
{
    public static Action<int, int> Sum;

    void Start()
    {
        Sum = (um, dois) =>
        {
            var total = um + dois;

            Debug.Log("Total: " + total);
        };

        Sum(5, 3);
    }
}

    
