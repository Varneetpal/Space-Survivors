using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField] private float decayRate = 5f;
    [SerializeField] private float killRegenRate = 5f;
    [SerializeField] private bool decayOn;
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        healthbar.SetMaxhealth(maxHealth);

        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (decayOn)
        {
            currentHealth -= decayRate * Time.deltaTime;
        }
        healthbar.SetHealth(currentHealth);
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), (Input.GetAxis("Vertical")));
        death();
    }

    private void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed;
    }
    
    public void switchDecay()
    {
        if (decayOn)
        {
            decayOn = false;
        }
        else
        {
            decayOn = true;
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }

    public void regen()
    {
        if(currentHealth < maxHealth)
        {
            currentHealth += killRegenRate;
            healthbar.SetHealth(currentHealth);
        }
    }

    public void resetHealthAndPosition()
    {
        currentHealth = maxHealth;
        transform.position = Vector3.zero;
    }

    public void death()
    {
        if (currentHealth <= 0)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effect, 1.0f);
            PlayerAudioManager.instance.PlaySound("DeathSound");
            //Destroy(this.gameObject);

            switchDecay();
            resetHealthAndPosition();

            SceneManager.LoadScene("GameOver");
        }
    }

    public void increaseHealth(float rate)
    {
        maxHealth = (float) (maxHealth * rate) ;
        currentHealth = maxHealth;
        healthbar.SetHealth(currentHealth);
    }
}