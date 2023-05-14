using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class MEtodos : MonoBehaviour
{
    public int total;
    public int total2;
    
    void Start()
    {
        /*
        total = Sum(3, 4);
        total2 = Sum(1, 3);
        */

        transform.position = GetPos(2, 6, 8);

    }

    void Update()
    {
        
    }

    public Vector3 GetPos(float x, float y, float z)
    {
        Vector3 pos = new Vector3(x, y, z);
        return pos;
    }

    /* 
    Poderia ter feito:

    public void Start()
    {
        GetPosition(new Vector3 = (0, 0, 0);
    }

    public void GetPosition(Vector3 pos)
    {
        transform.position = pos;
    }
    */


    public int Sum(int a, int b)
    {
        return a + b;
    }
}
