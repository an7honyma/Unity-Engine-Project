using UnityEngine;

public class AbyssRayMovement : DroidPathFinding
{
    public AbyssRayMovement()
    {
        moveSpeed = 7.5f;
        range = 45f;
        fireRate = 7.5f;
        targetRange = 110f;
    }
}