using UnityEngine;
using System.Collections;

public class DarkNebulaSpawnEffect : SpawnEffect
{
    public GameObject darkNebulaPrefab;

    void Start()
    {
        productionTime = darkNebulaPrefab.GetComponent<DarkNebulaCost>().darkNebulaProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
