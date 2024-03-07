using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    private float bound = -35;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {   
        speed = Random.Range(0.05f, 0.15f);
        transform.Rotate(new Vector3(0f,180,0f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0f,0f, speed));
        if (transform.position.z < bound){
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
