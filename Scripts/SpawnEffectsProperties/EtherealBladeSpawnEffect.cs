using UnityEngine;
using System.Collections;

public class EtherealBladeSpawnEffect : SpawnEffect
{
    public GameObject etherealBladePrefab;

    void Start()
    {
        productionTime = etherealBladePrefab.GetComponent<EtherealBladeCost>().etherealBladeProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
