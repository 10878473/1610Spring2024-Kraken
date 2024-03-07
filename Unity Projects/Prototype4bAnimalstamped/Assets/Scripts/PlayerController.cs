using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float h_input;
    public float v_input;
    public float boundingbox = 25;
    public float Speed = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h_input = Input.GetAxis("Horizontal");
        v_input = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(h_input*Speed, 0f, v_input * Speed));
        // IF the player tries to go out of bounds, put them back in the bounds
        if (transform.position.x > boundingbox)
        {//for right edge
            transform.position = new Vector3(boundingbox, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -boundingbox)
        {//Left edge
            transform.position = new Vector3(-boundingbox, transform.position.y, transform.position.z);
        }
        if (transform.position.z > boundingbox)
        {//top edge
            transform.position = new Vector3(transform.position.x, transform.position.y, boundingbox);
        }
        if (transform.position.z < -boundingbox)
        {//bottom edge
            transform.position = new Vector3(transform.position.x, transform.position.y, -boundingbox);
        }
        //Fire pizza projectile script
        if(Input.GetKeyDown(KeyCode.Space)){
            Vector3 newPos = new Vector3(transform.position.x, 1, transform.position.z);
            Instantiate(projectilePrefab, newPos, projectilePrefab.transform.rotation);
        }
    }
}
