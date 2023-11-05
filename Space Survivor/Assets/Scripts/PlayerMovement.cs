using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10.0f;
    public float moveSpeed = 5.0f;
    public float fireRate = 0.5f;
    private float nextFireTime = 0.0f;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleShootingInput();
        HandleMovementInput();
    }

    void HandleShootingInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            // Determine the shooting direction
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            if (horizontalInput > 0)
            {
                animator.SetTrigger("ShootRightTrigger");
            }
            else if (horizontalInput < 0)
            {
                animator.SetTrigger("ShootLeftTrigger");
            }
            else if (verticalInput > 0)
            {
                animator.SetTrigger("ShootUpTrigger");
            }
            else if (verticalInput < 0)
            {
                animator.SetTrigger("ShootDownTrigger");
            }

            Shoot();
        }
    }

    void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, verticalInput, 0);
        movementDirection.Normalize();

        // Update the animator based on the input for movement
        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
        animator.SetFloat("Speed", movementDirection.sqrMagnitude);

        // Move the player based on input
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        // Create a new projectile at the firePoint position and rotation
        GameObject newProjectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Get the rigidbody of the projectile
        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();

        // Apply force to the projectile to make it move
        rb.velocity = firePoint.right * projectileSpeed;
    }
}