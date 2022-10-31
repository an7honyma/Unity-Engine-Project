using UnityEngine;

public class TaurusCannonNeeds : MonoBehaviour
{
    public float taurusCannonCost = 400f;
    public float taurusCannonPower = 250f;
    public int taurusCannonWorkers = 10;

    void Start()
    {
        ResourceManager.credits -= taurusCannonCost;
        ResourceManager.workers += taurusCannonWorkers;
        ResourceManager.powerUsage += taurusCannonPower;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= taurusCannonWorkers;
        ResourceManager.powerUsage -= taurusCannonPower;
        ResourceManager.UpdateResources();
    }
}
