using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float bounds = 20f;
    public float speed = 7f;
    public GameObject laser;
    private float spread;
    private bool canFire;
    private float spreadstep;
    private int spreadmax;
    private float firingArc = 120;
    public GameManager gameManager;
    private AudioSource pew;
    // Start is called before the first frame update
    void Start()
    {
        pew = gameObject.GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spreadmax = 3;
        canFire = true; 
        //sets spread of gun at start and can fire
    }

    // Update is called once per frame
    void Update()
    {
        //moves within bounds
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
        //shoots with a cooldown
        if(Input.GetAxis("Fire1")>0){
            if (canFire == true && !gameManager.isgameOver){

                spread = Random.Range(1, spreadmax);
                Debug.Log("Pew!");
                pew.Play();
                
                //shoots a spread of bullets.
                if (spread ==1){
                    Instantiate(laser,transform.position + Vector3.forward, laser.transform.rotation);
                }
                else{
                    spreadstep = firingArc/spread;//splits the spread of bullets evenly between the firing arc(I have changed the arc a few times and it could change in game later)
                    for (int i = 0; i < spread; i++)
                    {
                    Quaternion currentAngle = Quaternion.Euler(Vector3.up * spreadstep*i -new Vector3(0,45,0));//this math took a while to fine tune.
                    //Debug.Log(currentAngle.y);
                    Instantiate(laser,transform.position + Vector3.forward*1.5f, currentAngle);
                    //StartCoroutine("SpreadCooldown");
                    }
                }
                canFire = false;
                StartCoroutine("Cooldown");
            }
            
        }
    }
    IEnumerator Cooldown(){
        yield return new WaitForSeconds(.5f);
        canFire = true;//simple firing cooldown
    }

    //couldnt figure out WaitUntil type code
    //IEnumerator SpreadCooldown(){
    //    yield return new WaitForSeconds(.25f);

    //}
    private void OnTriggerEnter(Collider other){
        
        //Pickup Powerup to increase spread
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            spreadmax++;
            //Debug.Log("Current Power: " + spreadmax);
        }
    }
}
