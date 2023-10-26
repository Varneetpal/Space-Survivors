using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust player movement speed in the Inspector

    public Rigidbody2D rb;
    //public Gun gun;
    public Animator animator;

    Vector2 movement;

  

    private void Update()
    {
        // Get input for movement
         movement.x = Input.GetAxis("Horizontal");
         movement.y = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
