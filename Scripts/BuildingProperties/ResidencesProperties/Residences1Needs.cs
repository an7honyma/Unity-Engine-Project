using UnityEngine;

public class Residences1Needs : MonoBehaviour
{
    public float residences1Cost = 250f;
    public float residences1Power = 25f;

    void Start()
    {
        ResourceManager.credits -= residences1Cost;
        ResourceManager.powerUsage += residences1Power;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.powerUsage -= residences1Power;
        ResourceManager.UpdateResources();
    }
}
