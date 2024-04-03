using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Rigidbody targetRb;
    
    //Seperating random forces and positions into seperate groups pt 1
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float absmaxTorque = 10;
    private float xRange = 4;
    private float ySpawnpos = -6;
    private GameManager gameManager;
    public int pointValue;
    
    public GameObject explosion;
    
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();//gets the script from the game manager

        //seperated random forces and positions into groups/functions pt 2
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(),ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Groups of functions for random starting postions and forces
    Vector3 RandomForce(){
        return Vector3.up*Random.Range(minSpeed,maxSpeed);
    }
    float RandomTorque(){ return Random.Range(-absmaxTorque, absmaxTorque);
    }
    Vector3 RandomSpawnPos(){
        return new Vector3(Random.Range(-xRange,xRange), ySpawnpos);
    }
    private void OnMouseDown(){
        if (gameManager.isGameActive)
        { 
            gameManager.UpdateScore(pointValue);
        }
        //kept these lines outside of game active check so you can still pop the last food to make an explosion even if you have lost, because it would be more fun and doesn't affect score.
        Destroy(gameObject);
        Instantiate(explosion, transform.position, explosion.transform.rotation);
        
    }
    private void OnTriggerEnter(Collider other){
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }

    }
}
