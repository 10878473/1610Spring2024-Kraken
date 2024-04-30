using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpikerEnemy : MonoBehaviour
{
    //
    //This script will be split into multiple components once i figure out what kind of scripts can be shared
    //
    private int hp = 10;
    private int speed;
    private GameObject player;
    private ScoreManager ScoreManager;

    private int targetDist;
    private bool canFire;
    public GameObject cone;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager = GameObject.Find("ManagersGoHere").GetComponent<ScoreManager>();
        targetDist = Random.Range(20,50 );
        player = GameObject.Find("PlayerController");
        speed = Random.Range(15,30);
        Debug.Log(gameObject.name + " speed is " + speed);
        canFire = true;
    } 
    void Awake(){
        transform.Rotate(0,180,0);
    }
    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            ScoreManager.increaseScore(4);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(gameObject);
            //TODO - Explosion?
        }
        
        if(transform.position.z > targetDist)
        {
            transform.Translate(Vector3.back* speed * Time.deltaTime, Space.World);//Move towards player. Randomized based on instance?
        } else
        {

            
            
            
            //rotate towards plaeer
            transform.LookAt(player.transform);
            if (canFire)
            {
                canFire = false;
                firecones();
                StartCoroutine("cooldown");
            }
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
    private void firecones(){
        Instantiate(cone,transform.position, transform.rotation);
    }
    
    private IEnumerator cooldown(){
        yield return new WaitForSeconds(Random.Range(.5f,2));
        canFire = true;
    }
}
