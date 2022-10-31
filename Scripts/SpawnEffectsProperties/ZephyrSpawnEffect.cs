using UnityEngine;
using System.Collections;

public class ZephyrSpawnEffect : SpawnEffect
{
    public GameObject zephyrPrefab;

    void Start()
    {
        productionTime = zephyrPrefab.GetComponent<ZephyrCost>().zephyrProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
