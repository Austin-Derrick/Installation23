using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Enemy> enemyPrefabs;
    public int enemyCount;
    public int waveNumber = 1;
    public BoxCollider2D room;

    [SerializeField]
    float spawnRange = 9;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        room = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, 0);
        return randomPos;
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
}
