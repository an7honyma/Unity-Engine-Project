using UnityEngine;
using System.Collections;

public class AbyssRaySpawnEffect : SpawnEffect
{
    public GameObject abyssRayPrefab;

    void Start()
    {
        productionTime = abyssRayPrefab.GetComponent<AbyssRayCost>().abyssRayProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
