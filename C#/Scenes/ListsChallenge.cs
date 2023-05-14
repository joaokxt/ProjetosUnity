using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ListsChallenge : MonoBehaviour
{
    public List<string> names = new List<string>();
    
    
    

    void Start()
    {
        names[0] = "Bob";
        names[1] = "Charles";
        names[2] = "Lucia";
        names[3] = "Edivaldo";
        names[4] = "Ednaldo";

        foreach(var name in names)
        {
            Debug.Log(name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var nameRemoval = names[UnityEngine.Random.Range (0, names.Count)];

            names.Remove(nameRemoval);

            foreach(var name in names)
            {
                Debug.Log(name);
            }

            Debug.Log($"Removemos o nome: {nameRemoval}");
        }
    }
}
