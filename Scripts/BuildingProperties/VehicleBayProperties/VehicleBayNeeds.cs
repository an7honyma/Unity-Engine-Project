using UnityEngine;

public class VehicleBayNeeds : MonoBehaviour
{
    public float vehicleBayCost = 2000f;
    public float vehicleBayPower = 250f;
    public int vehicleBayWorkers = 50;

    void Start()
    {
        ResourceManager.credits -= vehicleBayCost;
        ResourceManager.workers += vehicleBayWorkers;
        ResourceManager.powerUsage += vehicleBayPower;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= vehicleBayWorkers;
        ResourceManager.powerUsage -= vehicleBayPower;
        ResourceManager.UpdateResources();
    }
}
