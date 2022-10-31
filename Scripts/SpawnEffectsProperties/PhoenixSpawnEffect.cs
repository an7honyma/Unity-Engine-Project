using UnityEngine;
using System.Collections;

public class PhoenixSpawnEffect : SpawnEffect
{
    public GameObject phoenixPrefab;

    void Start()
    {
        productionTime = phoenixPrefab.GetComponent<PhoenixCost>().phoenixProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
