using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
// using 

public class PlayerController : MonoBehaviour
{
    //Scripting plan - Player controller for movement, limited to a decently sized box, and eventually have the ship move fluidly, based on a target position. also shooting based on screen targeting
    // the idea i really want to do is have the camera and gameplay change at parts of the game, like boss fights. 

    //idea one - It works more like a gallery shooter game until the enemies get close enough, then it quickly turns to an asteroids type game. with top down camera.
    //then turns into FPS or roating around a circle style controls in boss fight stage 
    // 
    // UNUSED AIMING SCRIPT 
    //public Vector3 screenPosition;//Mouse position on screen
    //public Vector3 worldPosition;//position mouse is aiming at in world
    //private float turnspeed = 0.1f; 

    private Vector3 moveVector;
    private float speed = 50;
    private Vector2 bounds = new Vector2(40, 25);
    private bool canFire = true;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    private bool basicBulletType;

    private GameObject playerTip;

    public float currentCooldown = 0.125f;
    // Start is called before the first frame update
    void Start()
    {
        playerTip = GameObject.Find("playerTip");
    }

    // Update is called once per frame
    void Update()
    {
        /* //Aiming Rotation code -------------------
        screenPosition = Input.mousePosition; //gets screen position of mouse
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);//Shoots a beam from camera to mouse point
        if (Physics.Raycast(ray, out RaycastHit hitData)){
            worldPosition = hitData.point;//world position is where we want to aim the player at.
            var direction = (worldPosition - transform.position).normalized;//takes  target direction
            var rotGoal = Quaternion.LookRotation(direction);// makes a quaternion for the direction
            var lerped = Quaternion.Slerp(transform.rotation, rotGoal, turnspeed); // Smoothly Lerps towards it.
            transform.rotation = lerped; // makes player aim at point. TODO- Change it so it moves smoothly.
            //Debug.Log("Direction_"+direction+"<Rotating by");
        } */
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
            //Debug.Log("PEW!");//Creates bullet, Aims in correct direction, and waits until it can shoot agin. Offset of 14 will need to change if size of player changes.
            if (basicBulletType){Instantiate(bulletPrefab, playerTip.transform.position, transform.rotation);
            basicBulletType = false;}
            else {Instantiate(bulletPrefab2, playerTip.transform.position, transform.rotation);
            basicBulletType = true;}//Alternates between 2 bullet visuals for fun.

            canFire = false;
            StartCoroutine(ShootCooldown());

        }        
        
        IEnumerator ShootCooldown(){//Bullet cooldown will vary based on type of powerup that you have
        yield return new WaitForSeconds(currentCooldown);
        canFire = true;
    }

    }
}
