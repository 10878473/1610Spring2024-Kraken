using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed*Vector3.forward*Time.deltaTime);
    }
    private void OnCollisionEnter(Collision other){
      Destroy(other.gameObject);
      Destroy(gameObject);
        
    }
}
