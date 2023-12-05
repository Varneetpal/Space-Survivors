using UnityEngine;

public class BuzzEnemy : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] public float maxHealth = 200.0f;
    [SerializeField] public float health = 200.0f;
    [SerializeField] private float damageToPlayer = 50.0f;
    [SerializeField] private float damageRate = 0.5f;
    [SerializeField] private float damageTime;
    
    private Vector2 direction;
    public GameObject deathEffect;
    public HealthBar healthbar;
    private GameObject player;
    public GameObject bullet;
    public Transform bulletPos;
    private float timer; //to control the frequncy that the bullet spawn into the scene

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        healthbar.SetMaxhealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    { 
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);
        if (distance < 10){
            timer += Time.deltaTime;
            if (timer > 2){
                timer = 0;
                shoot();
            }
        }
        direction = GameManager.instance.player.transform.position - transform.position;
        direction.Normalize();
        float angle = Vector2.SignedAngle(Vector2.down, direction);
        transform.eulerAngles = new Vector3 (0, 0, angle);
    }

    void shoot(){
        PlayerAudioManager.instance.PlaySound("BossShoot");
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player") && Time.time > damageTime && !(other is CircleCollider2D))
        {
            other.transform.GetComponent<PlayerController>().TakeDamage(damageToPlayer);
            damageTime = Time.time + damageRate;
        }
    }
    
    public void TakeDamage(float damage, bool isPlayer)
    {
        health -= damage;
        
        healthbar.SetHealth(health);
        if (health <= 0)
        {
            //set health to fix bug where kills are counted twice
            health = 10000;

            if (isPlayer)
            {
                GameManager.instance.player.GetComponent<PlayerController>().regen();
                GameManager.instance.increaseKills();
            }
            var position = transform.position;
            var rotation = transform.rotation;
            GameObject effect = Instantiate(deathEffect, position, rotation);
            PlayerAudioManager.instance.PlaySound("BossDeathSound");
            Destroy(effect, 1.0f);
            Destroy(this.gameObject);
        }
    }
}
