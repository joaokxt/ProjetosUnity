using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFast : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;

    private Vector3 lookDirection;
    private float speed;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        speed = 4.0f;
    }

    void Update()
    {
        lookDirection = (player.transform.position - transform.position).normalized;
        //subtração para criar um vetor de direção.
        //.normalized altera o módulo do vetor pra 1.
        //assim, o inimigo não acelera demais quando ele está longe do jogador (pois o programa multiplica um vetor grande pela velocidade, resultando numa força maior)
        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }
}