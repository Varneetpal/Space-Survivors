using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust player movement speed in the Inspector

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        // Apply movement
        rb.velocity = movement * moveSpeed;
    }
}
