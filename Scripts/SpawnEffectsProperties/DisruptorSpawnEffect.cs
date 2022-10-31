using UnityEngine;
using System.Collections;

public class DisruptorSpawnEffect : SpawnEffect
{
    public GameObject disruptorPrefab;

    void Start()
    {
        productionTime = disruptorPrefab.GetComponent<DisruptorCost>().disruptorProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
