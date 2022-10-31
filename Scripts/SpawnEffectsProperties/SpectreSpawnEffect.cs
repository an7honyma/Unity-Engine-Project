using UnityEngine;
using System.Collections;

public class SpectreSpawnEffect : SpawnEffect
{
    public GameObject spectrePrefab;

    void Start()
    {
        productionTime = spectrePrefab.GetComponent<SpectreCost>().spectreProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
