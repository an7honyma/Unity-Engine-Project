using UnityEngine;

public class PowerPlantNeeds : MonoBehaviour
{
    public float powerPlantCost = 1000f;
    public int powerPlantWorkers = 15;

    void Start()
    {
        ResourceManager.credits -= powerPlantCost;
        ResourceManager.workers += powerPlantWorkers;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= powerPlantWorkers;
        ResourceManager.UpdateResources();
    }
}
