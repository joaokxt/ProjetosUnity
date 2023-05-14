using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    //public Spell fireBlade;
    public Spell[] spells; 

    public int exp;
    public int level = 1;


    void Start()
    {
        //fireBlade = new Spell("Fire Blade", 1, 35, 20);
    }

    void Update()
    {   
        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            fireBlade.Cast();
            exp += fireBlade.expGained;
        }
        */

        if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var spell in spells)
            {
                if (spell.lvlRequired == level)
                {
                    spell.Cast();
                    exp += spell.expGained;
                }
            }
        }
    }
}
