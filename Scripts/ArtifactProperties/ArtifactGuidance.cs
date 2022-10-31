using UnityEngine;

public class ArtifactGuidance : MonoBehaviour
{
    private float defaultRange = 10f;
    private float moveSpeed = 5f;
    private float lookSpeed = 3f;
    private Transform avatar;
    public GameObject tractorBeamEffect;
    private float nextTimeToGenerate = 0f;
    private float generationRate = 2.5f;

    void Start()
    {
        avatar = GameObject.FindGameObjectWithTag("AvatarFocus").transform;
    }

    void FixedUpdate()
    {
        if (AvatarAbilities.tractorBeamEnabled)
        {
            if (Vector3.Distance(transform.position, avatar.position) < defaultRange * AvatarAbilities.tractorBeamLevel)
            {
                MoveTowardsPlayer();
            }
        }
    }

    void MoveTowardsPlayer()
    {
        if (Time.time >= nextTimeToGenerate)
        {
            nextTimeToGenerate = Time.time + 1f/generationRate;
            Instantiate(tractorBeamEffect, transform.position, transform.rotation);
        }

        // Rotate towards avatar:
        if (avatar.position - transform.position != Vector3.zero)
        {
            Vector3 dir = avatar.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        }
        // Move towards target:
        transform.position = Vector3.MoveTowards(transform.position, avatar.position, moveSpeed * Time.deltaTime);
    }
}
