using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public int selectedDifficulty;
    public int easyDifficulty = 0;
    public int mediumDifficulty = 1;
    public int hardDifficulty = 2;
    public bool feito = false;



    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && feito == false)
        {
            selectedDifficulty = UnityEngine.Random.Range(0, 4);
            switch (selectedDifficulty)
            {
                case (0):
                    Debug.Log("A dificuldade atual é: Fácil");
                    break;
                case (1):
                    Debug.Log("A dificuldade atual é: Normal");
                    break;
                case (2):
                    Debug.Log("A dificuldade atual é: Difícil");
                    break;
                default:
                    Debug.Log("Dificuldade Inválida");
                    break;
            }
            feito = true;
        }

        feito = false;
    }
}
