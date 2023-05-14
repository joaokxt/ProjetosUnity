using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTres : MonoBehaviour
{
    public int weaponID;

    void Start()
    {
        
    }


    void Update()
    {
       switch(weaponID)
        {
            case 1:
                Debug.Log("Arma atual: M4A1-S");
                break;        
            case 2:
                Debug.Log("Arma atual: USP-S");
                break;
            case 3:
                Debug.Log("Arma atual: Faca");
                break;
            default:
                Debug.Log("Nenhuma arma equipada");
                break;
        }
        
    }



    
        
}
