using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OncollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
