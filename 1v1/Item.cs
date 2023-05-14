using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;
    public int weaponID;
    public int baseDamage;
    public int price;
    public GameObject model;
}

public class Weapon:Item
{  
    public string weaponType;
    public int magSize;
    public int bulletsLoaded;
    public int totalAmmo;
    public float fireRate;
    public float rangeReduction;
    public bool canAutomatic;
    public bool canChangeFireMode;
  
    public Weapon(string name, string weaponType, int magSize, int totalAmmo, int bulletsLoaded, float fireRate, int weaponID, GameObject model, bool canAutomatic, int baseDamage, float rangeReduction, bool canChangeFireMode/*, int price*/)
    {
        this.name = name;
        this.weaponType = weaponType;
        this.magSize = magSize;
        this.bulletsLoaded = bulletsLoaded;
        this.totalAmmo = totalAmmo;
        this.fireRate = fireRate;
        this.weaponID = weaponID;
        this.model = model;
        this.canAutomatic = canAutomatic;
        this.baseDamage = baseDamage;
        this.rangeReduction = rangeReduction;
        this.canChangeFireMode =canChangeFireMode;
        //this.price = price;
    }
}

public class Gadget:Item
{
    public int range;

    public Gadget(string name, int baseDamage, int range, int id, GameObject model/*, int price*/)
    {
        this.name = name;
        this.weaponID = id;
        this.baseDamage = baseDamage;
        this.range = range;
        this.model = model;
        //this.price = price;
    }
}
