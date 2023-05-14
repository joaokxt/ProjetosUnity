using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    private Player _player;
    private Animator _eAnimator;

    private AudioSource _audioSrc;
    [SerializeField]
    private AudioClip _explosionSound;

    [SerializeField]
    private GameObject _laserPrefab;
    private float _fireRate = 3.0f;
    private float _canFire = -1.0f;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

        _eAnimator = gameObject.GetComponent<Animator>();
        if(_eAnimator == null)
        {
            Debug.Log("NULL ERROR::ENEMY");
        }

        _audioSrc = GetComponent<AudioSource>();
        if(_audioSrc == null)
        {
            Debug.Log("NUll AudioSource::Enemy");
        }
        else
        {
            _audioSrc.clip = _explosionSound;
        }
    }

    void Update()
    {
        CalculateMovement();

        if(Time.time > _canFire)
        {
            _fireRate = UnityEngine.Random.Range(3f, 7f);
            _canFire = Time.time + _fireRate;
            GameObject enemyLaser = Instantiate(_laserPrefab, transform.position + new Vector3(0f, -1.5f, 0f), Quaternion.identity);
            LaserBehaviour[] lasers = enemyLaser.GetComponentsInChildren<LaserBehaviour>();
            
            for(int i = 0; i < lasers.Length; i++)
            {
                lasers[i].AssignEnemy();
            }
        }
    }

    void CalculateMovement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -9.5f)
        {
            float newExPosition = UnityEngine.Random.Range(-13.0f, 13.0f);
            transform.position = new Vector3(newExPosition, 9.5f, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.tag == "Player")
        {
            PlayerCollision(other);
        }

        if (other.tag == "Laser")
        {
            LaserBehaviour laser = other.GetComponent<LaserBehaviour>();
            if (laser.EnemyCheck() == false)
            {
                LaserCollision(other);
            }    
        }
    }

    void PlayerCollision(Collider2D other)
    {
        if (_player != null)
        {
            _player.Damage();
        }

        _eAnimator.SetTrigger("OnEnemyDeath");
        _speed = 0;
        _audioSrc.Play();

        Destroy(this.gameObject, 2.5f);
    }

    void LaserCollision(Collider2D other)
    {
        Destroy(other.gameObject);
        _player.AddScore(10);

        _eAnimator.SetTrigger("OnEnemyDeath");
        _speed = 0;
        _audioSrc.Play();

        Destroy(GetComponent<Collider2D>());

        Destroy(this.gameObject, 2.5f);
    }

}
