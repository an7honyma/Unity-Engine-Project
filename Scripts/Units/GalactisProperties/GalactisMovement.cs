using UnityEngine;
using System.Collections.Generic;

public class GalactisMovement : ShipMovementWithGuided
{
    public GalactisMovement()
    {
        moveSpeed = 6.5f;
        range = 90;
        fireRate = 6.5f;
        guidedFireRate = 5f;
        targetRange = 130f;
    }
}
