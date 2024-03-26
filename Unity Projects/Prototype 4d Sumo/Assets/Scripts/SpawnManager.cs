using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int difficulty;
    public GameObject powerupPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        difficulty = 3;
        
    }
    void Update(){// Counts enemies, and spawns waves when there are no enemies. Also spawns powerups
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            SpawnEnemyWave(difficulty);
            difficulty++;
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }
private Vector3 GenerateSpawnPosition(){//picks a random point in -9 through 9 on x and z axis
    float spawnPosX = Random.Range(-spawnRange, spawnRange);
    float spawnPosZ = Random.Range(-spawnRange, spawnRange);
    Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
    return randomPos;
}
void SpawnEnemyWave(int size){// simple for loop, makes an enemy 3 times
    for (int i = 0; i < size; i++)
    {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }
}
   
}
