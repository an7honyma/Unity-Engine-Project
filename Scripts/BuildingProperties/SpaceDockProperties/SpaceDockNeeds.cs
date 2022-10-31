using UnityEngine;

public class SpaceDockNeeds : MonoBehaviour
{
    public float spaceDockCost = 5000f;
    public float spaceDockPower = 750f;
    public int spaceDockWorkers = 100;

    void Start()
    {
        ResourceManager.credits -= spaceDockCost;
        ResourceManager.workers += spaceDockWorkers;
        ResourceManager.powerUsage += spaceDockPower;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= spaceDockWorkers;
        ResourceManager.powerUsage -= spaceDockPower;
        ResourceManager.UpdateResources();
    }
}
