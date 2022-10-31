using UnityEngine;

public class BuildingIndicatorRotation : MonoBehaviour
{
    private float rotationSpeed = 50f;
    private float oscillationSpeed = 2f;
    private float oscillationHeight = 0.5f;
    private Vector3 pos;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);
        float newY = Mathf.Sin(Time.time * oscillationSpeed) * oscillationHeight + pos.y;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
