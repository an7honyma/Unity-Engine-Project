using UnityEngine;

public class Residences3Population : MonoBehaviour
{
    public int residences3Population = 400;

    void Start()
    {
        ResourceManager.population += residences3Population;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.population -= residences3Population;
        ResourceManager.UpdateResources();
    }
}
