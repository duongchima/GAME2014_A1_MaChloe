using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Wave
{
    public string waveName;
    public int numOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}
public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    Wave[] waves;
    [SerializeField]
    Transform[] spawnPoints;

    private Wave currentWave;
    private int currentWaveNum;
    private bool canSpawn = true;
    private float nextSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentWave = waves[currentWaveNum];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(totalEnemies.Length == 0 && !canSpawn && currentWaveNum + 1 != waves.Length)
        {
            SpawnNextWave();
        }
    }

    void SpawnNextWave()
    {
        currentWaveNum++;
        canSpawn = true;
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            int x = Random.Range(0, spawnPoints.Length);
            GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
            Transform randomPoint = spawnPoints[x];
            if (x < 5)
            {
                Instantiate(randomEnemy, randomPoint.position, Quaternion.Euler(0, 180, 0));
            }
            else
            {
                Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            }
            currentWave.numOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if(currentWave.numOfEnemies == 0)
            {
                canSpawn = false;
            }
        }
    }
}
