using UnityEngine;

public class VoidCannonNeeds : MonoBehaviour
{
    public float voidCannonCost = 1600f;
    public float voidCannonPower = 1000f;
    public int voidCannonWorkers = 40;

    void Start()
    {
        ResourceManager.credits -= voidCannonCost;
        ResourceManager.workers += voidCannonWorkers;
        ResourceManager.powerUsage += voidCannonPower;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= voidCannonWorkers;
        ResourceManager.powerUsage -= voidCannonPower;
        ResourceManager.UpdateResources();
    }
}
