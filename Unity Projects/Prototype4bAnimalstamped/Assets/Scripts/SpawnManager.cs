using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public int animalIndex;
    public int SpawnRangeX = 20;
    public int spawnPosZ = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Pick an animal and a position
            Vector3 spawnPos = new Vector3(Random.Range(-SpawnRangeX,SpawnRangeX),0,spawnPosZ);
            animalIndex = Random.Range(0,animalPrefabs.Length);
            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);

        }
    }
}
