using UnityEngine;

public class SuperReactorOutput : MonoBehaviour
{
    public float superReactorOutput = 3000f;

    void Start()
    {
        ResourceManager.power += superReactorOutput;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.power -= superReactorOutput;
        ResourceManager.UpdateResources();
    }
}
