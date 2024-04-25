using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > 500 ||transform.position.z < -10 || Math.Abs(transform.position.y) > 150 ||Math.Abs(transform.position.x)> 200){
            Destroy(gameObject);
        }
    }
}
