using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 mousepos;
    public float lifeTime;
    private Camera mainCam;
    private Rigidbody2D rb;
    [SerializeField] public float damage = 50.0f;

    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage,true);
            Destroy(this.gameObject);
        }
        else if (other.transform.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        else if (other.transform.CompareTag("Boss"))
        {
            other.GetComponent<BuzzEnemy>().TakeDamage(damage,true);
            Destroy(this.gameObject);
        }

    }
}
