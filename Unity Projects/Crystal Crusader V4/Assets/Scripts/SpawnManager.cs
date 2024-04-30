using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] meteors;
    public GameObject powerup;
    public GameObject spiker;
    private int wavetimer = 15;
    private bool waveCanSpawn = true;
    private int difficulty = 2;

    public ScoreManager ScoreManager;
    void Start()
    {
        ScoreManager = GameObject.Find("ManagersGoHere").GetComponent<ScoreManager>();
        //spawn waves of meteors 

        

    }
   
    // Update is called once per frame
    void Update()
    {
        //if gamerunning to add later.
        if (waveCanSpawn && !ScoreManager.BossTime)
        {
            SpawnWave();
            StartCoroutine("waveCooldown");
            waveCanSpawn = false;
            Debug.Log("Spawned wave at Difficulty " + difficulty);
        }
    }
    private Vector3 pointInZone(){
        Vector3 point = new Vector3(Random.insideUnitCircle.x * 40, Random.insideUnitCircle.y * 25, Random.Range(400,500));
        return point;
    }
    //Spawn area X/Y -150 to 150 Z 400-500
     IEnumerator waveCooldown(){
        yield return new WaitForSeconds(wavetimer);
        waveCanSpawn = true;
    }
    void SpawnWave(){
        //spawn a bunch of meteors, some enemies, and a powerup for each wave
        for (int i = 0; i < Random.Range(8,difficulty*4); i++)
        {
            Instantiate(meteors[Random.Range(0,meteors.Length +1)], pointInZone(),Random.rotation);
        }
        for (int i = 0; i < Random.Range(2,difficulty); i++)
        {
            Instantiate(spiker, pointInZone(),transform.rotation);
        }
        difficulty++;
        Instantiate(powerup, pointInZone(),transform.rotation);

    }
    
}
