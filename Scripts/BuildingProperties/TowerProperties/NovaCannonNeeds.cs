using UnityEngine;

public class NovaCannonNeeds : MonoBehaviour
{
    public float novaCannonCost = 1200f;
    public float novaCannonPower = 75f;
    public int novaCannonWorkers = 30;

    void Start()
    {
        ResourceManager.credits -= novaCannonCost;
        ResourceManager.workers += novaCannonWorkers;
        ResourceManager.powerUsage += novaCannonPower;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= novaCannonWorkers;
        ResourceManager.powerUsage -= novaCannonPower;
        ResourceManager.UpdateResources();
    }
}
