using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _movementSpeed;
    [SerializeField]
    private float _jumpVelocity;
    [SerializeField]
    private float _gravity;
    private float _yVelocity;
    private CharacterController _controller;
    private float hInput;
    private float vInput;

    private int _currentAmmo;

    private bool _isSecondary;
    private bool _buyZoneActive;
    private bool _buying;
    private bool _pistolsActive;
    private bool _arActive;
    private bool _heavyActive;
    private bool _gadgetActive;

    private ItemDatabase _idb;
    private bool _isOnBuyZone;
    private Weapon _activePrimary;
    private Weapon _activeSecondary;
    private Weapon _holdingWeapon;

    private int _playerHealth;
    private int _vestLife;
    private bool _isReloading;

    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private GameObject _hitMarker;
    public float _canFire;

    private List<Gadget> _activeGrenades;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _movementSpeed = 5.0f;
        _jumpVelocity = 25.0f;
        _gravity = -1.5f;
        _isSecondary = false;
        _idb = GameObject.Find("ItemDatabase").GetComponent<ItemDatabase>();
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

    }

    void Update()
    {
        Movement();

        //Mecânica de Disparo, adicionar parâmetro de taxa de fogo

        //DIFERENCIAR ENTRE ARMAS DE DISPARO UNICO E AUTOMATICAS

        if(_holdingWeapon.canAutomatic == false && _currentAmmo > 0 && Input.GetMouseButtonDown(0))
        {
            if(Time.time > _canFire)
            {
                SingleShooting(_holdingWeapon);
                _canFire = Time.time + _holdingWeapon.fireRate;
            }
        }
        else if(_holdingWeapon.canAutomatic == true)
        {
            if (Input.GetMouseButton(0))
            {
                AutoShooting(_holdingWeapon);
            }
        }
        
        if(_holdingWeapon.canChangeFireMode == true && Input.GetMouseButtonDown(1))
        {
            AimOrChange();
        }

        if(Input.GetKeyDown(KeyCode.R) && _isReloading == false)
        {
            _isReloading = true;
            StartCoroutine(Reload());
        }

        //Menu de compra
        BuyMenu();
        GunInventoryStatus();
        ChangeGuns();
    }
    public void GunInventoryStatus()
    {
        if (_activePrimary == null)
        {
            _holdingWeapon = _activeSecondary;
            _isSecondary = true;
        }
        else
        {
            _holdingWeapon = _activePrimary;
            _isSecondary = false;
        }
    }

    private void Movement()
    {
        Vector3 direction = new Vector3(hInput, 0, vInput);
        Vector3 velocity = direction * _movementSpeed;

        if(_controller.isGrounded == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpVelocity;
            }
        }

        _yVelocity += _gravity;
 
        velocity.y = _yVelocity;
        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }

    void BuyMenu()
    {
        if (_isOnBuyZone == true && Input.GetKeyDown(KeyCode.B))
        {
            _buyZoneActive = true;
            _buying = true; 
        }

        if (_buying == true)
        {
            hInput = 0.0f;
            vInput = 0.0f;
        }

        if (_buyZoneActive == true)
        {
            //SetActive(BuyMenuUI)

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _pistolsActive = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _arActive = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _heavyActive = true;
            }
            if(Input.GetKeyDown(KeyCode.Alpha4))
            {
                _gadgetActive = true;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //SetActiveFalse(BuyMenuUI)
                _buyZoneActive = false;
                hInput = Input.GetAxis("Horizontal");
                vInput = Input.GetAxis("Vertical");
            }
        }

        if (_pistolsActive == true)
        {
            PistolBuy();
        }
        if (_arActive == true)
        {
            ARifleBuy();
        }
        if (_heavyActive == true)
        {
            HeavyBuy();
        }
        if(_gadgetActive == true)
        {
            GadgetBuy();
        }
    }

    void PistolBuy()
    {
        //SetActiveFalse(BuyMenuUI)
        //SetActive(PistolsUI)
        _buyZoneActive = false;

        var input = Input.inputString;
        switch (input)
        {
            case "q":
                _activeSecondary = _idb.GetWeapon(101);
                //SetActiveFalse(PistolsUI)
                //SetActive(BuyMenuUI)
                _buyZoneActive = true;
                _pistolsActive = false;
                break;
            case "w":
                _activeSecondary = _idb.GetWeapon(102);
                //SetActiveFalse(PistolsUI)
                //SetActive(BuyMenuUI)
                _buyZoneActive = true;
                _pistolsActive = false;
                break;
            case "e":
                _activeSecondary = _idb.GetWeapon(103);
                //SetActiveFalse(PistolsUI)
                //SetActive(BuyMenuUI)
                _buyZoneActive = true;
                _pistolsActive = false;
                break;
            case "r":
                _activeSecondary = _idb.GetWeapon(104);
                //SetActiveFalse(PistolsUI)
                //SetActive(BuyMenuUI)
                _buyZoneActive = true;
                _pistolsActive = false;
                break;
            case "t":
                _activeSecondary = _idb.GetWeapon(105);
                //SetActiveFalse(PistolsUI)
                //SetActive(BuyMenuUI)
                _buyZoneActive = true;
                _pistolsActive = false;
                break;
        }

        input = null;
    }

    void ARifleBuy()
    {
        //SetActiveFalse(BuyMenuUI)
        //SetActive(ARsUI)
        _buyZoneActive = false;

        var input = Input.inputString;
        switch (input)
        {
            case "q":
                _activePrimary = _idb.GetWeapon(201);
                //SetActiveFalse(ARsUI)
                //SetActive(BuyMenuUI)
                _buyZoneActive = true;
                _arActive = false;
                break;
            case "w":
                _activePrimary = _idb.GetWeapon(202);
                //SetActiveFalse(ARsUI)
                //SetActive(BuyMenuUI)
                _buyZoneActive = true;
                _arActive = false;
                break;
            case "e":
                _activePrimary = _idb.GetWeapon(203);
                //SetActiveFalse(ARsUI)
                //SetActive(BuyMenuUI)
                _buyZoneActive = true;
                _arActive = false;
                break;
            case "r":
                _activePrimary = _idb.GetWeapon(204);
                //SetActiveFalse(ARsUI)
                //SetActive(BuyMenuUI)
                _buyZoneActive = true;
                _arActive = false;
                break;
            case "t":
                _activePrimary = _idb.GetWeapon(205);
                //SetActiveFalse(ARsUI)
                //SetActive(BuyMenuUI)
                _buyZoneActive = true;
                _arActive = false;
                break;
        }

        input = null;
    }

    void HeavyBuy()
    {
        //SetActiveFalse(BuyMenuUI)
        //SetActive(HeavyUI)
        _buyZoneActive = false;

        var input = Input.inputString;
        switch (input)
        {
            case "q":
                _activePrimary = _idb.GetWeapon(301);
                //SetActiveFalse(HeavyUI)
                //SetActive(BuyMenuUI)
                _buyZoneActive = true;
                _heavyActive = false;
                break;
            case "w":
                _activePrimary = _idb.GetWeapon(302);
                //SetActiveFalse(HeavyUI)
                //SetActive(BuyMenuUI)
                _buyZoneActive = true;
                _heavyActive = false;
                break;
            case "e":
                _activePrimary = _idb.GetWeapon(303);
                //SetActiveFalse(HeavyUI)
                //SetActive(BuyMenuUI)
                _buyZoneActive = true;
                _heavyActive = false;
                break;
            case "r":
                _activePrimary = _idb.GetWeapon(304);
                //SetActiveFalse(HeavyUI)
                //SetActive(BuyMenuUI)
                _buyZoneActive = true;
                _heavyActive = false;
                break;
            case "t":
                _activePrimary = _idb.GetWeapon(305);
                //SetActiveFalse(HeavyUI)
                //SetActive(BuyMenuUI)
                _buyZoneActive = true;
                _heavyActive = false;
                break;
        }

        input = null;
    }

    void GadgetBuy()
    {
        //SetActiveFalse(BuyMenuUI)
        //SetActive(GadgetsUI)
        _buyZoneActive = false;

        var input = Input.inputString;
        switch (input)
        {
            case "q":
                _activeGrenades.Add(_idb.GetGadget(401));
                //SetActiveFalse(GagdetsUI)
                //SetActive(BuyMenuUI)
                _buyZoneActive = true;
                _gadgetActive = false;
                break;
            case "w":
                _activeGrenades.Add(_idb.GetGadget(401));
                //SetActiveFalse(GadgetsUI)
                //SetActive(BuyMenuUI)
                _buyZoneActive = true;
                _gadgetActive = false;
                break;
            case "e":
                _activeGrenades.Add(_idb.GetGadget(401));
                //SetActiveFalse(GagdetsUI)
                //SetActive(BuyMenuUI)
                _buyZoneActive = true;
                _gadgetActive = false;
                break;
            case "r":
                _activeGrenades.Add(_idb.GetGadget(401));
                //SetActiveFalse(GagdetsUI)
                //SetActive(BuyMenuUI)
                _buyZoneActive = true;
                _gadgetActive = false;
                break;
            case "t":
                _vestLife = 75;
                _buyZoneActive = true;
                _gadgetActive = false;
                break;
        }

        input = null;
    }

    void SingleShooting(Weapon holding)
    {
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hitInfo;
        //_muzzleflash / animação
        holding.bulletsLoaded--;
        _currentAmmo = holding.bulletsLoaded;
        
        if(Physics.Raycast(rayOrigin, out hitInfo))
        {
            if(hitInfo.transform.tag == "Player")
            {
                Player player = hitInfo.transform.GetComponent<Player>();
                player.Health(holding.baseDamage);
            }

            GameObject hitMarker = Instantiate(_hitMarker, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(hitMarker, 1f);
        }
    }

    void AutoShooting(Weapon holding)
    {
        //tentar for while

        if(holding.bulletsLoaded > 0)
        {
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hitInfo;
            //_muzzleflash
            //animação
            holding.bulletsLoaded--;
            _currentAmmo = holding.bulletsLoaded;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                if (hitInfo.transform.tag == "Player")
                {
                    Player player = hitInfo.transform.GetComponent<Player>();
                    player.Health(holding.baseDamage);
                }

                GameObject hitMarker = Instantiate(_hitMarker, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(hitMarker, 1f);
            }
        }
    }

    private void ChangeGuns()
    {
        if(_isSecondary == false && Input.GetKeyDown(KeyCode.Alpha2))
        {
            _holdingWeapon = _activeSecondary;
            _isSecondary = true;
            Instantiate(_holdingWeapon.model);
            //_activePrimary SetActiveFalse
            //modificar interface
        }
        
        if(_isSecondary == true && Input.GetKeyDown(KeyCode.Alpha1))
        {
            _holdingWeapon = _activePrimary;
            _isSecondary = false;
            Instantiate(_holdingWeapon.model);
            //_activeSecondary SetActiveFalse
            //modificar interface
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            _holdingWeapon = null;
            _isSecondary = false;
            _movementSpeed *= 0.25f;
        }
    }

    void AimOrChange()
    {
        
    }
    
    void Health(int damage)
    {
        if(_vestLife > 0)
        {
            if(damage > _vestLife)
            {
                damage -= _vestLife;
                _vestLife = 0;
                _playerHealth -= damage;
            }
            else if(_vestLife > damage)
            {
                _vestLife -= damage;
            }
        }
        else
        {
            _playerHealth -= damage;
        }

        if(_playerHealth == 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(_activePrimary.model);
        Instantiate(_activeSecondary.model);
        Destroy(this);
    }


    public void BuyZoneIn()
    {
        _isOnBuyZone = true;
    }

    public void BuyZoneOut()
    {
        _isOnBuyZone = false;
    }

    IEnumerator Reload()
    {
        //INVENTAR O PARÂMETRO RELOAD TIME
        yield return new WaitForSeconds(1.5f);

        int toReload = _holdingWeapon.magSize - _holdingWeapon.bulletsLoaded;
        if(toReload < _holdingWeapon.totalAmmo)
        {
            _holdingWeapon.bulletsLoaded += toReload;
            _holdingWeapon.totalAmmo -= toReload;
        }
        else
        {
            _holdingWeapon.bulletsLoaded += _holdingWeapon.totalAmmo;
        }
        _isReloading = false;

        //Animação
    }

}
