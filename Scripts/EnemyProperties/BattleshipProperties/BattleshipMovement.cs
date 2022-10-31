using UnityEngine;

public class BattleshipMovement : EnemyPathFinding
{
    public BattleshipMovement()
    {
        moveSpeed = 5f;
        range = 30f;
        fireRate = 7.5f;
    }
}
