using UnityEngine;

public class PhotonTankHead : MonoBehaviour
{
    public float fireRate = 7.5f;

    private float nextTimeToFire = 0f;
    public Transform projectileOrigin;
    public GameObject photonTankProjectilePrefab;
    public GameObject tankBody;
    public float projectionSpeed = 30f;
    private float lookSpeed = 5f;

    void FixedUpdate()
    {
        if (tankBody.tag == "Vehicle")
        {
            Operate();
        }
    }

    void Operate()
    {
        Transform target = tankBody.GetComponent<PhotonTankMovement>().target;
        if (target != null)
        {
            Vector3 dir = target.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed).eulerAngles;

            if (tankBody.GetComponent<PhotonTankMovement>().inRange)
            {
                // Rotate towards target:
                if (target.transform.position - transform.position != Vector3.zero)
                {
                    transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
                    
                }

                Vector3 lookDirection = (target.position - transform.position).normalized;
                float dotProd = Vector3.Dot(lookDirection, transform.forward);

                if (Time.time >= nextTimeToFire && dotProd > 0.9)
                {
                    nextTimeToFire = Time.time + 1f/fireRate;
                    var projectile = Instantiate(photonTankProjectilePrefab, projectileOrigin.position, projectileOrigin.rotation);
                    projectile.GetComponent<Rigidbody>().velocity = projectileOrigin.forward * projectionSpeed;
                }
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, rotation.y, 0);
            }
        }
    }
}