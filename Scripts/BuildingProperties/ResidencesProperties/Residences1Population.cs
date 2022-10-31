using UnityEngine;

public class Residences1Population : MonoBehaviour
{
    public int residences1Population = 200;

    void Start()
    {
        ResourceManager.population += residences1Population;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.population -= residences1Population;
        ResourceManager.UpdateResources();
    }
}
