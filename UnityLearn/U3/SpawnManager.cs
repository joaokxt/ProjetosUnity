using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(40, 0, 0);
    private int randomIndex;
    private int startDelay = 2;
    private int repeatRate = 2;
    private PlayerController player;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if(player.isGameOver==true)
        {
            Destroy(this.gameObject);
        }
    }
    void SpawnObstacle()
    {
        randomIndex = Random.Range(0, 10);
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        float spawnDelay = Random.Range(0f, 1.5f);
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(obstaclePrefabs[randomIndex], spawnPos, transform.rotation);
        StopCoroutine(SpawnRoutine());
    }
}
