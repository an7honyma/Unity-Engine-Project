using UnityEngine;
using System.Collections;

public class HydraSpawnEffect : SpawnEffect
{
    public GameObject hydraPrefab;

    void Start()
    {
        productionTime = hydraPrefab.GetComponent<HydraCost>().hydraProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
