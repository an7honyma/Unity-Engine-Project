using UnityEngine;

public class SentryMovement : DroidPathFinding
{
    public SentryMovement()
    {
        moveSpeed = 10f;
        range = 20f;
        fireRate = 10f;
        targetRange = 60f;
    }
}
