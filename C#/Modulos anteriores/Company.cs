using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Empregados
{
    public string name;
    public int age;
    public string profession;

    public static string company;

    public Empregados()
    {
        Debug.Log("INSTANCE");
    }

    static Empregados()
    {
        company = "Sony";
        Debug.Log("STATIC");
    }

}

public class Company : MonoBehaviour
{
    
    void Start()
    {
        var e1 = new Empregados();
        var e2 = new Empregados();
        var e3 = new Empregados();

        //INSTANCE será executado tres vezes, mas STATIC somente uma
    }

    
    void Update()
    {
        
    }
}
