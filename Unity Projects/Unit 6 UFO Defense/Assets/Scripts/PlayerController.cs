using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float bounds = 20f;
    public float speed = 7f;
    public GameObject laser;
    public int spread;
    private bool canFire;
    private float spreadstep;
    // Start is called before the first frame update
    void Start()
    {
        canFire = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal")>0){
            if(transform.position.x < bounds){
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
        if(Input.GetAxis("Horizontal")<0){
            if(transform.position.x > -bounds){
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }
        if(Input.GetAxis("Fire1")>0){
            if (canFire == true){
                spread = Random.Range(1, 10);
                //Debug.Log("Pew!");
                if (spread ==1){
                    Instantiate(laser,transform.position + Vector3.forward, laser.transform.rotation);
                }
                else{
                    spreadstep = 90/spread;
                    for (int i = 0; i < spread; i++)
                    {
                    Quaternion currentAngle = Quaternion.Euler(Vector3.up * spreadstep*i);
                    Debug.Log(currentAngle.y -45);
                    Instantiate(laser,transform.position + Vector3.forward*3, Quaternion.Euler(Vector3.up * spreadstep*i -new Vector3(0,45,0)));
                    //StartCoroutine("SpreadCooldown");
                    }
                }
                canFire = false;
                StartCoroutine("Cooldown");
            }
            
        }
    }
    IEnumerator Cooldown(){
        yield return new WaitForSeconds(1.5f);
        canFire = true;

    }
    IEnumerator SpreadCooldown(){
        yield return new WaitForSeconds(.25f);

    }
}
