using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            Player player = other.GetComponent<Player>();
            player.BuyZoneIn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Player")
        {
            Player player = other.GetComponent<Player>();
            player.BuyZoneOut();
        }
    }
}
