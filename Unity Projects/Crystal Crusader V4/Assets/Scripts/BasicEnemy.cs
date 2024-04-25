using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    //
    //This script will be split into multiple components once i figure out what kind of scripts can be shared
    //
    private int hp = 5;
    private int speed;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerController");
        speed = Random.Range(5,20);
        Debug.Log(gameObject.name + " speed is " + speed);
    }

    // Update is called once per frame
    void Update()
    {
        //rotate towards player? sometimes
        transform.Translate(Vector3.back* speed * Time.deltaTime, Space.World);//Move towards player. Randomized based on instance?
        if (hp <= 0)
        {
            Destroy(gameObject);
            //TODO - Explosion?
        }
    }
    private void OnTriggerEnter(Collider other){
        
        Debug.Log(gameObject.name +" Collided with _" + other.gameObject.name);
        
        if (other.gameObject.CompareTag("Bullet")){
            hp --;
            Debug.Log(gameObject.name + "HP:"+hp);
            Destroy(other.gameObject);
            //TODO - add visual indicator of damage being taken
            
        }

    }
    
    
}
