using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    private int goldWorth;
    [SerializeField] private float magnetismSpeed = 15.0f;
    private bool magnetism = false;

    // Start is called before the first frame update
    void Start()
    {
        goldWorth = GameManager.instance.goldWorth;
    }

    // Update is called once per frame
    void Update()
    {
        if (magnetism == true)
        {
            magnet();
        }
    }

    private void magnet()
    {
        if (GameManager.instance.player)
        {
            transform.LookAt(GameManager.instance.player.transform.position);
            transform.position += transform.forward * magnetismSpeed * Time.deltaTime;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other is CircleCollider2D && other.transform.CompareTag("Player"))
        {
            magnetism = true;
        }

        else if (other.transform.CompareTag("Player"))
        {
            GameManager.instance.increaseGold(goldWorth);
            Destroy(this.gameObject);
        }
    }   
}
