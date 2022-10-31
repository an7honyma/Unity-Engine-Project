using UnityEngine;
using System.Collections;

public class DecimatorSpawnEffect : SpawnEffect
{
    public GameObject decimatorPrefab;

    void Start()
    {
        productionTime = decimatorPrefab.GetComponent<DecimatorCost>().decimatorProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
