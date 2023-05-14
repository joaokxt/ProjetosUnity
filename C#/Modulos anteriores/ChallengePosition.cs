using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ChallengePosition : MonoBehaviour
{
    public Vector3[] positions;
    public int _index;

    void Start()
    {
        _index = indexes();
        transform.position = GetPosition(_index);
    }

    void Update()
    {
        
    }

    private int indexes()
    {
        int i = UnityEngine.Random.Range(0, positions.Length);
        return i;
    }

    private Vector3 GetPosition(int index)
    {
        return positions[index];
    }


}
