using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private float bound = 35;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate( new Vector3(0f,0f,1f));
        if (transform.position.z> bound)
        {
            Destroy(gameObject);
        }

    }
}
