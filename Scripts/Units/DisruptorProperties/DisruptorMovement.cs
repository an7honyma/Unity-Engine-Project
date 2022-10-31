using UnityEngine;

public class DisruptorMovement : DroidPathFinding
{
    public Transform projectileOrigin2;
    public Transform projectileOrigin3;
    public DisruptorMovement()
    {
        moveSpeed = 9.5f;
        range = 25f;
        fireRate = 9.5f;
        targetRange = 70f;
    }

    public override void FireProjectiles()
    {
        var projectile = Instantiate(projectilePrefab, projectileOrigin.position, projectileOrigin.rotation);
        projectile.GetComponent<Rigidbody>().velocity = projectileOrigin.forward * projectionSpeed;
        var projectile2 = Instantiate(projectilePrefab, projectileOrigin2.position, projectileOrigin2.rotation);
        projectile2.GetComponent<Rigidbody>().velocity = projectileOrigin2.forward * projectionSpeed;
        var projectile3 = Instantiate(projectilePrefab, projectileOrigin3.position, projectileOrigin3.rotation);
        projectile3.GetComponent<Rigidbody>().velocity = projectileOrigin3.forward * projectionSpeed;
    }
}