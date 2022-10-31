using UnityEngine;
using System.Linq;

public class EnemyPathFindingWithGuided : MonoBehaviour
{
    // Declared in subclasses:
    public float moveSpeed;
    public float range;
    public float fireRate;
    public float guidedFireRate;

    private Transform target;
    private float distanceToTarget;

    private float nextTimeToFire = 0f;
    private float nextTimeToGuidedFire = 0f;
    public Transform[] projectileOrigins;
    public Transform[] guidedProjectileOrigins;
    public GameObject enemyProjectilePrefab;
    public GameObject enemyGuidedProjectilePrefab;
    public float projectionSpeed = 20f;
    private float guidedProjectionSpeed = 5f;
    private float lookSpeed = 2f;

    void Start()
    {
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
            if (distanceToTarget < shortestDistance)
            {
                shortestDistance = distanceToTarget;
                nearestTarget = target;
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
        if (gameObject.tag == "Enemy")
        {
            Operate();
        }
    }

    void Operate()
    {
        if (target != null)
        {
            // Calculate distance between enemy and target:
            distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if (distanceToTarget >= range)
            {
                // Move towards target:
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                Vector3 lookDirection = (target.position - transform.position).normalized;
                float dotProd = Vector3.Dot(lookDirection, transform.forward);

                if (Time.time >= nextTimeToFire && dotProd > 0.9)
                {
                    nextTimeToFire = Time.time + 1f/fireRate;
                    foreach (Transform projectileOrigin in projectileOrigins)
                    {
                        projectileOrigin.LookAt(target);
                        var enemyProjectile = Instantiate(enemyProjectilePrefab, projectileOrigin.position, projectileOrigin.rotation);
                        enemyProjectile.GetComponent<Rigidbody>().velocity = projectileOrigin.forward * projectionSpeed;
                    }
                }
                if (Time.time >= nextTimeToGuidedFire && dotProd > 0.9)
                {
                    nextTimeToGuidedFire = Time.time + 1f/guidedFireRate;
                    foreach (Transform guidedProjectileOrigin in guidedProjectileOrigins)
                    {
                        var enemyGuidedProjectile = Instantiate(enemyGuidedProjectilePrefab, guidedProjectileOrigin.position, guidedProjectileOrigin.rotation);
                        enemyGuidedProjectile.GetComponent<GuidedEnemyProjectile>().target = target;
                        enemyGuidedProjectile.GetComponent<Rigidbody>().AddForce(guidedProjectileOrigin.forward * guidedProjectionSpeed, ForceMode.VelocityChange);
                    }
                } 
            }
            
            // Rotate towards target:
            if (target.transform.position - transform.position != Vector3.zero)
            {
                Vector3 dir = target.transform.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed).eulerAngles;
                transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
            }
        }
    }
}
