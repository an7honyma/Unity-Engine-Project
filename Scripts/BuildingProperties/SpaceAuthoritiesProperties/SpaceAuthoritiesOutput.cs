using UnityEngine;

public class SpaceAuthoritiesOutput : MonoBehaviour
{
    void Start()
    {
        BuildToggle.spaceAuthorities += 1;
    }

    void OnDestroy()
    {
        BuildToggle.spaceAuthorities -= 1;
    }
}
