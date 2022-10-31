using UnityEngine;

public class AntaresCannonNeeds : MonoBehaviour
{
    public float antaresCannonCost = 1400f;
    public float antaresCannonPower = 875f;
    public int antaresCannonWorkers = 35;

    void Start()
    {
        ResourceManager.credits -= antaresCannonCost;
        ResourceManager.workers += antaresCannonWorkers;
        ResourceManager.powerUsage += antaresCannonPower;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= antaresCannonWorkers;
        ResourceManager.powerUsage -= antaresCannonPower;
        ResourceManager.UpdateResources();
    }
}
