using UnityEngine;

public class PowerPlantOutput : MonoBehaviour
{
    public float powerPlantOutput = 1000f;

    void Start()
    {
        ResourceManager.power += powerPlantOutput;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.power -= powerPlantOutput;
        ResourceManager.UpdateResources();
    }
}
