using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    [SerializeField] private float spawnRate = 2.0f;
    private float spawnTimer;

    private float spawnRange = 10.0f;

    private Transform [] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }
    
    private void SpawnEnemy()
    {
        if (Time.time > spawnTimer)
        {
            // Choosing a random spawn point

            // float randomPosition1 = Random.Range(-spawnRange, spawnRange);
            // float randomPosition2 = Random.Range(-spawnRange, spawnRange);
            //
            // Vector3 spawnPosition = transform.position + new Vector3(randomPosition1, 0, randomPosition2);
            //
            // Instantiate(enemyPrefab, spawnPosition, transform.rotation);
            // spawnTimer = Time.time + spawnRate;
            // currentEnemyHealth += 20.0f;
            
            
            float randomPosition1 = Random.Range(-spawnRange, spawnRange);
            float randomPosition2 = Random.Range(-spawnRange, spawnRange);

            Vector2 spawnPosition = (Vector2)transform.position + new Vector2(randomPosition1, randomPosition2);

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            spawnTimer = Time.time + spawnRate;
        }
    }
}
