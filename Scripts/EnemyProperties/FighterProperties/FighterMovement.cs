using UnityEngine;

public class FighterMovement : EnemyPathFinding
{
    public FighterMovement()
    {
        moveSpeed = 5.5f;
        range = 20f;
        fireRate = 7f;
    }
}
