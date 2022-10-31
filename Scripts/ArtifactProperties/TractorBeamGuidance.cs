using UnityEngine;

public class TractorBeamGuidance : MonoBehaviour
{
    private float moveSpeed = 7f;
    private float lookSpeed = 3f;
    private Transform avatar;

    void Start()
    {
        avatar = GameObject.FindGameObjectWithTag("AvatarFocus").transform;
    }

    void FixedUpdate()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        // Rotate towards avatar:
        if (avatar.position - transform.position != Vector3.zero)
        {
            Vector3 dir = avatar.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        }
        // Move towards target:
        transform.position = Vector3.MoveTowards(transform.position, avatar.position, moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
