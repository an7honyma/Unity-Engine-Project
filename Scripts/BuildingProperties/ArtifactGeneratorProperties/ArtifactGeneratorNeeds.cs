using UnityEngine;

public class ArtifactGeneratorNeeds : MonoBehaviour
{
    public float artifactGeneratorCost = 3000f;
    public float artifactGeneratorPower = 500f;
    public int artifactGeneratorWorkers = 75;

    void Start()
    {
        ResourceManager.credits -= artifactGeneratorCost;
        ResourceManager.workers += artifactGeneratorWorkers;
        ResourceManager.powerUsage += artifactGeneratorPower;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= artifactGeneratorWorkers;
        ResourceManager.powerUsage -= artifactGeneratorPower;
        ResourceManager.UpdateResources();
    }
}
