using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public int saude = 100;

    public void Dano(int pontosDeDano)
    {
        saude -= pontosDeDano;

        if(saude < 1)
        {
            saude = 0;
            Destroy(this.gameObject);
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            Dano(5);
        }
    }
}
