using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Properties : MonoBehaviour
{

    //Property

    //private bool isGameOver;

    //Aqui eu preciso da variavel E da propriedade

    /*public bool IsGameOver
    {
        get
        {
            return isGameOver;
        }
        set
        {
            if(value == true)
            {
                Debug.Log("You died!");
            }
            isGameOver = true;
        }
    }
    */

    //Auto property:

    //Somente este script poderá definir o valor, mas todos poderão ver ele

    public bool IsGameOver { get; private set; }


    
    void Start()
    {
        IsGameOver = false;

        if(IsGameOver)
        {
            //bla bla bla
        }
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            IsGameOver = true;
        }
    }
}
