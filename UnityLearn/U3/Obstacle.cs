using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    float speed = 25f;
    private PlayerController player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (player.isGameOver==false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }   

        if(transform.position.x < -5)
        {
            Destroy(this.gameObject);
        }
    }
}
