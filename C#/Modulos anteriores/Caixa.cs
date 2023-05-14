using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Caixa : Bank
{
    public int availableCashTolend;

    public void ApproveLending()
    {
        Debug.Log("You are awarded a loan!");
    }
}
