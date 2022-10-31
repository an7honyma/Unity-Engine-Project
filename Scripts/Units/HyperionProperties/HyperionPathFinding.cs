using UnityEngine;
using System.Collections.Generic;

public class HyperionPathFinding : MonoBehaviour
{
    public float moveSpeed = 5.5f;
    public float range = 100f;
    public float deployRange = 150f;
    public float fireRate = 6.5f;
    public float deployRate = 0.5f;
    public float targetRange = 200f;
    private bool manualRecall = false;

    public Transform target;
    private float distanceToTarget;
    private bool findNewTarget = false;

    private float nextTimeToFire = 0f;
    private float nextTimeToDeploy = 0f;
    public Transform projectileOrigin1;
    public Transform projectileOrigin2;
    public Transform projectileOrigin3;
    public Transform projectileOrigin4;
    public GameObject projectilePrefab;
    public Transform droneOrigin;
    public GameObject dronePrefab;
    public float projectionSpeed = 40f;
    private float lookSpeed = 1f;
    private Vector3 spawnPoint;
    private float returnRange = 15f;
    private List<GameObject> allocatedTargets = new List<GameObject>();
    RaycastHit hit;

    void Start()
    {
        spawnPoint = transform.position;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            manualRecall = true;
            allocatedTargets.Clear();
        }

        if (SelectedUnits.selectUnits && Input.GetMouseButtonDown(1) && SelectedUnits.selectedUnits.Contains(gameObject))
        {
            Ray ray  = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 50000f, (1 << 9)) || Physics.Raycast(ray, out hit, 50000f, (1 << 20)))
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    allocatedTargets.Add(hit.transform.gameObject);
                }
                else
                {
                    allocatedTargets.Clear();
                    allocatedTargets.Add(hit.transform.gameObject);
                }
            }
        }
    }

    public Transform UpdateTarget()
    {
        if (allocatedTargets.Count == 0)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;

            if (!manualRecall)
            {
                // Update target enemy:
                foreach (GameObject enemy in enemies)
                {
                    float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                    if (distanceToEnemy < shortestDistance && distanceToEnemy < targetRange)
                    {
                        shortestDistance = distanceToEnemy;
                        nearestEnemy = enemy;
                    }
                }
            }

            if (nearestEnemy != null)
            {
                target = nearestEnemy.transform;
            }
            else
            {
                target = null;
            }
        }
        else
        {
            if (allocatedTargets[0] != null && allocatedTargets[0].tag == "Enemy")
            {
                target = allocatedTargets[0].transform;
            }
            else
            {
                allocatedTargets.RemoveAt(0);
            }
        }
        return target;
    }

    void FixedUpdate()
    {
        if (gameObject.tag == "Ship")
        {
            Move();
        }
    }

    void Move()
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
            else if (distanceToTarget <= range)
            {
                transform.position = transform.position;

                Vector3 lookDirection = (target.position - transform.position).normalized;
                float dotProd = Vector3.Dot(lookDirection, transform.forward);

                projectileOrigin1.LookAt(target);
                projectileOrigin2.LookAt(target);
                projectileOrigin3.LookAt(target);
                projectileOrigin4.LookAt(target);

                if (Time.time >= nextTimeToFire && dotProd > 0.9)
                {
                    nextTimeToFire = Time.time + 1f/fireRate;
                    var projectile1 = Instantiate(projectilePrefab, projectileOrigin1.position, projectileOrigin1.rotation);
                    projectile1.GetComponent<Rigidbody>().velocity = projectileOrigin1.forward * projectionSpeed;
                    var projectile2 = Instantiate(projectilePrefab, projectileOrigin2.position, projectileOrigin2.rotation);
                    projectile2.GetComponent<Rigidbody>().velocity = projectileOrigin2.forward * projectionSpeed;
                    var projectile3 = Instantiate(projectilePrefab, projectileOrigin3.position, projectileOrigin3.rotation);
                    projectile3.GetComponent<Rigidbody>().velocity = projectileOrigin3.forward * projectionSpeed;
                    var projectile4 = Instantiate(projectilePrefab, projectileOrigin4.position, projectileOrigin4.rotation);
                    projectile4.GetComponent<Rigidbody>().velocity = projectileOrigin4.forward * projectionSpeed;
                }
            }

            if (distanceToTarget <= deployRange)
            {
                if (Time.time >= nextTimeToDeploy)
                {
                    nextTimeToDeploy = Time.time + 1f/deployRate;
                    var dronePrefab1 = Instantiate(dronePrefab, droneOrigin.position, droneOrigin.rotation);
                    dronePrefab1.transform.parent = gameObject.transform;
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
            findNewTarget = true;
        }
        else
        {
            if (findNewTarget)
            {
                UpdateTarget();
                findNewTarget = false;
            }
            // Calculate distance between object and spawn point:
            float distanceToSpawn = Vector3.Distance(transform.position, spawnPoint);
            if (spawnPoint - transform.position != Vector3.zero)
            {
                if (distanceToSpawn > returnRange)
                {
                    // Rotate towards spawnPoint:
                    Vector3 dir = spawnPoint - transform.position;
                    Quaternion lookRotation = Quaternion.LookRotation(dir);
                    Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed).eulerAngles;
                    transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
                    // Move towards spawn range:
                    transform.position = Vector3.MoveTowards(transform.position, spawnPoint, moveSpeed * Time.deltaTime);
                }
                else
                {
                    // Rotate away from spawnPoint:
                    Vector3 dir = transform.position - spawnPoint;
                    Quaternion lookRotation = Quaternion.LookRotation(dir);
                    Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed).eulerAngles;
                    transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
                    manualRecall = false;
                }
            }
        }
    }
}
