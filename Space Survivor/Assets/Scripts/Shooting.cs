using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    public Vector3 firePoint;
    public GameObject bullet;
    public float bulletSpeed;
    public Transform bulletTransform;
    private Vector2 direction;
    public bool canFire;
    private float timer;
    public float timeBetweenFire;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        lookat();
        Shoot();
    }

    void lookat()
    {
        firePoint = mainCam.ScreenToWorldPoint(Input.mousePosition);
        direction = firePoint - transform.position;
        direction.Normalize();
        float angle = Vector2.SignedAngle(Vector2.up, direction);
        transform.eulerAngles = new Vector3 (0, 0, angle);
    }
    
    void Shoot()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFire)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = true;
            GameObject bullet1 = Instantiate(bullet, bulletTransform.position, bulletTransform.rotation);
            PlayerAudioManager.instance.PlaySound("Shoot");
            bullet1.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }

    public void increaseFireRate(float rate)
    {
        timeBetweenFire = (float) (timeBetweenFire * rate);
    }
}
