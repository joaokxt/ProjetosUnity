using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    public Coisa[] inventario = new Coisa[10];
    private ItemDB _itemdatabase;

    void Start()
    {
        _itemdatabase = GameObject.Find("ItemDatabase").GetComponent<ItemDB>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _itemdatabase.AddItem(0, this);
        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
            _itemdatabase.RemoveItem(0, this);
        }    
    }
}
