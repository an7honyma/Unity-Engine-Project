using UnityEngine;

public class CallistoDroidMovement : DroidPathFinding
{
    public CallistoDroidMovement()
    {
        moveSpeed = 8f;
        range = 40f;
        fireRate = 8f;
        targetRange = 100f;
    }
}