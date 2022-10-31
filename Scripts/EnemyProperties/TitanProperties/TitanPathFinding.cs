using UnityEngine;
using System.Linq;

public class TitanPathFinding : MonoBehaviour
{
    // Declared in subclasses:
    public float moveSpeed = 4.7f;
    public float range = 50;
    public float fireRate = 5.5f;

    private Transform target;
    private float distanceToTarget;

    private float nextTimeToFire = 0f;
    public Transform projectileOrigin1;
    public Transform projectileOrigin2;
    private bool deployVipers = true;
    public Transform deploymentOrigin1;
    public Transform deploymentOrigin2;
    public Transform deploymentOrigin3;
    public Transform deploymentOrigin4;
    public Transform deploymentOrigin5;
    public Transform deploymentOrigin6;
    public GameObject enemyProjectilePrefab;
    public GameObject viperPrefab;
    public float projectionSpeed = 20f;
    private float lookSpeed = 5f;

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
                transform.position = transform.position;
                
                Vector3 lookDirection = (target.position - transform.position).normalized;
                float dotProd = Vector3.Dot(lookDirection, transform.forward);

                if (Time.time >= nextTimeToFire && dotProd > 0.9)
                {
                    nextTimeToFire = Time.time + 1f/fireRate;
                    var enemyProjectile1 = Instantiate(enemyProjectilePrefab, projectileOrigin1.position, projectileOrigin1.rotation);
                    enemyProjectile1.GetComponent<Rigidbody>().velocity = projectileOrigin1.forward * projectionSpeed;
                    var enemyProjectile2 = Instantiate(enemyProjectilePrefab, projectileOrigin2.position, projectileOrigin2.rotation);
                    enemyProjectile2.GetComponent<Rigidbody>().velocity = projectileOrigin2.forward * projectionSpeed;
                }

                if (deployVipers && dotProd > 0.9)
                {
                    var viperPrefab1 = Instantiate(viperPrefab, deploymentOrigin1.position, deploymentOrigin1.rotation);
                    viperPrefab1.GetComponent<Rigidbody>().velocity = deploymentOrigin1.forward * projectionSpeed;
                    var viperPrefab2 = Instantiate(viperPrefab, deploymentOrigin2.position, deploymentOrigin2.rotation);
                    viperPrefab2.GetComponent<Rigidbody>().velocity = deploymentOrigin2.forward * projectionSpeed;
                    var viperPrefab3 = Instantiate(viperPrefab, deploymentOrigin3.position, deploymentOrigin3.rotation);
                    viperPrefab3.GetComponent<Rigidbody>().velocity = deploymentOrigin3.forward * projectionSpeed;
                    var viperPrefab4 = Instantiate(viperPrefab, deploymentOrigin4.position, deploymentOrigin4.rotation);
                    viperPrefab4.GetComponent<Rigidbody>().velocity = deploymentOrigin4.forward * projectionSpeed;
                    var viperPrefab5 = Instantiate(viperPrefab, deploymentOrigin5.position, deploymentOrigin5.rotation);
                    viperPrefab5.GetComponent<Rigidbody>().velocity = deploymentOrigin5.forward * projectionSpeed;
                    var viperPrefab6 = Instantiate(viperPrefab, deploymentOrigin6.position, deploymentOrigin6.rotation);
                    viperPrefab6.GetComponent<Rigidbody>().velocity = deploymentOrigin6.forward * projectionSpeed;
                    deployVipers = false;
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
