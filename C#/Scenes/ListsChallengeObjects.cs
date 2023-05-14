using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class ListsChallengeObjects : MonoBehaviour
{
    public GameObject[] coisas = new GameObject[3];
    public List<GameObject> vivos = new List<GameObject>();
    public int SpawnCount { get; set; }
    private bool _initColorChange;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(SpawnCount == 10)
            {
                _initColorChange = true;
                return;
            }

            /*int i = UnityEngine.Random.Range(0, coisas.Length);
            var position = new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10), 0);
            Instantiate(coisas[i], position, Quaternion.identity);
            vivos.Add(coisas[i]);
            SpawnCount++;*/
            // ou: 
            var objectToSpawn = coisas[UnityEngine.Random.Range(0, coisas.Length)];
            int x = UnityEngine.Random.Range(-10,10);
            int y = UnityEngine.Random.Range(-10,10);
            var pos = new Vector3(x, y, 0);
            var go = Instantiate(objectToSpawn, pos, Quaternion.identity);
            vivos.Add(go);
            SpawnCount++;
        }

        if(_initColorChange == true)
        {
            _initColorChange = false;

            foreach(var cubo in vivos)
            {
                cubo.GetComponent<MeshRenderer>().material.color = Color.green;
            }

            vivos.Clear();
        }

        
    }
}
