using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGateSpawning : MonoBehaviour
{
    public Transform spawnOrigin;
    public int spawnInterval;
    public GameObject enemyPrefab;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnOrigin.position, Quaternion.identity);
    }
}
