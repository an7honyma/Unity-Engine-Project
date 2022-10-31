using UnityEngine;
using System.Linq;

public class RepairDroneMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float range = 3f;
    public float fireRate = 15f;
    public float healAmount = 0.5f;
    public float targetRange= 50f;
    private bool manualRecall = false;

    private Transform target;
    private float distanceToTarget;
    private Vector3 returnPoint;
    private float returnPointOrientation;

    public Transform projectileOrigin;
    public GameObject repairDroneProjectilePrefab;
    private float nextTimeToFire = 0f;
    public float projectionSpeed = 20f;
    private float lookSpeed = 5f;

    void Start()
    {
        // Establish spawn point:
        returnPointOrientation = transform.rotation.y;
        returnPoint = transform.position;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            manualRecall = true;
        }
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

        if (!manualRecall)
        {
            // Update target enemy:
            foreach (GameObject target in targets)
            {
                Health health = target.GetComponent<Health>();
                RepairStationHealth repairStationHealth = target.GetComponent<RepairStationHealth>();
                if (health != null && repairStationHealth == null)
                {
                    if (Vector3.Distance(returnPoint, target.transform.position) <= targetRange)
                    {
                        if (target.GetComponent<Health>().maxHealth > target.GetComponent<Health>().health)
                        {
                            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
                            if (distanceToTarget < shortestDistance)
                            {
                                shortestDistance = distanceToTarget;
                                nearestTarget = target;
                            }
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
        if (target != null)
        {
            // Calculate distance between object and target:
            distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if (distanceToTarget >= range)
            {
                // Move towards target:
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                if (Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1f/fireRate;
                    var projectile = Instantiate(repairDroneProjectilePrefab, projectileOrigin.position, projectileOrigin.rotation);
                    projectile.GetComponent<Rigidbody>().velocity = projectileOrigin.forward * projectionSpeed;
                    Health health = target.transform.GetComponent<Health>();
                    if (health != null)
                    {
                        health.Heal(healAmount);
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
        else
        {
            if (returnPoint - transform.position != Vector3.zero)
            {
                // Rotate towards droid's spawn point:
                Vector3 dir = returnPoint - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed).eulerAngles;
                transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
                // Move towards spawn point:
                transform.position = Vector3.MoveTowards(transform.position, returnPoint, moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, returnPointOrientation, 0f);
                manualRecall = false;
            }
        }
    }
}