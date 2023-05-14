using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public int health;
    public int movementSpeed;
    private Rigidbody playerRb;
    public float gravityModifier;
    private Vector3 jumpSpeed;

    void Start()
    {
        health = 5;
        movementSpeed = 1;
        jumpSpeed = new Vector3(0,5,0);
        Physics.gravity *= gravityModifier;
        playerRb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(5, 0, 0) * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-5, 0, 0) * movementSpeed * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(jumpSpeed, ForceMode.Impulse);
        }
    }
}
