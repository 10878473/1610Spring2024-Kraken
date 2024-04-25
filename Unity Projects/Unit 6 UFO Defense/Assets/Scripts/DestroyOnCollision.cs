using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {        

        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    void Awake(){   
             
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other){
        //Debug.Log("Blam! hit " + other.gameObject.CompareTag("UFO"));

        if (other.gameObject.CompareTag("UFO"))
        {        
            Debug.Log("BANG");
            scoreManager.increaseScore(1);
                
            Destroy(gameObject);
            Destroy(other.gameObject);

        }
    }
}
