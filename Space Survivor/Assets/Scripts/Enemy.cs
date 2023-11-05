using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 direction;
    private GameObject player;
    
    [SerializeField] public float maxHealth = 100.0f;
    [SerializeField] public float health = 100.0f;
    [SerializeField] private float damageToPlayer = 50.0f;
    [SerializeField] private float damageRate = 0.2f;
    [SerializeField] private float damageTime;
    
    public GameObject deathEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Vector2.SignedAngle(Vector2.up, direction);
        transform.eulerAngles = new Vector3 (0, 0, angle);

        rb.velocity = direction * movementSpeed;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            var position = transform.position;
            var rotation = transform.rotation;
            GameObject effect = Instantiate(deathEffect, position, rotation);
            Destroy(effect, 1.0f);
            Destroy(this.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player") && Time.time > damageTime)
        {
            other.transform.GetComponent<PlayerController>().TakeDamage(damageToPlayer);
            damageTime = Time.time + damageRate;
        }
    }
}
