using UnityEngine;

public class RailCannonNeeds : MonoBehaviour
{
    public float railCannonCost = 600f;
    public float railCannonPower = 375f;
    public int railCannonWorkers = 15;

    void Start()
    {
        ResourceManager.credits -= railCannonCost;
        ResourceManager.workers += railCannonWorkers;
        ResourceManager.powerUsage += railCannonPower;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= railCannonWorkers;
        ResourceManager.powerUsage -= railCannonPower;
        ResourceManager.UpdateResources();
    }
}
