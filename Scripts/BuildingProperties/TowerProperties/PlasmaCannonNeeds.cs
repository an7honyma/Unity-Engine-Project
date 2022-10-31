using UnityEngine;

public class PlasmaCannonNeeds : MonoBehaviour
{
    public float plasmaCannonCost = 200f;
    public float plasmaCannonPower = 125f;
    public int plasmaCannonWorkers = 5;

    void Start()
    {
        ResourceManager.credits -= plasmaCannonCost;
        ResourceManager.workers += plasmaCannonWorkers;
        ResourceManager.powerUsage += plasmaCannonPower;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= plasmaCannonWorkers;
        ResourceManager.powerUsage -= plasmaCannonPower;
        ResourceManager.UpdateResources();
    }
}
