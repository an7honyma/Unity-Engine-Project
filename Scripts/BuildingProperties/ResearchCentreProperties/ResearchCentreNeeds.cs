using UnityEngine;

public class ResearchCentreNeeds : MonoBehaviour
{
    public float researchCentreCost = 150f;
    public float researchCentrePower = 25f;
    public int researchCentreWorkers = 100;

    void Start()
    {
        ResourceManager.credits -= researchCentreCost;
        ResourceManager.workers += researchCentreWorkers;
        ResourceManager.powerUsage += researchCentrePower;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= researchCentreWorkers;
        ResourceManager.powerUsage -= researchCentrePower;
        ResourceManager.UpdateResources();
    }
}
