using UnityEngine;

public class FusionCannonNeeds : MonoBehaviour
{
    public float fusionCannonCost = 1000f;
    public float fusionCannonPower = 625f;
    public int fusionCannonWorkers = 25;

    void Start()
    {
        ResourceManager.credits -= fusionCannonCost;
        ResourceManager.workers += fusionCannonWorkers;
        ResourceManager.powerUsage += fusionCannonPower;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= fusionCannonWorkers;
        ResourceManager.powerUsage -= fusionCannonPower;
        ResourceManager.UpdateResources();
    }
}
