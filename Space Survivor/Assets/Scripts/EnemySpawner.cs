using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject BossPrefab;
    private GameObject newBoss;
    [SerializeField] private float spawnRate = 2.0f;
    private float _spawnTimer;
    private int bosscount = 0;
    public GameObject[] enemySpawners;
    private GameObject _currentSpawner;
    public GameObject bossSpawner;
    private int _index;
    private int _enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        _enemyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
        if (newBoss.IsDestroyed())
        {
            bosscount -= 1;
        }
    }
    
    private void SpawnEnemy()
    {
        if (Time.time > _spawnTimer)
        {
            enemySpawners = GameObject.FindGameObjectsWithTag("EnemySpawn");
            _index = Random.Range(0,enemySpawners.Length);
            _currentSpawner = enemySpawners[_index];
            float maxHealth = 100 + _enemyCount;
            if ((GameManager.instance.score % 5 == 0) && (GameManager.instance.score != 0) && (bosscount == 0))
            {
                newBoss = Instantiate(BossPrefab, bossSpawner.transform.position, bossSpawner.transform.rotation);
                bosscount += 1;
            }
            else
            {
                GameObject newEnemy = Instantiate(enemyPrefab, _currentSpawner.transform.position, _currentSpawner.transform.rotation);
                newEnemy.GetComponent<Enemy>().maxHealth = maxHealth;
                newEnemy.GetComponent<Enemy>().health = maxHealth;
            }
            _spawnTimer = Time.time + spawnRate;
            _enemyCount++;
        }
    }
    
}
