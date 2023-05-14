using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject[] _powerups;

    private bool _isPlayerDead = false;

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(2.0f);

        while (_isPlayerDead == false)
        {
            GameObject newEnemy = Instantiate(_enemyPrefab, new Vector3(UnityEngine.Random.Range(-12.0f, 12.0f), 7f, 0f), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        yield return new WaitForSeconds(2.0f);

        while(_isPlayerDead == false)
        {
            float spawnTime = UnityEngine.Random.Range(7.0f, 12.0f);
            int randomPowerup = UnityEngine.Random.Range(0, _powerups.Length);
            Instantiate(_powerups[randomPowerup], new Vector3(UnityEngine.Random.Range(-13.0f, 13.0f), 9.5f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public void OnPlayerDeath()
    {
        _isPlayerDead = true;
    }
}
