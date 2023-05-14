using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _score;
    [SerializeField]
    private int _lives = 3;

    [SerializeField]
    private float _speed = 5f;
    private float _speedMultiplier = 2f;
 
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;

    private float _fireRate = 0.25f;
    private float _canFire = -1f;

    private SpawnManager _spawnManager;
    private UIManager _ui;
    private GameManager _gameManager;
    private bool _tripleShot = false;
    private bool _shield = false;

    [SerializeField]
    private GameObject _shieldVisualizer;
    [SerializeField]
    private GameObject[] _engineVisualizers;
    private int _randomDamage;

    [SerializeField]
    private AudioClip _laserSoundClip;
    private AudioSource _audioSrc;

    void Start()
    {
        transform.position = new Vector3(0, -2, 0);

        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.Log("Couldn't find the Spawn Manager!! (Spawn_Manager is NULL)");
        }

        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(_ui == null)
        {
            Debug.Log("UI is NULL!");
        }

        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        if(_gameManager == null)
        {
            Debug.Log("NULL Error!");
        }

        _audioSrc = GetComponent<AudioSource>();
        if(_audioSrc == null)
        {
            Debug.Log("NULL Audio Source");
        }
        else
        {
            _audioSrc.clip = _laserSoundClip;
        }

    }

    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
            ShootingLaser();
    }

    void CalculateMovement()
    {
        if (_speed <= 0)
        {
            _speed = 0;
        }

        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalAxis, verticalAxis, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -6.0f, 6.0f), 0);

        if (transform.position.x >= 13.0f)
        {
            transform.position = new Vector3(-13.0f, transform.position.y, 0);
        }
        else if (transform.position.x <= -13.0f)
        {
            transform.position = new Vector3(13.0f, transform.position.y, 0);
        }
    }

    public void Damage()
    {
        if (_shield == true)
        {
            _shield = false;
            _shieldVisualizer.SetActive(false);
            return;
        }
        else
        {
            _lives--;
            _ui.UpdateLives(_lives);
        }

        switch(_lives)
        {
            case (2):
                _randomDamage = UnityEngine.Random.Range(0, 2);
                _engineVisualizers[_randomDamage].SetActive(true);
                break;
            case (1):
                int rest = 1 - _randomDamage;
                _engineVisualizers[rest].SetActive(true);
                break;
            case (0):
                Die();
                break;
        }
    }

    public void ShootingLaser()
    {
        _canFire = Time.time + _fireRate;

        if (_tripleShot == true)
        {
            Instantiate(_tripleShotPrefab, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
        }

        _audioSrc.Play();
    }

    public void TripleShotActivate()
    {
        _tripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);

        _tripleShot = false;
    }

    public void SpeedBoostActivate()
    {
        _speed *= _speedMultiplier;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }

    IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _speed /= _speedMultiplier;
    }

    public void ShieldActivate()
    {
        _shield = true;
        _shieldVisualizer.SetActive(true);
    }

    public void AddScore(int points)
    {
        _score += points;
        _ui.UpdateScore(_score);
    }

    public void Die()
    {
        _gameManager.GameOverRestart();
        _spawnManager.OnPlayerDeath();
        Destroy(this.gameObject);
    }
}
