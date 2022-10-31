using UnityEngine;

public class CommerceCentrePopulation : MonoBehaviour
{
    void Start()
    {
        ResourceManager.commerceCentreCount += 1;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.commerceCentreCount -= 1;
        ResourceManager.UpdateResources();
    }
}
