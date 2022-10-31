using UnityEngine;
using System.Collections;

public class BallistaVXSpawnEffect : SpawnEffect
{
    public GameObject ballistaVXPrefab;

    void Start()
    {
        productionTime = ballistaVXPrefab.GetComponent<BallistaVXCost>().ballistaVXProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
