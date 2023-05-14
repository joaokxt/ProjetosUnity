using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private UIManager _ui;

    public void OnEnable()
    {
        EnemySpawner.enemyCount++;
        _ui = GameObject.Find("UI_Manager").GetComponent<UIManager>();
        _ui.UpdateEnemyText();
        Die();
    }

    public void OnDisable()
    {
        EnemySpawner.enemyCount--;
        _ui.UpdateEnemyText();
    }

    void Die()
    {
        Destroy(this.gameObject, UnityEngine.Random.Range(2, 6));
    }
}
