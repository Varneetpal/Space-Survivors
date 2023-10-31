using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firepoint;
    private float fireForce = 20f;
    private float nextFireTime = 0.0f;
    public float fireRate = 0.5f;
    public Animator animator;

    Vector2 shoot;


    void Update()
    {
        DetermineShootingDirection();
        HandleShootingInput();
    }

    public void Shoot()
    {
        nextFireTime = Time.time + fireRate;
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firepoint.up * fireForce, ForceMode2D.Impulse);
    }

    void HandleShootingInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFireTime)
        {

            nextFireTime = Time.time + fireRate;
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            if (horizontalInput > 0 && (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFireTime))
            {
                animator.SetTrigger("ShootRight");
                Shoot();
            }
            else if (horizontalInput < 0 && (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFireTime))
            {
                animator.SetTrigger("ShootLeft");
                Shoot();
            }
            else if (verticalInput > 0 && (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFireTime))
            {
                animator.SetTrigger("ShootUp");
                Shoot();
            }
            else if (verticalInput < 0 && (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFireTime))
            {
                animator.SetTrigger("ShootDown");
                Shoot();
            }
        }
        
        }

    void DetermineShootingDirection()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput > 0)
        {
            animator.SetTrigger("ShootRight");
        }
        else if (horizontalInput < 0)
        {
            animator.SetTrigger("ShootLeft");
        }
        else if (verticalInput > 0)
        {
            animator.SetTrigger("ShootUp");
        }
        else if (verticalInput < 0)
        {
            animator.SetTrigger("ShootDown");
        }
    }

}
