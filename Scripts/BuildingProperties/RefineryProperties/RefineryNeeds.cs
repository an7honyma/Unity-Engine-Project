using UnityEngine;

public class RefineryNeeds : MonoBehaviour
{
    public float refineryCost = 2500f;
    public float refineryPower = 500f;
    public int refineryWorkers = 25;

    void Start()
    {
        ResourceManager.credits -= refineryCost;
        ResourceManager.workers += refineryWorkers;
        ResourceManager.powerUsage += refineryPower;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= refineryWorkers;
        ResourceManager.powerUsage -= refineryPower;
        ResourceManager.UpdateResources();
    }
}
