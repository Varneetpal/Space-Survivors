using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    [SerializeField] private float spawnRate = 2.0f;
    private float _spawnTimer;
    public GameObject[] enemySpawners;
    private GameObject _currentSpawner;
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
    }
    
    private void SpawnEnemy()
    {
        if (Time.time > _spawnTimer)
        {
            enemySpawners = GameObject.FindGameObjectsWithTag("EnemySpawn");
            _index = Random.Range(0,enemySpawners.Length);
            _currentSpawner = enemySpawners[_index];
            float maxHealth = 100 + _enemyCount;
            GameObject newEnemy = Instantiate(enemyPrefab, _currentSpawner.transform.position, _currentSpawner.transform.rotation);
            newEnemy.GetComponent<Enemy>().maxHealth = maxHealth;
            newEnemy.GetComponent<Enemy>().health = maxHealth;
            _spawnTimer = Time.time + spawnRate;
            _enemyCount++;
        }
    }
}
