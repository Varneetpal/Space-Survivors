using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject collisionEffect;
    private void OncollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(collisionEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
