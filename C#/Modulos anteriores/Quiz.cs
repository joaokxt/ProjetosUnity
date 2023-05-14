using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    public int[] quiz = { 0, 0, 0, 0, 0 };
    private int amount = 0;
    private float average;

   
    void Start()
    {
        foreach(int quantity in quiz)
        {
            amount++;
        }
        

        System.Random nota = new System.Random();
        quiz[0] = nota.Next(1, 11);
        quiz[1] = nota.Next(1, 11);
        quiz[2] = nota.Next(1, 11);
        quiz[3] = nota.Next(1, 11);
        quiz[4] = nota.Next(1, 11);

        average = (quiz[0] + quiz[1] + quiz[2] + quiz[3] + quiz[4]) / amount;


        Debug.Log($"Resultado: {quiz[0]}");
        Debug.Log($"Resultado: {quiz[1]}");
        Debug.Log($"Resultado: {quiz[2]}");
        Debug.Log($"Resultado: {quiz[3]}");
        Debug.Log($"Resultado: {quiz[4]}");
        Debug.Log($"Average: {average}");
    }

    
    void Update()
    {
        
    }
}
