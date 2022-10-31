using UnityEngine;

public class SkyOrchidMovement : ShipMovementWithGuided
{
    public SkyOrchidMovement()
    {
        moveSpeed = 4f;
        range = 100f;
        fireRate = 3f;
        guidedFireRate = 5f;
        projectionSpeed = 34f;
        targetRange = 150f;
    }
}