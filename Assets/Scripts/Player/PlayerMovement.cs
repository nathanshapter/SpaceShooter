using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float movementSpeed = 10;
    [SerializeField] float accelerationSmoothingTime = 1.0f;
    [SerializeField] float decelerationSmoothingTime = 0.5f;
    [SerializeField] float extraMovementTime = 1.0f;
    [SerializeField] float extraMovementSpeed = 5.0f;

    private Vector2 targetInput;
    private float targetSpeed;
    private Vector2 currentVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetSpeed = movementSpeed;
    }

    private void FixedUpdate()
    {
        // Face the mouse
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z; // Set the distance from the camera to the player (adjust if needed)
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 directionToMouse = mouseWorldPosition - transform.position;
        transform.up = directionToMouse.normalized;

        // Calculate the movement direction from WASD input
        Vector2 wasdInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Modify WASD input to move towards/away from the mouse cursor
        if (wasdInput.y > 0) // "W" key pressed (forward)
        {
            wasdInput = directionToMouse.normalized;
        }
        else if (wasdInput.y < 0) // "S" key pressed (backward)
        {
            wasdInput = -directionToMouse.normalized;
        }
        else if (wasdInput.x > 0) // "D" key pressed (right)
        {
            wasdInput = new Vector2(directionToMouse.y, -directionToMouse.x).normalized;
        }
        else if (wasdInput.x < 0) // "A" key pressed (left)
        {
            wasdInput = new Vector2(-directionToMouse.y, directionToMouse.x).normalized;
        }

        // Move the player
        float smoothingTime = (wasdInput.magnitude > 0) ? accelerationSmoothingTime : decelerationSmoothingTime;
        targetInput = Vector2.SmoothDamp(targetInput, wasdInput, ref currentVelocity, smoothingTime);
        rb.velocity = targetInput * targetSpeed;
    }
}
