using UnityEngine;

public class RotateAroundY : MonoBehaviour
{
    public float rotationSpeed;
    
    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);
    }
}
