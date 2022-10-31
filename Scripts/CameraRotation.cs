using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    // Reference to camera:
    [SerializeField] private Camera cam;
    // Reference to game object:
    private Transform origin;
    
    private Vector3 previousPosition;

    void LateUpdate()
    {
        GameObject rotationOrigin = GameObject.FindGameObjectWithTag("AvatarFocus");
        origin = rotationOrigin.transform;
        // Rotation control:
        if (Input.GetMouseButtonDown(2))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);

        if (Input.GetMouseButton(2))
        {
            /*
            if (direction.y > 0 || cam.transform.position.y > 1)
            {
                cam.transform.Rotate(new Vector3(x: 1, y: 0, z: 0), angle: direction.y * 180);
            }
            */
            cam.transform.Rotate(new Vector3(x: 1, y: 0, z: 0), angle: direction.y * 180);
            cam.transform.Rotate(new Vector3(x: 0, y: 1, z: 0), angle: -direction.x * 180, relativeTo: Space.World);
            
        }

        cam.transform.position = origin.position;
        cam.transform.Translate(new Vector3(x: 0, y: 0, z: -20));   
        previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
    }

}
