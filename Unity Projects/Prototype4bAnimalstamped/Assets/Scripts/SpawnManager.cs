using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public int animalIndex;
    public int SpawnRangeX = 20;
    public int spawnPosZ = 20;
    private float startDelay = 4;
    private float spawnInterval = 1.25f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
 
    void SpawnRandomAnimal(){
        // Pick an animal and a position
        Vector3 spawnPos = new Vector3(Random.Range(-SpawnRangeX,SpawnRangeX),0,spawnPosZ);
        animalIndex = Random.Range(0,animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
