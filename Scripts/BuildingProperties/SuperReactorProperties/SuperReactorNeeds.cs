using UnityEngine;

public class SuperReactorNeeds : MonoBehaviour
{
    public float superReactorCost = 1000f;
    public int superReactorWorkers = 25;

    void Start()
    {
        ResourceManager.credits -= superReactorCost;
        ResourceManager.workers += superReactorWorkers;
        ResourceManager.UpdateResources();
    }

    void OnDestroy()
    {
        ResourceManager.workers -= superReactorWorkers;
        ResourceManager.UpdateResources();
    }
}
