using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Behavior : MonoBehaviour
{

    // Generic boss code - HP
    public int hp = 250;
    public bool canShoot = true;
    public GameObject laser;
    public float spreadstep;
    public Quaternion currentAngle;
    private float spreadmax;
    private int rotatedlinedeg;
    private float currentCooldown;
    void Start()
        {
        spreadmax = 5;

        }
    
    // Update is called once per frame
    void Update()
    {
        if(hp > 100 &&  canShoot == true){//regular attack and movement pattern
                for (int b = 0; b < 3; b++)
                {
                    rotatedlinedeg = Random.Range(0,360);//horizontal rotation of the spread of bullets
                    spreadstep = 45f/spreadmax;//splits the spread of bullets evenly between the firing arc(I have changed the arc a few times and it could change in game later)
                    for (int i = 0; i < spreadmax; i++)
                    {
                        currentAngle = Quaternion.Euler(Vector3.forward * spreadstep*i -new Vector3(rotatedlinedeg,270,-75));//this math took a while to fine tune.
                        Instantiate(laser,transform.position + Vector3.back*30f, currentAngle);

                    }
                    
                }
                
                canShoot = false;
                currentCooldown = Random.Range(2,4);
                StartCoroutine("bossCooldown");
            
        }else if (hp < 100 && canShoot == true)
        {
                    rotatedlinedeg = Random.Range(0,360);//horizontal rotation of the spread of bullets
                    
                        currentAngle = Quaternion.Euler(Vector3.forward  -new Vector3(rotatedlinedeg,270,Random.Range(-75,0)));//this math took a while to fine tune.
                        Instantiate(laser,transform.position + Vector3.back*30f, currentAngle);

                    
                    canShoot = false;
                    currentCooldown = .1f;
                    StartCoroutine("bossCooldown");
        }
        if (hp < 0){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other){
        
        
        if (other.gameObject.CompareTag("Bullet")){
            hp --;
            //Debug.Log(gameObject.name + "HP:"+hp);
            Destroy(other.gameObject);
            //TODO - add visual indicator of damage being taken
            
        }

    }
    IEnumerator bossCooldown(){
        yield return new WaitForSeconds(currentCooldown);
        canShoot = true;
    }
    
}
