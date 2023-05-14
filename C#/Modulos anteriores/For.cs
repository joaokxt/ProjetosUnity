using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class For : MonoBehaviour
{
    //public string[] names;
    //public string[] names = new string[6];
    //public string[] names = {"ssds", "dmasld", ",as;das"'};


    public int _speed;
    public int maxSpeed;

    void Start()
    {
        maxSpeed = UnityEngine.Random.Range(60, 120);
        Debug.Log("Max speed is: " + maxSpeed);
        StartCoroutine(SpeedRoutine());

    }


    void Update()
    {

    }

    IEnumerator SpeedRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            _speed += 5;
            Debug.Log("Speed is: " + _speed);
            
            if(_speed > maxSpeed)
            {
                break;
            }
        }
    }





}




