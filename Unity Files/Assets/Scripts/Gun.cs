using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firepoint;
    private float fireForce = 20f;

    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firepoint.up * fireForce, ForceMode2D.Impulse);
    }

}
