using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other){
        Debug.Log("Blam! hit " + other.gameObject.CompareTag("UFO"));

        if (other.gameObject.CompareTag("UFO"))
        {
            Debug.Log("Why isnt this being destroyed!");
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
