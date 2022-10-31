using UnityEngine;
using System.Collections;

public class GuardianSpawnEffect : SpawnEffect
{
    public GameObject guardianPrefab;

    void Start()
    {
        productionTime = guardianPrefab.GetComponent<GuardianCost>().guardianProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
