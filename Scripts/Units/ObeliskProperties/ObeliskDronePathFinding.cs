using UnityEngine;
using System;

public class ObeliskDronePathFinding : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float range = 20f;
    public float fireRate = 9f;
    private Transform target;
    private bool manualRecall = false;

    private float nextTimeToFire = 0f;
    public Transform projectileOrigin;
    public GameObject projectilePrefab;
    public float projectionSpeed = 20f;
    private float lookSpeed = 5f;
    private GameObject parentShip;
    private Vector3 spawnPoint;
    private float returnRange = 1f;

    void Start()
    {
        parentShip = transform.parent.gameObject;
        spawnPoint = parentShip.transform.position;
        transform.parent = null;
        FindTarget();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            manualRecall = true;
        }

        if (parentShip == null)
        {
            gameObject.GetComponent<Health>().Die();
        }
        else
        {
            spawnPoint = parentShip.transform.position;
        }
    }

    public Transform FindTarget()
    {
        if (parentShip != null)
        {
            target = parentShip.GetComponent<ObeliskPathFinding>().target;
        }
        else
        {
            target = null;
        }
        return target;
    }

    void FixedUpdate()
    {
        if (gameObject.tag == "Droid")
        {
            Move();
        }
    }

    public Transform UpdateTarget()
    {
        if (!manualRecall)
        {
            if (target != null && target.gameObject.tag != "Enemy")
            {
                target = null;
            }
        }
        else
        {
            target = null;
        }
        return target;
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
                transform.position = transform.position;
                
                Vector3 lookDirection = (target.position - transform.position).normalized;
                float dotProd = Vector3.Dot(lookDirection, transform.forward);

                if (Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1f/fireRate;
                    var projectile = Instantiate(projectilePrefab, projectileOrigin.position, projectileOrigin.rotation);
                    projectile.GetComponent<Rigidbody>().velocity = projectileOrigin.forward * projectionSpeed;
                }
            }
        }
        else
        {
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
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == parentShip && target == null)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == parentShip && target == null)
        {
            Destroy(gameObject);
        }
    }
}
