using UnityEngine;

public class CarrierMovement : EnemyPathFinding
{
    public CarrierMovement()
    {
        moveSpeed = 4.9f;
        range = 32f;
        fireRate = 0.5f;
    }
}
