using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject powerupIndicator;
    private float powerupStrength = 15.0f;
    public bool hasPowerup;
    private Rigidbody playerRb;
    public float speed = 5.0f;
    private GameObject focalPoint;
    // Start is called before the first frame update
    void Start()
    {
        
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {   // only moves forward or back based off of camera angle
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0,-0.5f,0);//indicator tied to player
    }
    private void OnTriggerEnter(Collider other){//turns on powerup mode, turns on indicator
        if (other.CompareTag("Powerup")){
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }
    private void OnCollisionEnter(Collision collision){//knocks enemy farther away if you have powerup
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Debug.Log("Collided with "+ collision.gameObject.name + " with powerup? = " + hasPowerup);
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayfromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayfromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
    IEnumerator PowerupCountdownRoutine(){// powerup lasts 7 seconds
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
