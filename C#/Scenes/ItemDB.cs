using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    public List<Coisa> ItemDatabase = new List<Coisa>();

    
    public void AddItem(int id, PlayerOne player)
    {
        foreach (var item in ItemDatabase)
        {
            if(id == item.id)
            {
                Debug.Log("We have it!");
                player.inventario[0] = item;
                return;
            }
        }

        Debug.Log("Item does not exist");
    }

    public void RemoveItem(int id, PlayerOne player)
    {
        foreach(var item in ItemDatabase)
        {
            if(id == item.id)
            {
                Debug.Log("Item removed!");
                player.inventario[0] = null;
                return;
            }

            Debug.Log("Você nem tem esse item!");
          
        }
    }
}
