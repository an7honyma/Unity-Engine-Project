using UnityEngine;
using System.Collections;

public class RangerSpawnEffect : SpawnEffect
{
    public GameObject rangerPrefab;

    void Start()
    {
        productionTime = rangerPrefab.GetComponent<RangerCost>().rangerProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
