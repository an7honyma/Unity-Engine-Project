using UnityEngine;

public class PlatformCannon : DoubleFiring
{
    public PlatformCannon()
    {
        range = 100f;
        projectionSpeed = 70f;
        fireRate = 3f;
    }
}