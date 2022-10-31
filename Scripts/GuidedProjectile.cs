using UnityEngine;

public class GuidedProjectile : MonoBehaviour
{
    public float damage;
    private float lookSpeed = 5f;
    public float moveSpeed;
    public GameObject impactEffect;
    public Transform target;
    private Vector3 targetLastPosition;
    private Vector3 vectorFloatZero = new Vector3(0.00f, 0.00f, 0.00f);

    void FixedUpdate()
    {
        if (target != null)
        {
            targetLastPosition = target.transform.position;
            // Move towards target:
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            // Rotate towards target:
            if (target.transform.position - transform.position != Vector3.zero)
            {
                Vector3 dir = target.transform.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed).eulerAngles;
                transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
            }
        }
        else if (targetLastPosition != vectorFloatZero)
        {
            // Move towards last known target position:
            transform.position = Vector3.MoveTowards(transform.position, targetLastPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetLastPosition) <= 0.2f)
            {
                Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            if (targetLastPosition - transform.position != Vector3.zero)
            {
                Vector3 dir = targetLastPosition - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed).eulerAngles;
                transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (target != null)
        {
            EnemyHealth enemyHealth = collision.transform.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
