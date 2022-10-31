using UnityEngine;

public class DefenceBureauNeeds : MonoBehaviour
{
    public float defenceBureauCost = 1500f;
    public float defenceBureauPower = 75f;
    public int defenceBureauWorkers = 30;

    void Start()
    {
        ResourceManager.credits -= defenceBureauCost;
        ResourceManager.workers += defenceBureauWorkers;
        ResourceManager.powerUsage += defenceBureauPower;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= defenceBureauWorkers;
        ResourceManager.powerUsage -= defenceBureauPower;
        ResourceManager.UpdateResources();
    }
}
