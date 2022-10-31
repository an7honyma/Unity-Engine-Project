using UnityEngine;

public class EnforcerMovement : DroidPathFinding
{
    public EnforcerMovement()
    {
        moveSpeed = 9.5f;
        range = 25f;
        fireRate = 9.5f;
        targetRange = 70f;
    }
}