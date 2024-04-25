using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PowerupMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 20;
    void Start()
    {
        
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
