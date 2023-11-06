using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Player health info
    [SerializeField] private float movementSpeed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    
    public float maxHealth = 100;
    public float currentHealth;
    public HealthBar healthbar;
    public GameObject deathEffect;
    
    public Camera cam;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        healthbar.SetMaxhealth(maxHealth);
    }

    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), (Input.GetAxis("Vertical")));
    }

    private void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed;
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effect, 1.0f);
            Destroy(this.gameObject);
        }
    }
    
}