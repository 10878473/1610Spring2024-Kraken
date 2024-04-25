using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 75f;
    // Start is called before the first frame update
    private float bulletSpread = 5f;
    private Vector3 bulletSpreadVector;
    void Start()
    {
        
    }
    void Awake(){
        bulletSpreadVector = new Vector3(Random.Range(-bulletSpread,bulletSpread),Random.Range(-bulletSpread,bulletSpread),0);
        transform.Rotate(bulletSpreadVector);
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
    }
}
