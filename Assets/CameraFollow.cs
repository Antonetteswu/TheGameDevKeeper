using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;     // Drag your Player here in the Inspector
    public float smoothTime = 0.25f; // How fast the camera catches up
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Keep the camera at a distance

    private Vector3 currentVelocity = Vector3.zero;

    // FixedUpdate or LateUpdate is best for cameras to prevent jitter
    private void LateUpdate()
    {
        if (target == null) return;

        // The position we want the camera to be at
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera from its current position to the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
    }
}