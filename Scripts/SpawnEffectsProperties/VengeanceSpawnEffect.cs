using UnityEngine;
using System.Collections;

public class VengeanceSpawnEffect : SpawnEffect
{
    public GameObject vengeancePrefab;

    void Start()
    {
        productionTime = vengeancePrefab.GetComponent<VengeanceCost>().vengeanceProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
