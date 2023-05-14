using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Teste
{
    public class Player
    {
        public string name;
        public int id;

        public Player(int id)
        {
            this.id = id;
        }
    }
    public class Dictionary : MonoBehaviour
    {
        public Dictionary<int, Coisa> itemDictrionary = new Dictionary<int, Coisa>();

        public Dictionary<int, Player> playerDictionary = new Dictionary<int, Player>();

        public Dictionary<string, int> people = new Dictionary<string, int>();

        Player p1;
        Player p2;
        Player p3;


        void Start()
        {
            Coisa sword = new Coisa();
            sword.name = "Sword";
            sword.id = 0;

            Coisa bread = new Coisa();
            bread.name = "Bread";
            bread.id = 1;

            Coisa cape = new Coisa();
            cape.name = "Cape";
            cape.id = 2;

            itemDictrionary.Add(0, sword);
            itemDictrionary.Add(1, bread);
            itemDictrionary.Add(2, cape);

            /*foreach(KeyValuePair<int, Coisa> item in itemDictrionary)
            {
                Debug.Log($"Key: {item.Key}, Value: {item.Value.name}");
            }*/

            foreach (int key in itemDictrionary.Keys)
            {
                Debug.Log($"Key: {key}");
            }

            foreach (Coisa item in itemDictrionary.Values)
            {
                Debug.Log($"Item: {item.name}");
            }

            if (itemDictrionary.ContainsKey(60))
            {
                Debug.Log("You have it");
                var randomItem = itemDictrionary[60];
            }
            else
            {
                Debug.Log("It doesn't exist");
            }

            p1 = new Player(1);
            p1.name = "joaokxt";
            p2 = new Player(200);
            p2.name = "Petter_854";
            p3 = new Player(5);
            p3.name = "RickyGonza";

            playerDictionary.Add(p1.id, p1);
            playerDictionary.Add(p2.id, p2);
            playerDictionary.Add(p3.id, p3);

            //Act 3:

            people.Add("James", 34);
            people.Add("Mary", 25);
            people.Add("Charles", 42);
            people.Add("Marta", 38);

            int jamesAge = people["James"];

            Debug.Log(jamesAge);

        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //                           Eu só posso escrever isto aqui pois declarei p2 globalmente lá encima (antes de void start)
                var player = playerDictionary[p2.id];
                Debug.Log("Player name: " + player.name);
            }
        }
    }

}
