using UnityEngine;

public class PowerPlantRotation : MonoBehaviour
{
    private float rotationSpeed = 20f;

    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime);
    }
}
