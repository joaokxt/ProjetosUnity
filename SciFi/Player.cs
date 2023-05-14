using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float _speed = 3.5f;
    private float _gravity = 9.8f;
    private float _jump = 2.0f;
    private float _yVelocity;
    [SerializeField]
    private int _coins = 0;

    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private GameObject _hitMarker;

    private AudioSource _audioSrc;
    [SerializeField]
    private AudioClip _somTiro;
    [SerializeField]
    private UIManager _ui;

    [SerializeField]
    private int _currentAmmo;
    private int _maxAmmo = 50;

    private float _fireRate = 0.1f;
    private float _canFire = 0f;

    private bool _isReloading;


    void Start()
    {
        _controller = GetComponent<CharacterController>();
        if(_controller == null)
        {
            Debug.Log("NULL CONTROLLER::PLAYER");
        }

        _audioSrc = GetComponent<AudioSource>();
        if (_audioSrc == null)
        {
            Debug.Log("NULL AUDIO::PLAYER");
        }
        else
        {
            _audioSrc.clip = _somTiro;
        }

        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_ui == null)
        {
            Debug.Log("NULL UI::PLAYER");
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _muzzleFlash.SetActive(false);
        _currentAmmo = _maxAmmo;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && _currentAmmo > 0 && _isReloading == false)
        {
            if (Time.time > _canFire)
            {
                Shoot();
                _canFire = Time.time + _fireRate;
            }
        }
        else
        {
            _muzzleFlash.SetActive(false);
        }


        //AUDIO
        if (Input.GetMouseButtonDown(0) && _currentAmmo > 0)
        {
            _audioSrc.Play();
        }
        if (Input.GetMouseButtonUp(0) || _currentAmmo == 0 || _isReloading == true)
        {
            _audioSrc.Stop();
        }

        if (Input.GetKeyDown(KeyCode.R) && _isReloading == false)
        {
            _isReloading = true;
            StartCoroutine(Reload());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }


        CalculateMovement();

        _ui.UpdateAmmo(_currentAmmo);
    }

    void Shoot()
    {
        //Definir o ponto de surgimento do RayCast
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        //Todas as informações sobre colisões serão armazenadas em hitInfo

        RaycastHit hitInfo;
        _muzzleFlash.SetActive(true);
        _currentAmmo--;
   
        //Gerar o raio e checar colisões
        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            //É possível acessar todas as informações dos corpos que colidem com o raio pela variável hitInfo
            Debug.Log("Acerto!" + hitInfo.transform.name);

            GameObject hitMarker = Instantiate(_hitMarker, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(hitMarker, 1f);
        }

    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.5f);
        _currentAmmo = _maxAmmo;
        _isReloading = false;
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        if(_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jump;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _speed = _speed * 2;
        }

        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            _speed = 3.5f;
        }

        _yVelocity -= _gravity * Time.deltaTime;
        Vector3 direction = new Vector3(horizontalInput, _yVelocity, verticalInput);
        Vector3 velocity = direction * _speed;
        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }

    public void AddCoins()
    {
       _coins++;
    }

    public void RemoveCoins(int amount)
    {
        _coins -= amount;
    }

}
