using UnityEngine;
using System.Collections;

public class DeceptorSpawnEffect : SpawnEffect
{
    public GameObject deceptorPrefab;

    void Start()
    {
        productionTime = deceptorPrefab.GetComponent<DeceptorCost>().deceptorProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
