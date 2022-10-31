using UnityEngine;

public class AvatarTurrets : MonoBehaviour
{
    public Transform upperTurret;
    public Transform lowerTurret;
    float upperTurretAngle;
    float lowerTurretAngle;
    RaycastHit hit;

    private Camera mainCamera;

    void Update()
    {
        mainCamera = FindObjectOfType<Camera>();
        if (TimeManager.isPaused == false)
        {
            RotateUpperTurret();
            RotateLowerTurret();
        }
    }

    void RotateUpperTurret()
    {
        Ray cameraRay  = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(cameraRay, out hit, 50000.0f, (1 << 9)) || Physics.Raycast(cameraRay, out hit, 50000.0f, (1 << 20)))
        {
            upperTurret.LookAt(hit.point);
        }
        else
        {
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                upperTurret.LookAt(new Vector3(pointToLook.x, upperTurret.position.y, pointToLook.z));
            }
        }
    }

    void RotateLowerTurret()
    {
        Ray cameraRay  = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(cameraRay, out hit, 50000.0f, (1 << 9)) || Physics.Raycast(cameraRay, out hit, 50000.0f, (1 << 20)))
        {
            lowerTurret.LookAt(hit.point);
        }
        else
        {
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                lowerTurret.LookAt(new Vector3(pointToLook.x, lowerTurret.position.y, pointToLook.z));
            }
        }
    }
}
