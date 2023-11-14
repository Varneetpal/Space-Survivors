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
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}