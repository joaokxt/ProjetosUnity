using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    [SerializeField]
    public List<Weapon> weapons;
    public List<Gadget> gadgets;

    private void Start()
    {
        weapons = new List<Weapon>()
        {
            //Pistolas:
            new Weapon("Clock-17", "Pistol", 17, 102, 17, 0.75f, 101, GameObject.Find("Glock"), false, 25, 0.75f, true),
            new Weapon("VSP-S", "Pistol", 15, 60, 15, 0.5f, 102, GameObject.Find("USP"), false, 30, 0.8f, false),
            new Weapon("Doble Verreta", "Pistol", 30, 120 ,30, 0.5f, 103, GameObject.Find("Duals"), false, 35, 0.75f, false),
            new Weapon("1912", "Pistol", 8, 64,8, 0.4f, 104, GameObject.Find("1911"), false, 30, 0.8f, false),
            new Weapon("Desert Ingol", "Pistol", 7, 35,7, 0.35f, 105, GameObject.Find("Deagle"), false, 50, 0.85f, false),

            //ARs
            new Weapon("FAMOS", "AR", 17, 102, 17, 0.75f, 201, GameObject.Find("Famas"), true, 25, 0.75f, false),
            new Weapon("AKK-47", "AR", 15, 60, 15, 0.5f, 202, GameObject.Find("Ak47"), true, 30, 0.8f, false),
            new Weapon("P50", "SMG", 30, 120 ,30, 0.5f, 203, GameObject.Find("P90"), true, 35, 0.75f, false),
            new Weapon("MC-10", "SMG", 8, 64,8, 0.4f, 204, GameObject.Find("Mac10"), true, 30, 0.8f, false),
            new Weapon("M5", "SMG", 7, 35,7, 0.35f, 205, GameObject.Find("M4A1"), true, 50, 0.85f, false),

            //Pesados
            new Weapon("MAGA-7", "Shotgun", 17, 102, 17, 0.75f, 301, GameObject.Find("Mag7"), false, 25, 0.75f, false),
            new Weapon("X510", "Shotgun", 15, 60, 15, 0.5f, 302, GameObject.Find("X500"), false, 30, 0.8f, false),
            new Weapon("Negeb", "Machine Gun", 30, 120 ,30, 0.5f, 303, GameObject.Find("Negev"), true, 35, 0.75f, false),
            new Weapon("SSC-10", "Sniper", 8, 64,8, 0.4f, 304, GameObject.Find("SSG"), false, 30, 0.8f, true),
            new Weapon("ATP", "Sniper", 7, 35,7, 0.35f, 305, GameObject.Find("AWP"), false, 50, 0.85f, true),

        };

        gadgets = new List<Gadget>()
        {
            new Gadget("He Grenade", 80, 30, 401, GameObject.Find("HE")),
            new Gadget("Flash Grenade", 0, 50, 402, GameObject.Find("Flashbang")),
            new Gadget("Molotov", 20, 30, 403, GameObject.Find("Molotov")),
            new Gadget("Smoke Grenade", 0, 40, 404, GameObject.Find("Smoke")),
            new Gadget("Decoy Grenade", 0, 50, 405, GameObject.Find("Decoy")),
        };

    }
    public Weapon GetWeapon(int id)
    {
        return weapons.Find(weapon => weapon.weaponID == id);
    }

    public Gadget GetGadget(int id)
    {
        return gadgets.Find(gadget => gadget.weaponID == id);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        player.BuyZoneIn();
    }
    private void OnTriggerExit(Collider other)
    {
        Player player = other.GetComponent<Player>();
        player.BuyZoneOut();
    }
}
