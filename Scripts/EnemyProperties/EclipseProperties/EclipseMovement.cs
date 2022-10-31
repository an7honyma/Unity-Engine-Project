using UnityEngine;

public class EclipseMovement : EnemyPathFindingWithGuided
{
    public EclipseMovement()
    {
        moveSpeed = 4.6f;
        range = 52f;
        fireRate = 5f;
        guidedFireRate = 3f;
    }
}
