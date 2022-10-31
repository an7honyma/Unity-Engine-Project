using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            GetComponent<Camera>().fieldOfView -= 2;
            if (GetComponent<Camera>().fieldOfView < 15)
            {
                GetComponent<Camera>().fieldOfView = 15;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            GetComponent<Camera>().fieldOfView += 2;
            if (GetComponent<Camera>().fieldOfView > 75)
            {
                GetComponent<Camera>().fieldOfView = 75;
            }
        }
    }
}
