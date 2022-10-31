using UnityEngine;

public class SpaceAuthoritiesNeeds : MonoBehaviour
{
    public float spaceAuthoritiesCost = 1500f;
    public float spaceAuthoritiesPower = 75f;
    public int spaceAuthoritiesWorkers = 30;

    void Start()
    {
        ResourceManager.credits -= spaceAuthoritiesCost;
        ResourceManager.workers += spaceAuthoritiesWorkers;
        ResourceManager.powerUsage += spaceAuthoritiesPower;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= spaceAuthoritiesWorkers;
        ResourceManager.powerUsage -= spaceAuthoritiesPower;
        ResourceManager.UpdateResources();
    }
}
