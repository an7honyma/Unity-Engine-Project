using UnityEngine;

public class RedOlympusMovement : ShipMovementWithGuided
{
    public RedOlympusMovement()
    {
        moveSpeed = 6f;
        range = 30f;
        fireRate = 10f;
        guidedFireRate = 3f;
        projectionSpeed = 30f;
        targetRange = 90f;
    }
}