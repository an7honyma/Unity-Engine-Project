using UnityEngine;
using System.Collections;

public class HyperionSpawnEffect : SpawnEffect
{
    public GameObject hyperionPrefab;

    void Start()
    {
        productionTime = hyperionPrefab.GetComponent<HyperionCost>().hyperionProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
