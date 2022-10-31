using UnityEngine;
using System.Collections;

public class StarWardenSpawnEffect : SpawnEffect
{
    public GameObject starWardenPrefab;

    void Start()
    {
        productionTime = starWardenPrefab.GetComponent<StarWardenCost>().starWardenProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
