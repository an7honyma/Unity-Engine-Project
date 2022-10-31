using UnityEngine;

public class GuardianMovement : DroidPathFinding
{
    public GuardianMovement()
    {
        moveSpeed = 9f;
        range = 30f;
        fireRate = 9f;
        targetRange = 80f;
    }
}