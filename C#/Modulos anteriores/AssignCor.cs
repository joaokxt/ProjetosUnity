using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignCor : MonoBehaviour
{
    public GameObject cubo;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AssignColor(cubo, Color.red);
        }
    }

    private void AssignColor(GameObject objeto, Color cor)
    {
        objeto.GetComponent<Renderer>().material.color = cor;
    }
}
