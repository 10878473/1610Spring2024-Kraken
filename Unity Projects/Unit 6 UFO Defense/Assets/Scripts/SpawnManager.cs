using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int wave;
    public GameObject UFO;
    public GameObject PowerUp;
    private bool spawnPowerup;
    // Start is called before the first frame update
    void Start()
    {
        spawnPowerup = true;
        wave = 1;
        InvokeRepeating("SpawnWave", 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //Spawn powerups
        if (spawnPowerup){
            Instantiate(PowerUp, new Vector3(Random.Range(-20,20),0,Random.Range(30,40)), PowerUp.transform.rotation);
            StartCoroutine("randomCooldown");
            spawnPowerup = false;
        }
    }
    //spawn waves according to wave size
    private void SpawnWave(){
        for (int i = 0; i < wave; i++)
        {
            Instantiate(UFO, new Vector3(Random.Range(-20,20),0,Random.Range(30,40)), UFO.transform.rotation);
        }
        wave++;
    }
    IEnumerator randomCooldown(){
        yield return new WaitForSeconds(Random.Range(5,10));
        spawnPowerup = true;
    }//pretty short interval, makes it so you can upgrade your ship a bunch. will probably tweak later if i work on this again.

}
