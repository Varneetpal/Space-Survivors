using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float health = 100.0f;
    
    [SerializeField] private float damageToPlayer = 50.0f;
    [SerializeField] private float damageRate = 0.2f;
    [SerializeField] private float damageTime;
    
    public GameObject deathEffect;
    // public GameManager GameManager;
   
    

    // Start is called before the first frame update
    void Start()
    {

}

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    
    private void Movement()
    {
        if (GameManager.instance.player) {
            // transform.LookAt(GameManager.instance.player.transform.position);
            // transform.position = transform.forward * moveSpeed * Time.deltaTime;
            Vector3 direction = GameManager.instance.player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

// Move the object forward in the direction it's facing (2D forward is the right direction)
            transform.position += transform.right * Time.deltaTime * moveSpeed;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(deathEffect, transform.position, transform.rotation);
        }

    }
}
