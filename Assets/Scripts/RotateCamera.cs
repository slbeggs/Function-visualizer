using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public Transform target; // The target (or pivot) to rotate around
    public float rotateSpeed = 5.0f;
    public float distance = 4.0f; // Distance from the target
    private float xAngle = 0.0f;
    private float yAngle = 0.0f;
    public float zoomSpeed = 10.0f;
    public float minDistance = 2.0f; // Minimum distance from the target
    public float maxDistance = 20.0f; // Maximum distance from the target

    void Start()
    {
        // Set initial rotation angles
        xAngle = transform.eulerAngles.y;
        yAngle = transform.eulerAngles.x;
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) // When the left mouse button is pressed
        {
            // Update the angles based on mouse movement
            xAngle += Input.GetAxis("Mouse X") * rotateSpeed;
            yAngle -= Input.GetAxis("Mouse Y") * rotateSpeed;

            // Clamp the vertical rotation to avoid flipping
            yAngle = Mathf.Clamp(yAngle, -50, 80);
        }

        // Update camera position and rotation
        Quaternion rotation = Quaternion.Euler(yAngle, xAngle, 0);
        Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

        transform.rotation = rotation;
        transform.position = position;
        // Zoom based on mouse scroll input
        distance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance); // Make sure the camera doesn't go too close or too far
    }
}