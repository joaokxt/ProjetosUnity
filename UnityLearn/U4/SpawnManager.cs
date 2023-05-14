using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnX;
    private float spawnZ;
    private float spawnRange;
    private Vector3 randomPos;

    private int spawnIndexR;
    private int spawnIndex;
    private int i;

    private int enemyCount;
    private int waveNumber;

    void Start()
    {
        spawnRange = 10f;
        waveNumber = 1;
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount==0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        if (waveNumber == 1)
        {
            for (i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(enemyPrefab[0], GeneratePosition(), enemyPrefab[0].transform.rotation);
            }
        }
        else
        {
            for (i = 0; i < enemiesToSpawn; i++)
            {
                spawnIndexR = Random.Range(1, 10);
                if (spawnIndexR < 8)
                {
                    spawnIndex = 0;
                }
                else
                {
                    spawnIndex = 1;
                }
                Instantiate(enemyPrefab[spawnIndex], GeneratePosition(), enemyPrefab[spawnIndex].transform.rotation);
            }
        }
    }

    private void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GeneratePosition(), powerupPrefab.transform.rotation);
    }

    private Vector3 GeneratePosition()
    {
        spawnX = Random.Range(-spawnRange, spawnRange);
        spawnZ = Random.Range(-spawnRange, spawnRange);
        randomPos = new Vector3(spawnX, 0, spawnZ);
        return randomPos;
    }
}
