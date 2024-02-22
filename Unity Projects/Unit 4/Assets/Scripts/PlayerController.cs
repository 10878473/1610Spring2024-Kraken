using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float velocityF =0;
    public float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movement ------------------------------------------------------------------
        if (Input.GetAxis("Vertical") != 0 ){
            
            if (MathF.Abs(velocityF) < maxSpeed)
            {
                velocityF += 0.25f * Input.GetAxis("Vertical");
            }
        }else
        {
            velocityF -= Mathf.Lerp(velocityF , 0f, 0.9f);
        }
        Debug.Log("Forwardby" + Input.GetAxis("Vertical"));
        Debug.Log("Velocity"+velocityF);
        Debug.Log("Lerp"+Mathf.Lerp(velocityF , 0f, 0.75f));
        //Forward movement 
        transform.Translate(Vector3.forward * Time.deltaTime * velocityF);
        
        //Rotation
        if(velocityF != 0){
            transform.Rotate(0f,Input.GetAxis("Horizontal")*MathF.Abs(velocityF*0.1f),0f,Space.Self);

        }
    }
}
