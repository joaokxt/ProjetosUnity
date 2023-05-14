using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bank
{
    public string bankName;
    public string location;
    public int cashInVault;

    public void CashBalance()
    {
        Debug.Log("Checking balance at: " + this.bankName);
    }

    public void CashWithdrawal()
    {
        Debug.Log("Withdrawing money from: " + this.bankName);
    }

    public void CashDeposit()
    {
        Debug.Log("Depositing money to: " + this.bankName);
    }

}
