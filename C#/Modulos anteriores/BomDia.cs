using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomDia : MonoBehaviour
{
    public GameObject[] players;

    void Start()
    {
        players = GetAllPlayers();
    }

   
    void Update()
    {
   

    }

    //Método retornará array de GameObjects.
    GameObject[] GetAllPlayers()
    {
        //Array de GameObjects com a tag Player.
        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");
        
        //Por cada objeto no array.
        foreach(var p in allPlayers)
        {
            //Mudar a cor = Cor com um número aleatorio para cada valor do RGB.
            p.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value); 
        }

        //Retorna todos os objetos do array.
        return allPlayers;

    }
}
