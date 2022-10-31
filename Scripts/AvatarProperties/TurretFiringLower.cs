using UnityEngine;

public class TurretFiringLower : MonoBehaviour
{
    private float fireRate = 10f;
    private float nextTimeToFire = 0f;
    public Transform projectileOrigin;
    public GameObject projectilePrefab;
    public float projectionSpeed = 40f;
    public float energyRequired = 2.5f;

    void Update()
    {
        if (Input.GetButton("Fire2") && Time.time >= nextTimeToFire && !BuildToggle.isBuilding && !SelectedUnits.selectUnits && AvatarRequirements.energy > energyRequired)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            AvatarRequirements.energy -= energyRequired;
            ShootLower();
        }
    }

    void ShootLower()
    {
        var projectile = Instantiate(projectilePrefab, projectileOrigin.position, projectileOrigin.rotation);
        projectile.GetComponent<Rigidbody>().velocity = projectileOrigin.forward * projectionSpeed;
    }
}