using UnityEngine;
using System.Collections;

public class CallistoDroidSpawnEffect : SpawnEffect
{
    public GameObject callistoDroidPrefab;

    void Start()
    {
        productionTime = callistoDroidPrefab.GetComponent<CallistoDroidCost>().callistoDroidProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
