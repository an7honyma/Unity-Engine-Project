using UnityEngine;

public class ScoutMovement : EnemyPathFinding
{
    public ScoutMovement()
    {
        moveSpeed = 5.5f;
        range = 20f;
        fireRate = 10f;
    }
}
