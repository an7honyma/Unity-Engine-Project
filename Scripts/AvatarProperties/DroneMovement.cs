using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    public float orbitSpeed = 30f;
    private GameObject rotationOrigin;
    private float radius = 5f;
    public float lifetime = 10f;
    public float requiredEnergy = 200f;
    private Transform origin;

    void Start()
    {
        Destroy(gameObject, lifetime * AvatarAbilities.droneLevel);
    }

    void LateUpdate()
    {
        GameObject rotationOrigin = GameObject.FindGameObjectWithTag("AvatarFocus");
        origin = rotationOrigin.transform;
        // Re-adjust radius when player object is moving:
        var newPos = (transform.position - origin.transform.position).normalized * radius;
        newPos += origin.transform.position;
        transform.position = newPos;

        transform.RotateAround(origin.transform.position, new Vector3(0, 1, 0), orbitSpeed * Time.deltaTime);
    }
}
