using UnityEngine;

public class Residences2Population : MonoBehaviour
{
    public int residences2Population = 300;

    void Start()
    {
        ResourceManager.population += residences2Population;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.population -= residences2Population;
        ResourceManager.UpdateResources();
    }
}
