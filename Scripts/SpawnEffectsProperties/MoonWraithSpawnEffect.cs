using UnityEngine;
using System.Collections;

public class MoonWraithSpawnEffect : SpawnEffect
{
    public GameObject moonWraithPrefab;

    void Start()
    {
        productionTime = moonWraithPrefab.GetComponent<MoonWraithCost>().moonWraithProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
