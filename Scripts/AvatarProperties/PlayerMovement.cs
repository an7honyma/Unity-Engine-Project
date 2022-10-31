using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;
    public float rotationSpeed = 360f;
    
    Rigidbody rigidBody;
    public float elevationSpeed = 3f;
    private float upperAltitudeLimit = 400f;
    private float boundsLimit = 420f;

    private CharacterController characterController;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Move avatar based on user input:
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Player elevation:
        if (Input.GetKey(KeyCode.Space))
        {
            elevationSpeed = 3f;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            elevationSpeed = -3f;
        }
        else
        {
            elevationSpeed = 0f;
        }

        // Determine direction vector:
        Vector3 movementDirection = new Vector3(horizontalInput, elevationSpeed, verticalInput);
        // Normalise to have magnitude of 1 in any direction:
        movementDirection.Normalize();

        // Move avatar through game environment, using Time.deltaTime to move at constant speed regardless of frame rate, relative to world:
        // transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        rigidBody.MovePosition(rigidBody.position + movementDirection * speed * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            // If moving, avatar should rotate towards direction of movement:
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Altitude limit checking:
        Vector3 temp = transform.position;
        if (temp.y >= upperAltitudeLimit)
        {
            temp.y = upperAltitudeLimit;
        }
        if (temp.x >= boundsLimit)
        {
            temp.x = boundsLimit;
        }
        if (temp.x <= -boundsLimit)
        {
            temp.x = -boundsLimit;
        }
        if (temp.z >= boundsLimit)
        {
            temp.z = boundsLimit;
        }
        if (temp.z <= -boundsLimit)
        {
            temp.z = -boundsLimit;
        }
        transform.position = temp;
    }
}
