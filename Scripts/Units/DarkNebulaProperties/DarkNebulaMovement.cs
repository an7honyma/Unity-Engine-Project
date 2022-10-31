using UnityEngine;

public class DarkNebulaMovement : ShipMovementWithGuided
{
    public DarkNebulaMovement()
    {
        moveSpeed = 6f;
        range = 30f;
        fireRate = 6f;
        guidedFireRate = 3f;
        projectionSpeed = 30f;
        targetRange = 90f;
    }
}