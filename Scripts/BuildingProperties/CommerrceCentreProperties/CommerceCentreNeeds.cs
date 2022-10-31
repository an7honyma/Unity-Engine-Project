using UnityEngine;

public class CommerceCentreNeeds : MonoBehaviour
{
    public float commerceCentreCost = 1500f;
    public float commerceCentrePower = 50f;
    public int commerceCentreWorkers = 25;

    void Start()
    {
        ResourceManager.credits -= commerceCentreCost;
        ResourceManager.powerUsage += commerceCentrePower;
        ResourceManager.workers += commerceCentreWorkers;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.powerUsage -= commerceCentrePower;
        ResourceManager.workers -= commerceCentreWorkers;
        ResourceManager.UpdateResources();
    }
}
