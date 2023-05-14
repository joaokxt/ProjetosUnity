using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Main : MonoBehaviour
{
    public delegate void Teleport(Vector3 pos);
    public static event Teleport OnTeleport;


    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (OnTeleport != null)
            {
                Vector3 pos = new Vector3(5, 9, 0);
                OnTeleport(pos);
            }
               
        }
    }
}
