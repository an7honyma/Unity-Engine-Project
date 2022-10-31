using UnityEngine;

public class DeceptorMovement : DroidPathFinding
{
    public DeceptorMovement()
    {
        moveSpeed = 8f;
        range = 40f;
        fireRate = 8f;
        targetRange = 100f;
    }
}