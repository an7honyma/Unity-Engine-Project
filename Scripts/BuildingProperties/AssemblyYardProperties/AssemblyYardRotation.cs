using UnityEngine;

public class AssemblyYardRotation : MonoBehaviour
{
    private float rotationSpeed = 10f;

    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime, Space.Self);
    }
}
