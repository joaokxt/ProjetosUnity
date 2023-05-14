using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilityHelper 
{
    public static void NewColor(GameObject obj, Color color, bool randomColor = false)
    {
        if(randomColor == true)
        {
            color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        }

        obj.GetComponent<Renderer>().material.color = color;
    }

}
