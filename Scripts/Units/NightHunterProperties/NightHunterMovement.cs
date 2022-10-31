using UnityEngine;

public class NightHunterMovement : DroidPathFinding
{
    public NightHunterMovement()
    {
        moveSpeed = 10f;
        range = 20f;
        fireRate = 6f;
        targetRange = 60f;
    }
}
