using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDois : MonoBehaviour
{
    public int points;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            points = 50;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            points = 100;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            points = 0;
        }

        switch(points)
        {
            case (50):
                Debug.Log("Você tem 50 Pontos!");
                break;
            case (100):
                Debug.Log("UAU! Você tem 100 Pontos!");
                break;
            default:
                Debug.Log("Desculpe, mas você precisa de 50 ou 100 pontos para acessar esta parte...");
                break;
        }


    }

    
        
}
