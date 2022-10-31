using UnityEngine;

public class Residences2Needs : MonoBehaviour
{
    public float residences2Cost = 750f;
    public float residences2Power = 50f;

    void Start()
    {
        ResourceManager.credits -= residences2Cost;
        ResourceManager.powerUsage += residences2Power;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.powerUsage -= residences2Power;
        ResourceManager.UpdateResources();
    }
}
