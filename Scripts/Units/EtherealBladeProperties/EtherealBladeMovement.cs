using UnityEngine;

public class EtherealBladeMovement : ShipMovementWithGuided
{
    public EtherealBladeMovement()
    {
        moveSpeed = 8f;
        range = 100f;
        guidedFireRate = 5f;
        projectionSpeed = 34f;
        targetRange = 150f;
    }
}