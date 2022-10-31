using UnityEngine;
using System.Linq;

public class RepairStationOperation : MonoBehaviour
{
    public float fireRate = 5f;
    public float targetRange = 30f;
    private float moveSpeed = 2f;

    public Transform target;

    private float projectionSpeed = 10f;
    public Transform projectileOrigin1;
    public Transform projectileOrigin2;
    public Transform projectileOrigin3;
    public Transform projectileOrigin4;
    public GameObject repairStationProjectilePrefab;
    private float nextTimeToFire = 0f;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    public Transform UpdateTarget()
    {
        GameObject[] enemyTargets = GameObject.FindGameObjectsWithTag("EnemyTarget");
        GameObject[] droids = GameObject.FindGameObjectsWithTag("Droid");
        GameObject[] vehicles = GameObject.FindGameObjectsWithTag("Vehicle");
        GameObject[] ships = GameObject.FindGameObjectsWithTag("Ship");
        GameObject[] targets = enemyTargets.Concat(droids).ToArray();
        targets = targets.Concat(vehicles).ToArray();
        targets = targets.Concat(ships).ToArray();

        float shortestDistance = Mathf.Infinity;
        GameObject nearestTarget = null;

        // Update target enemy:
        foreach (GameObject target in targets)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if (distanceToTarget <= targetRange)
            {
                Health health = target.GetComponent<Health>();
                RepairStationHealth repairStationHealth = target.GetComponent<RepairStationHealth>();
                if (health != null && target != gameObject && repairStationHealth == null)
                {
                    if (target.GetComponent<Health>().maxHealth > target.GetComponent<Health>().health)
                    {
                        if (distanceToTarget < shortestDistance)
                        {
                            shortestDistance = distanceToTarget;
                            nearestTarget = target;
                        }
                    }
                }
            }
        }

        if (nearestTarget != null)
        {
            target = nearestTarget.transform;
        }
        else
        {
            target = null;
        }
        return target;
    }

    void FixedUpdate()
    {
        if (target != null && gameObject.tag != "Untagged")
        {
            if (Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f/fireRate;
                var projectile1 = Instantiate(repairStationProjectilePrefab, projectileOrigin1.position, projectileOrigin1.rotation);
                projectile1.GetComponent<GuidedHealthProjectile>().target = target;
                projectile1.GetComponent<Rigidbody>().AddForce(projectileOrigin1.forward * projectionSpeed, ForceMode.VelocityChange);
                var projectile2 = Instantiate(repairStationProjectilePrefab, projectileOrigin2.position, projectileOrigin2.rotation);
                projectile2.GetComponent<GuidedHealthProjectile>().target = target;
                projectile2.GetComponent<Rigidbody>().AddForce(projectileOrigin2.forward * projectionSpeed, ForceMode.VelocityChange);
                var projectile3 = Instantiate(repairStationProjectilePrefab, projectileOrigin3.position, projectileOrigin3.rotation);
                projectile3.GetComponent<GuidedHealthProjectile>().target = target;
                projectile3.GetComponent<Rigidbody>().AddForce(projectileOrigin3.forward * projectionSpeed, ForceMode.VelocityChange);
                var projectile4 = Instantiate(repairStationProjectilePrefab, projectileOrigin4.position, projectileOrigin4.rotation);
                projectile4.GetComponent<GuidedHealthProjectile>().target = target;
                projectile4.GetComponent<Rigidbody>().AddForce(projectileOrigin4.forward * projectionSpeed, ForceMode.VelocityChange);
            }
        }

        if (transform.position != initialPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);
        }
    }
}