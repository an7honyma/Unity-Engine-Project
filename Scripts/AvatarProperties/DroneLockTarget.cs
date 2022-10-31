using UnityEngine;

public class DroneLockTarget : MonoBehaviour
{
    private float range = 20f;
    public float projectionSpeed = 20f;
    private float fireRate = 15f;
    private float nextTimeToFire = 0f;
    private Transform target;
    private GameObject rotationOrigin;
    private Transform sourceObject;
    public Transform projectileOrigin;
    public GameObject projectilePrefab;
    private float lookSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        // Update target enemy:
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
    }

    void LateUpdate()
    {
        GameObject rotationOrigin = GameObject.FindGameObjectWithTag("AvatarFocus");
        sourceObject = rotationOrigin.transform;
        // Drone idle:
        if (target == null)
        {
            // Look outward from source object:
            if (sourceObject.transform.position - transform.position != Vector3.zero)
            {
                transform.forward = -(sourceObject.transform.position - transform.position);
            }
        }
        else if (target.gameObject.tag == "Enemy")
        {
            // Rotate towards enemy target:
            if (target.transform.position - transform.position != Vector3.zero)
            {
                Vector3 dir = target.transform.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed).eulerAngles;
                transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
                // transform.forward = target.transform.position - transform.position;
            }

            Vector3 lookDirection = (target.position - transform.position).normalized;
            float dotProd = Vector3.Dot(lookDirection, transform.forward);

            // Fire projectiles:
            if (Time.time >= nextTimeToFire && dotProd > 0.9)
            {
                nextTimeToFire = Time.time + 1f/fireRate;
                var projectile = Instantiate(projectilePrefab, projectileOrigin.position, projectileOrigin.rotation);
                projectile.GetComponent<Rigidbody>().velocity = projectileOrigin.forward * projectionSpeed;
            }  
        }
        else
        {
            // Look outward from source object:
            if (sourceObject.transform.position - transform.position != Vector3.zero)
            {
                transform.forward = -(sourceObject.transform.position - transform.position);
            }
        }
    }
}
