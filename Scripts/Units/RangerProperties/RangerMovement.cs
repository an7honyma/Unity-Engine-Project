using UnityEngine;

public class RangerMovement : ShipMovement
{
    public RangerMovement()
    {
        moveSpeed = 8f;
        range = 50f;
        fireRate = 9f;
        projectionSpeed = 34f;
        targetRange = 110f;
    }
}