using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject projectile;


    [SerializeField] private float fireRate = 0.1f;
    private float fireTime;

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= fireTime)
        {
            Debug.Log("Test");
            Instantiate(projectile, transform.position, transform.rotation);
            fireTime = Time.time + fireRate; //Set your fire rate cooldown
        }
    }

}
