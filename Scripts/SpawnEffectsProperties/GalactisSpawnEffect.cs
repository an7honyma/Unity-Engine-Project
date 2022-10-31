using UnityEngine;
using System.Collections;

public class GalactisSpawnEffect : SpawnEffect
{
    public GameObject galactisPrefab;

    void Start()
    {
        productionTime = galactisPrefab.GetComponent<GalactisCost>().galactisProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
