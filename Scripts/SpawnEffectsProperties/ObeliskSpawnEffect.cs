using UnityEngine;
using System.Collections;

public class ObeliskSpawnEffect : SpawnEffect
{
    public GameObject obeliskPrefab;

    void Start()
    {
        productionTime = obeliskPrefab.GetComponent<ObeliskCost>().obeliskProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
