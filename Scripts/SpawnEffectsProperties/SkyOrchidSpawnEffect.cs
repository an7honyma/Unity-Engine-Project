using UnityEngine;
using System.Collections;

public class SkyOrchidSpawnEffect : SpawnEffect
{
    public GameObject skyOrchidPrefab;

    void Start()
    {
        productionTime = skyOrchidPrefab.GetComponent<SkyOrchidCost>().skyOrchidProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
