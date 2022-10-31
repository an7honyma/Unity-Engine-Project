using UnityEngine;
using System.Collections;

public class DragonheadSpawnEffect : SpawnEffect
{
    public GameObject dragonheadPrefab;

    void Start()
    {
        productionTime = dragonheadPrefab.GetComponent<DragonheadCost>().dragonheadProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
