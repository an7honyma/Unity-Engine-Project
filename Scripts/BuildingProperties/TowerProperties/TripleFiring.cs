using UnityEngine;

public class TripleFiring : MonoBehaviour
{
    public float range;
    public float projectionSpeed;
    public float fireRate;
    private float nextTimeToFire = 0f;
    private Transform target;
    public Transform projectileOrigin1;
    public Transform projectileOrigin2;
    public Transform projectileOrigin3;
    public GameObject projectilePrefab;
    private float lookSpeed = 10f;
    private float idleRotationSpeed = 10f;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    Transform UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        // Update target enemy:
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance && enemy.GetComponent<Rigidbody>().useGravity == false)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
        return target;
    }

    void Update()
    {
        if (!ResourceManager.insufficientPower)
        {
            Operate();
        }
    }

    void Operate()
    {
        if (target == null)
        {
            transform.Rotate(new Vector3(0, idleRotationSpeed, 0) * Time.deltaTime, Space.World);
        }
        else
        {   
            // Rotate towards enemy target:
            if (target.transform.position - transform.position != Vector3.zero)
            {
                Vector3 dir = target.transform.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed).eulerAngles;
                transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
            }
            
            Vector3 lookDirection = (target.position - transform.position).normalized;
            float dotProd = Vector3.Dot(lookDirection, transform.forward);

            projectileOrigin1.LookAt(target);
            projectileOrigin2.LookAt(target);
            projectileOrigin3.LookAt(target);

            if (Time.time >= nextTimeToFire && dotProd > 0.9)
            {
                nextTimeToFire = Time.time + 1f/fireRate;
                // Fire projectiles:
                var projectile1 = Instantiate(projectilePrefab, projectileOrigin1.position, projectileOrigin1.rotation);
                projectile1.GetComponent<Rigidbody>().velocity = projectileOrigin1.forward * projectionSpeed;
                var projectile2 = Instantiate(projectilePrefab, projectileOrigin2.position, projectileOrigin2.rotation);
                projectile2.GetComponent<Rigidbody>().velocity = projectileOrigin2.forward * projectionSpeed;
                var projectile3 = Instantiate(projectilePrefab, projectileOrigin3.position, projectileOrigin3.rotation);
                projectile3.GetComponent<Rigidbody>().velocity = projectileOrigin3.forward * projectionSpeed;
            }
            
        }
    }
}
