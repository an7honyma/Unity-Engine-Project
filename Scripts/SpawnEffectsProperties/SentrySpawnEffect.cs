using UnityEngine;
using System.Collections;

public class SentrySpawnEffect : SpawnEffect
{
    public GameObject sentryPrefab;

    void Start()
    {
        productionTime = sentryPrefab.GetComponent<SentryCost>().sentryProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
