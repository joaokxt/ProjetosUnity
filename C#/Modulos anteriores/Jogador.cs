using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{ 

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            UtilityHelper.NewColor(this.gameObject, Color.blue, true);
        }
    }
}
