using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target;    // The object that the camera will follow
    public float smoothing = 5f;    // The smoothing factor for the camera movement

    private Vector3 offset;    // The initial offset between the camera and the target

    void Start()
    {
        // Calculate the initial offset between the camera and the target
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // Calculate the desired position for the camera
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}
