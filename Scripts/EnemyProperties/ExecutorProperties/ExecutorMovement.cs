using UnityEngine;

public class ExecutorMovement : EnemyPathFindingWithGuided
{
    public ExecutorMovement()
    {
        moveSpeed = 4.6f;
        range = 52f;
        fireRate = 0.25f;
        guidedFireRate = 1f;
    }
}
