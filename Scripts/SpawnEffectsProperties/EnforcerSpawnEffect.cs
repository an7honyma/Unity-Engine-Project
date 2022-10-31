using UnityEngine;
using System.Collections;

public class EnforcerSpawnEffect : SpawnEffect
{
    public GameObject enforcerPrefab;

    void Start()
    {
        productionTime = enforcerPrefab.GetComponent<EnforcerCost>().enforcerProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
