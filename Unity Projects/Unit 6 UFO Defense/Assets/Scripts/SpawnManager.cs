using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int wave;
    public GameObject UFO;
    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
        InvokeRepeating("SpawnWave", 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnWave(){
        for (int i = 0; i < wave; i++)
        {
            Instantiate(UFO, new Vector3(Random.Range(-20,20),0,Random.Range(30,40)), UFO.transform.rotation);
        }
        wave++;
    }

}
