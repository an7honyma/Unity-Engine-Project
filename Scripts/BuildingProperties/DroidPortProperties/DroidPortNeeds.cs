using UnityEngine;

public class DroidPortNeeds : MonoBehaviour
{
    public float droidPortCost = 1000f;
    public float droidPortPower = 100f;
    public int droidPortWorkers = 25;

    void Start()
    {
        ResourceManager.credits -= droidPortCost;
        ResourceManager.workers += droidPortWorkers;
        ResourceManager.powerUsage += droidPortPower;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= droidPortWorkers;
        ResourceManager.powerUsage -= droidPortPower;
        ResourceManager.UpdateResources();
    }
}
