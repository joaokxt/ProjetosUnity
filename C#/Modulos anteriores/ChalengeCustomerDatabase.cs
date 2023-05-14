using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChalengeCustomerDatabase : MonoBehaviour
{   
    
    public Customer Anna;
    
    public Customer Charles;
    
    public Customer Mary;

    public Customer[] customers;

    void Start()
    {
        Anna = new Customer("Anna", "De la Rosa", 25, "Female", "Engineer");
        Charles = new Customer("Charles", "LeClerc", 24, "Male", "Teacher");
        Mary = new Customer("Mary", "Frank", 28, "Female", "Shops assistant");
    }

    
    void Update()
    {
        
    }

    
}
