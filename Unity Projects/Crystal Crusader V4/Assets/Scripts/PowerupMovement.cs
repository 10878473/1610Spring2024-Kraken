using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PowerupMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    void Start()
    {
        speed = 1;
        move();
    }

    // Update is called once per frame
    //when spawned - Move towards screen, slow down when it reaches the area where the player can grab it, then 
    //destroys itself when it cannot be grabbed
    void Update()
    {
      
        
      
    }
    private void move(){
    switch (transform.position.z)
      {
        case > 15:
        while (transform.position.z > 15){transform.Translate(Vector3.back* speed * Time.deltaTime);}
        Debug.Log("Moved1");
        move();
        break;  
        case float i when (i> 0 && i <=15):
        while (transform.position.z >= 0){transform.Translate(Vector3.back* speed/4 * Time.deltaTime);}//slows down when it gets close
        Debug.Log("Moved2");
        move();
        break;
        case < 0:
        Debug.Log("Moved3");
        Destroy(gameObject);
        break;
        }
    }

}
