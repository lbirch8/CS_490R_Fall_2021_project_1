using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject objectivePrefab;
    public float spawnRange = 475f;

    private GameManager gameManager;
    private bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //this should only run once
        if (gameManager.gameActive)
        {
            if (!gameStarted)
            {
                gameStarted = true;
                SpawnObjective();
                InvokeRepeating("SpawnEnemy", 10.0f, 10.0f);
            }
        }
    }
    private Vector3 NewSpawnPosition(float height)
    {
        float spawnPosx = Random.Range(-spawnRange, spawnRange);
        float spawnPosy = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosx, height, spawnPosy);
        return randomPos;
    }
    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, NewSpawnPosition(10), enemyPrefab.transform.rotation);
    }

    public void SpawnObjective()
    {
        Instantiate(objectivePrefab, NewSpawnPosition(1), objectivePrefab.transform.rotation);
        SpawnEnemy();
    }
}
