using UnityEngine;

public class CameraFollow1 : MonoBehaviour
{
    public Transform target1;
    public float smoothing = 5f;
    public Vector3 offset1;
    public Vector2 minBounds; // Minimum X and Y bounds
    public Vector2 maxBounds; // Maximum X and Y bounds

    void LateUpdate()
    {
        if (target1 != null)
        {
            Vector3 targetPosition;
            targetPosition.x = target1.position.x + offset1.x;
            targetPosition.y = target1.position.y + offset1.y;
            targetPosition.z = -10;
            // Clamp the camera's position within the bounds
            targetPosition.x = Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minBounds.y, maxBounds.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }
}