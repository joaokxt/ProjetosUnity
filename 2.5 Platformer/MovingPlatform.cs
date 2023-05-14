using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB;
    private float _speed = 2.5f;
    private bool _ready = false;
    [SerializeField]
    private GameObject _player;

    void Start()
    {
        transform.position = _targetA.position;
    }
    void FixedUpdate()
    {
        if(_ready == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);
        }
        else if(_ready == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);
        }

        if(transform.position == _targetA.position)
        {
            _ready = false;
        }
        else if(transform.position == _targetB.position)
        {
            _ready = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _player.transform.parent = this.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            _player.transform.parent = null;
        }
    }
}
