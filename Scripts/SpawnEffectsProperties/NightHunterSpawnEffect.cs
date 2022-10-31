using UnityEngine;
using System.Collections;

public class NightHunterSpawnEffect : SpawnEffect
{
    public GameObject nightHunterPrefab;

    void Start()
    {
        productionTime = nightHunterPrefab.GetComponent<NightHunterCost>().nightHunterProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
