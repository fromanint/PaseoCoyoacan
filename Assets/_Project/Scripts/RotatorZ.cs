using UnityEngine;

public class RotatorZ : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private bool isRotatingForward = true;

    void Update()
    {
        // Determine the direction of rotation
        float rotationDirection = isRotatingForward ? 1 : -1;

        // Rotate the game object around the Z-axis
        transform.Rotate(0, 0, rotationSpeed * rotationDirection * Time.deltaTime);

        // Check if the rotation has reached the limit
        if (transform.eulerAngles.z >= 360f && isRotatingForward)
        {
            isRotatingForward = false;
        }
        else if (transform.eulerAngles.z <= 0f && !isRotatingForward)
        {
            isRotatingForward = true;
        }
    }
}