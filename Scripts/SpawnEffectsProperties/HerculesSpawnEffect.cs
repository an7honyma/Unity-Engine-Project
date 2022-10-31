using UnityEngine;
using System.Collections;

public class HerculesSpawnEffect : SpawnEffect
{
    public GameObject herculesPrefab;

    void Start()
    {
        productionTime = herculesPrefab.GetComponent<HerculesCost>().herculesProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
