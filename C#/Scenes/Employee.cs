using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Employee : MonoBehaviour
{
    public string employeeName;
    public static string companyName;

    public abstract void CalculateSalary();
}
