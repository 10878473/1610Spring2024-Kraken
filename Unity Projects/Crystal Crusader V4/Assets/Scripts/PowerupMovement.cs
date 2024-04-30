using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PowerupMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 20;
    public int powerupNum; // assigned per prefab, based off colors
     
    void Start()
    {
        
    }
    void Awake(){
        var orbRenderer = gameObject.GetComponent<Renderer>();
        powerupNum = Random.Range(4,7);
        switch (powerupNum)
        {
            case 1:        
            orbRenderer.material.SetColor("_Color", Color.red);// laser swarm
            break;
            case 2:        
            orbRenderer.material.SetColor("_Color", Color.grey);//grey rain
            break;
            case 3:        
            orbRenderer.material.SetColor("_Color", Color.blue);//blue mirror special
            break;
            case 4:        
            orbRenderer.material.SetColor("_Color", Color.black);//burst
            break;
            case 5:        
            orbRenderer.material.SetColor("_Color", Color.white);//white / silver helix
            break;
            case 6:        
            orbRenderer.material.SetColor("_Color", Color.yellow);//wide spam?
            break;

            
            
        }

    }

    // Update is called once per frame
    //when spawned - Move towards screen, slow down when it reaches the area where the player can grab it, then 
    //destroys itself when it cannot be grabbed
    void Update()
    {
      
        if(transform.position.z > 15){
            transform.Translate(Vector3.back* speed * Time.deltaTime);//moves toward screen
        } else if (transform.position.z> 0 && transform.position.z <=15){transform.Translate(Vector3.back* speed/4 * Time.deltaTime);}// slows down
        else if (transform.position.z < 0)
        {
            Destroy(gameObject);
        }
      
    }
    

}
