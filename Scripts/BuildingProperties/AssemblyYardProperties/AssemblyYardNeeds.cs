using UnityEngine;

public class AssemblyYardNeeds : MonoBehaviour
{
    public float assemblyYardCost = 3000f;
    public float assemblyYardPower = 500f;
    public int assemblyYardWorkers = 75;

    void Start()
    {
        ResourceManager.credits -= assemblyYardCost;
        ResourceManager.workers += assemblyYardWorkers;
        ResourceManager.powerUsage += assemblyYardPower;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= assemblyYardWorkers;
        ResourceManager.powerUsage -= assemblyYardPower;
        ResourceManager.UpdateResources();
    }
}
