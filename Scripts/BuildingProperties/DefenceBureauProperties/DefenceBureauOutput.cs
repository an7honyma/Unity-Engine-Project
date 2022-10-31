using UnityEngine;

public class DefenceBureauOutput : MonoBehaviour
{
    void Start()
    {
        BuildToggle.defenceBureaus += 1;
    }

    void OnDestroy()
    {
        BuildToggle.defenceBureaus -= 1;
    }
}
