using UnityEngine;
using System.Collections;

public class PhotonTankSpawnEffect : SpawnEffect
{
    public GameObject photonTankPrefab;

    void Start()
    {
        productionTime = photonTankPrefab.GetComponent<PhotonTankCost>().photonTankProductionTime;
        StartCoroutine(StopEffect());
        Destroy(gameObject, (productionTime + 2f));
    }
}
