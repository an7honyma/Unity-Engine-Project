using UnityEngine;
using System.Collections.Generic;

public class DroidPathFinding : MonoBehaviour
{
    // Declared in subclasses:
    public float moveSpeed;
    public float range;
    public float fireRate;
    public float targetRange;

    private Transform target;
    private bool manualRecall = false;
    private bool findNewTarget = false;

    private float nextTimeToFire = 0f;
    public Transform projectileOrigin;
    public GameObject projectilePrefab;
    public float projectionSpeed = 20f;
    private float lookSpeed = 3f;
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
        if (gameObject.tag == "Droid" || gameObject.tag == "Cloaked")
        {
            Move();
        }
    }

    void Move()
    {
        if (target != null)
        {
            // Rotate towards target:
            if (target.transform.position - transform.position != Vector3.zero)
            {
                Vector3 dir = target.transform.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed).eulerAngles;
                transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
            }

            // Calculate distance between self and target:
            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if (distanceToTarget >= range)
            {
                // Move towards target:
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                // transform.position = transform.position;
                
                Vector3 lookDirection = (target.position - transform.position).normalized;
                // float dotProd = Vector3.Dot(lookDirection, transform.forward);

                if (Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1f/fireRate;
                    FireProjectiles();
                }
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

    public virtual void FireProjectiles()
    {
        var projectile = Instantiate(projectilePrefab, projectileOrigin.position, projectileOrigin.rotation);
        projectile.GetComponent<Rigidbody>().velocity = projectileOrigin.forward * projectionSpeed;
    }
}
