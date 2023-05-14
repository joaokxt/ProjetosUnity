
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 8.0f;
    [SerializeField]
    private float _gravity = 0.75f;
    [SerializeField]
    private float _jumpHeight = 25.0f;
    private float _yVelocity;
    private bool _doubleJump = false;
    [SerializeField]
    private int _coins;
    private int _lives = 3;

    private UIManager _ui;

    void Start()
    {
        _controller = GetComponent<CharacterController>();

        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(_ui == null)
        {
            Debug.Log("NULL Ui Manager!");
        }

        _ui.UpdateLives(_lives);   
    }

    void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0f, 0f);
        Vector3 velocity = direction * _speed;

        if (_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _doubleJump = true;
            }
        }
        else
        {
            if (_doubleJump == true && Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity += _jumpHeight + 5f;
                _doubleJump = false;
            }
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;

        _controller.Move(velocity * Time.deltaTime);
    }

    public void AddCoins()
    {
        _coins++;
        _ui.UpdateCoins(_coins);
    }

    public void Damage()
    {
        _lives--;
        _ui.UpdateLives(_lives);

        if(_lives < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
