using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //Scripting plan - Player controller for movement, limited to a decently sized box, and eventually have the ship move fluidly, based on a target position. also shooting based on screen targeting
    // the idea i really want to do is have the camera and gameplay change at parts of the game, like boss fights. 

    //idea one - It works more like a gallery shooter game until the enemies get close enough, then it quickly turns to an asteroids type game. with top down camera.
    //then turns into FPS or roating around a circle style controls in boss fight stage 
    // 
    // UNUSED AIMING SCRIPT 
    public Vector3 screenPosition;//Mouse position on screen
    public Vector3 worldPosition;//position mouse is aiming at in world
    private float turnspeed = 0.1f; 

    //types of powerups - 1 - Silver Slicer, 2- Burst, 3-Super rapid fire, 4- Laser blast, 5- grey rain
    public string firingType;
    private Vector3 moveVector;
    private float speed = 50;
    private Vector2 bounds = new Vector2(40, 25);
    private bool canFire = true;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    private bool bulletAlternating;

    private GameObject playerTip;

    public float currentCooldown;

    public int hp;
    public TextMeshProUGUI hpText;
    public ParticleSystem explosionParticle;
    private bool aimWithMouse = true;
    public ScoreManager ScoreManager;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager = GameObject.Find("ManagersGoHere").GetComponent<ScoreManager>();
        hp = 50;
        playerTip = GameObject.Find("playerTip");
        firingType = "Rapid";
        currentCooldown = 0.125f;
    }

    // Update is called once per frame
    void Update()


    {
         //Aiming Rotation code -------------------
        if (ScoreManager.BossTime)
        {
            aimWithMouse = false;
        }
        if (aimWithMouse)
        {
            screenPosition = Input.mousePosition; //gets screen position of mouse
            Ray ray = Camera.main.ScreenPointToRay(screenPosition);//Shoots a beam from camera to mouse point
            if (Physics.Raycast(ray, out RaycastHit hitData)){
                worldPosition = hitData.point;//world position is where we want to aim the player at.
                var direction = (worldPosition - transform.position).normalized;//takes  target direction
                var rotGoal = Quaternion.LookRotation(direction);// makes a quaternion for the direction
                var lerped = Quaternion.Slerp(transform.rotation, rotGoal, turnspeed); // Smoothly Lerps towards it.
                transform.rotation = lerped; // makes player aim at point. TODO- Change it so it moves smoothly.
                //Debug.Log("Direction_"+direction+"<Rotating by");
            } 
        }else
        {
            transform.rotation = new Quaternion(0, 0, 0,0);
        }
        
        //else{Debug.Log(screenPosition+"No position?");}//This runs when it doesn't aim at anything. Not needed right now as it keeps its current angle.
        
        // this will change based on game state later 
        moveVector.x = Input.GetAxis("Horizontal");//gets a vector direction of what direction player wants to move in 
        moveVector.y = Input.GetAxis("Vertical");
        transform.position += moveVector * speed * Time.deltaTime;
        // Keeps character in bounding box -----
        if (transform.position.x > bounds.x)
        {//for right edge
            transform.position = new Vector3(bounds.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -bounds.x)
        {//Left edge
            transform.position = new Vector3(-bounds.x, transform.position.y, transform.position.z);
        }
        if (transform.position.y > bounds.y)
        {//top edge
            transform.position = new Vector3(transform.position.x, bounds.y, transform.position.z);
        }
        if (transform.position.y < -bounds.y)
        {//bottom edge
            transform.position = new Vector3(transform.position.x, -bounds.y, transform.position.z);
        }


        
        //Fire with mouse1/fire
        if(Input.GetAxis("Fire1") > 0 && canFire){        
            if (firingType == "Rapid"){// || means or
                //Debug.Log("PEW!");//Creates bullet, Aims in correct direction, and waits until it can shoot agin. Offset of 14 will need to change if size of player changes.
                if (bulletAlternating){Instantiate(bulletPrefab, playerTip.transform.position,  transform.rotation);
                bulletAlternating = false;}
                else {Instantiate(bulletPrefab2, playerTip.transform.position, transform.rotation);
                bulletAlternating = true;}//Alternates between 2 bullet visuals for fun.

                canFire = false;
                StartCoroutine(ShootCooldown());
            }
            if (firingType == "Burst"){// || means or
                //Debug.Log("PEW!");//Creates bullet, Aims in correct direction, and waits until it can shoot agin. Offset of 14 will need to change if size of player changes.
                for (int i = 0; i < 8; i++)
                {
                    if (bulletAlternating){Instantiate(bulletPrefab, playerTip.transform.position,  transform.rotation);
                    bulletAlternating = false;}
                    else {Instantiate(bulletPrefab2, playerTip.transform.position, transform.rotation);
                    bulletAlternating = true;}//Alternates between 2 bullet visuals for fun.

                }
                
                canFire = false;
                StartCoroutine(ShootCooldown());
            }
            
            if (firingType == "Super-Rapid"){
                //Debug.Log("PEW!");//Creates bullet, Aims in correct direction, and waits until it can shoot agin. Offset of 14 will need to change if size of player changes.
                Instantiate(bulletPrefab2, playerTip.transform.position, transform.rotation);
                canFire = false;
                StartCoroutine(ShootCooldown());
            }
        }        
        if(Input.GetKey("1")){
            firingType = "Rapid";
            currentCooldown = 0.125f;
            Debug.Log("Firing type = " + firingType);
        }
        if(Input.GetKey("2")){
            firingType = "Burst";
            currentCooldown = 0.3f;
            Debug.Log("Firing type = " + firingType);
        }
        if(Input.GetKey("3")){
            firingType = "Super-Rapid";
            currentCooldown = 0.01f;
            Debug.Log("Firing type = " + firingType);
        }
        
    }
    IEnumerator ShootCooldown(){//Bullet cooldown will vary based on type of powerup that you have
        yield return new WaitForSeconds(currentCooldown);
        canFire = true;
    }
    private void OnTriggerEnter(Collider other){//upon picking up powerup, change firing type, cooldown, and bullet spread
        if (other.gameObject.CompareTag("Powerup")){//
            switch (other.GetComponent<PowerupMovement>().powerupNum)
            {
                case 4:
                firingType = "Burst";
                currentCooldown = 0.3f;
                bulletPrefab.GetComponent<Bullet>().bulletSpread = 10f;
                StartCoroutine("PowerupCoolDown");
                break;
                case 5:
                firingType = "Burst";
                currentCooldown = 0.3f;
                bulletPrefab.GetComponent<Bullet>().bulletSpread = 20f;
                StartCoroutine("PowerupCoolDown");

                break;
                case 6:
                firingType = "Super-Rapid";
                currentCooldown = 0.01f;
                bulletPrefab.GetComponent<Bullet>().bulletSpread = 1f;
                StartCoroutine("PowerupCoolDown");

                break;
            }
            Destroy(other.gameObject);
            //TODO - add visual indicator of damage being taken
            
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            hp -= 2;
            Destroy(other.gameObject);
            hpText.text = "HP: " + hp;
            explosionParticle.Play();

        }
    }
    IEnumerator PowerupCoolDown(){
        yield return new WaitForSeconds(8);
        currentCooldown = 0.125f;
        firingType = "Rapid";
        bulletPrefab.GetComponent<Bullet>().bulletSpread = 5f;
    }

}
