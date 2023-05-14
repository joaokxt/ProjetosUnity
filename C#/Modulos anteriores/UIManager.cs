using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text activeEnemiesText;

    public void UpdateEnemyText()
    {
        activeEnemiesText.text = "Active Enemies: " + EnemySpawner.enemyCount;
    }





    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
