using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spell
{
    public string name;
    public int lvlRequired;
    public int itemRequiredId;
    public int expGained;

    public Spell(string name, int lvl, int ID, int expGained)
    {
        this.name = name;
        this.lvlRequired = lvl;
        this.itemRequiredId = ID;
        this.expGained = expGained;
    }

    public void Cast()
    {
        Debug.Log("Casting: " + this.name);
    }




}
