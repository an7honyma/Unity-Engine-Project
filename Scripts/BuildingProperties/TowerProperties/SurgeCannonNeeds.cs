using UnityEngine;

public class SurgeCannonNeeds : MonoBehaviour
{
    public float surgeCannonCost = 1800f;
    public float surgeCannonPower = 1125f;
    public int surgeCannonWorkers = 45;

    void Start()
    {
        ResourceManager.credits -= surgeCannonCost;
        ResourceManager.workers += surgeCannonWorkers;
        ResourceManager.powerUsage += surgeCannonPower;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= surgeCannonWorkers;
        ResourceManager.powerUsage -= surgeCannonPower;
        ResourceManager.UpdateResources();
    }
}
