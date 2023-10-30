using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15.0f;
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
        
    }
    
    private void Movement()
    {
        // if (GameManager.instance.player) {
        //     transform.LookAt(GameManager.instance.player.transform.position);
        //     transform.position += transform.forward * moveSpeed * Time.deltaTime; 
        // }
    }
}
