using UnityEngine;

public class StarWardenMovement : DroidPathFinding
{
    public StarWardenMovement()
    {
        moveSpeed = 8f;
        range = 40f;
        fireRate = 8f;
        targetRange = 100f;
    }
}