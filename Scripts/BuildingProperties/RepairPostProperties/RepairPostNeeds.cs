using UnityEngine;

public class RepairPostNeeds : MonoBehaviour
{
    public float repairPostCost = 2000f;
    public float repairPostPower = 50f;
    public int repairPostWorkers = 15;

    void Start()
    {
        ResourceManager.credits -= repairPostCost;
        ResourceManager.workers += repairPostWorkers;
        ResourceManager.powerUsage += repairPostPower;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= repairPostWorkers;
        ResourceManager.powerUsage -= repairPostPower;
        ResourceManager.UpdateResources();
    }
}
