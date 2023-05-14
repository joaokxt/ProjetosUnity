using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta classe poderia estar em outro script se eu bem quiesesse.
[System.Serializable]
public class WeaponStats
{
    public string name;
    public int ammo;
    public float fireRate;
    public Sprite icon;

    //Isto é um construtor
    public WeaponStats(string name, int ammo, float fireRate)
    {
        this.name = name;
        this.ammo = ammo;
        this.fireRate = fireRate;
    }
}

public class Classes : MonoBehaviour
{
    private WeaponStats pistola;
    private WeaponStats metralhadora;
    private WeaponStats tomahawk;

    //ou

    //public WeaponStats[] armas;

    void Start()
    {
        pistola = new WeaponStats("USP", 16, 0.5f);

        metralhadora = new WeaponStats("M4A1-S", 30, 6.0f);

        //ou

        tomahawk = CreateWeapon("Machado de arremeso", 1, 0.01f);

        //ou

        /*
        WeaponStats[0].name;
        WeaponStats[0].ammo;
        */

        //etc.


        Debug.Log($"Arma atual: {pistola.name}");
    }

    
    void Update()
    {
        
    }

    private WeaponStats CreateWeapon(string name, int ammo, float fireRate)
    {
        var weapon = new WeaponStats(name, ammo, fireRate);

        return weapon;
    }
}
