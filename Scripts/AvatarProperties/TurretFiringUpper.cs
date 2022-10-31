using UnityEngine;

public class TurretFiringUpper : MonoBehaviour
{
    private float fireRate = 15f;
    private float nextTimeToFire = 0f;
    public Transform projectileOrigin;
    public GameObject projectilePrefab;
    public float projectionSpeed = 40f;
    public float energyRequired = 2.5f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && !BuildToggle.isBuilding && !SelectedUnits.selectUnits && AvatarRequirements.energy > energyRequired)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            AvatarRequirements.energy -= energyRequired;
            ShootUpper();
        }
    }

    void ShootUpper()
    {
        var projectile = Instantiate(projectilePrefab, projectileOrigin.position, projectileOrigin.rotation);
        projectile.GetComponent<Rigidbody>().velocity = projectileOrigin.forward * projectionSpeed;
    }
}
