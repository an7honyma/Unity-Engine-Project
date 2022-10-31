using UnityEngine;

public class AstralCannonNeeds : MonoBehaviour
{
    public float astralCannonCost = 800f;
    public float astralCannonPower = 500f;
    public int astralCannonWorkers = 20;

    void Start()
    {
        ResourceManager.credits -= astralCannonCost;
        ResourceManager.workers += astralCannonWorkers;
        ResourceManager.powerUsage += astralCannonPower;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= astralCannonWorkers;
        ResourceManager.powerUsage -= astralCannonPower;
        ResourceManager.UpdateResources();
    }
}
