using UnityEngine;
using System.Collections;

public class RedOlympusSpawnEffect : SpawnEffect
{
    public GameObject redOlympusPrefab;

    void Start()
    {
        productionTime = redOlympusPrefab.GetComponent<RedOlympusCost>().redOlympusProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
