using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FireSpawner : MonoBehaviour
{
    private int spawnCount;
    private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] GameObject firePrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Random.InitState((DateTime.Now.ToString("hh:mm:ss")).GetHashCode());
        GetPoints();
        SpawnFire();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnFire()
    {
        int fireCount = UnityEngine.Random.Range(1, spawnCount);
        IndicatorsController indicators = GameObject.Find("Indicators").GetComponentInChildren<IndicatorsController>();
        indicators.fireStart = fireCount;
        for (int i = 0; i < fireCount; i++)
        {
            bool isDone = false;
            while (!isDone)
            {
                int randomChild = UnityEngine.Random.Range(0, spawnCount - 1);
                GameObject point = transform.GetChild(randomChild).gameObject;
                if (!point.activeSelf)
                {
                    point.SetActive(true);
                    Instantiate(firePrefab, point.transform.position, point.transform.rotation, point.transform);
                    isDone = true;
                }
            }
        }
    }

    void GetPoints()
    {
        spawnCount = transform.childCount;
        for (int i = 0; i < spawnCount; i++)
        {
            Transform child = transform.GetChild(i);
            spawnPoints.Add(child);
            child.gameObject.SetActive(false);
        }
    }
}
