using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Enemy> enemyPrefabs;
    public int enemyCount;
    public int waveNumber = 1;
    public LayerMask groundLayer;

    [SerializeField]
    private BoxCollider2D room;

    [SerializeField]
    Vector2 spawnCheckRange;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    Vector3 GenerateSpawnPos()
    {
        Vector2 validSpawnPos = Vector2.zero;
        for (; validSpawnPos == Vector2.zero;)
        {
            Vector2 possibleSpawnPos = RandomPointInBounds(room.bounds);

            if (Physics2D.OverlapBox(possibleSpawnPos, spawnCheckRange, groundLayer) == false)
            {
                Debug.Log("Valid spawn position found!");
                validSpawnPos = possibleSpawnPos;
            }
            else
                Debug.Log("No suitable location not found, trying again.");
        }

        return validSpawnPos;
        /*
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, 0);
        return randomPos;
        */
    }

    void SpawnEnemyWave(int enemyWave)
    {
        int enemiesToSpawn = 0;
        if (enemyWave == 1)
            enemiesToSpawn = 3;
        else
            enemiesToSpawn = GetRandEnemyNum(enemyWave);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefabs[0], GenerateSpawnPos(), enemyPrefabs[0].transform.rotation);
        }
    }

    int GetRandEnemyNum(int waveNum)
    {
        int maxRange = 3 + (waveNum * 2);
        int minRange = maxRange - waveNum;
        int enemies = Random.Range(minRange, maxRange);
        return enemies;
    }

    public static Vector2 RandomPointInBounds(Bounds bounds)
    {
        return new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
    }
}
