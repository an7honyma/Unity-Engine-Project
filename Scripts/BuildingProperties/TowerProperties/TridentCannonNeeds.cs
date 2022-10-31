using UnityEngine;

public class TridentCannonNeeds : MonoBehaviour
{
    public float tridentCannonCost = 2000f;
    public float tridentCannonPower = 1250f;
    public int tridentCannonWorkers = 50;

    void Start()
    {
        ResourceManager.credits -= tridentCannonCost;
        ResourceManager.workers += tridentCannonWorkers;
        ResourceManager.powerUsage += tridentCannonPower;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= tridentCannonWorkers;
        ResourceManager.powerUsage -= tridentCannonPower;
        ResourceManager.UpdateResources();
    }
}
