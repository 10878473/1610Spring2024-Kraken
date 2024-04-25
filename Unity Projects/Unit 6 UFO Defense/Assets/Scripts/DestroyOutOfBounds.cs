using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    public ScoreManager scoreManager;
    private int bound = 50;
    
    void Start()
    {
       
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > bound){
            Destroy(gameObject);
        }
        if(transform.position.x < -bound){
            Destroy(gameObject);
        }
        if(transform.position.z > bound){
            Destroy(gameObject);
        }
        if(transform.position.z < -2){
            Destroy(gameObject);
            if (gameObject.CompareTag("UFO"))
            {
                scoreManager.decreaseScore(5);


            }
            
        }
    }
}
