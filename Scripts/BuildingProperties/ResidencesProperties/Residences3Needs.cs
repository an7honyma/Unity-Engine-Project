using UnityEngine;

public class Residences3Needs : MonoBehaviour
{
    public float residences3Cost = 1000f;
    public float residences3Power = 650f;

    void Start()
    {
        ResourceManager.credits -= residences3Cost;
        ResourceManager.powerUsage += residences3Power;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.powerUsage -= residences3Power;
        ResourceManager.UpdateResources();
    }
}
