using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 direction;
    private float distance;
    public GameObject player;
    
    [SerializeField] private float maxHealth = 100.0f;
    [SerializeField] private float health;
    [SerializeField] private float damageToPlayer = 50.0f;
    [SerializeField] private float damageRate = 0.2f;
    [SerializeField] private float damageTime;
    
    public GameObject deathEffect;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    void Update()
    {
        direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Vector2.SignedAngle(Vector2.up, direction);
        transform.eulerAngles = new Vector3 (0, 0, angle);

        rb.velocity = direction * movementSpeed;
    }

    
}
