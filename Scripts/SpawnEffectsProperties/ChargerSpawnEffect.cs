using UnityEngine;
using System.Collections;

public class ChargerSpawnEffect : SpawnEffect
{
    public GameObject chargerPrefab;

    void Start()
    {
        productionTime = chargerPrefab.GetComponent<ChargerCost>().chargerProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
