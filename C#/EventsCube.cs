using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsCube : MonoBehaviour
{
   
    void Start()
    {
        Main.OnTeleport += Spawn;
    }

    public void Spawn(Vector3 pos)
    {
        transform.position = pos;
    }

    void OnDisable()
    {
        Main.OnTeleport -= Spawn;
    }
}
