using UnityEngine;

public class HydraMovement : ShipMovement
{
    public HydraMovement()
    {
        moveSpeed = 8f;
        range = 45f;
        fireRate = 9f;
        projectionSpeed = 32f;
        targetRange = 100f;
    }
}