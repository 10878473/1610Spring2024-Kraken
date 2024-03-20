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

    public Vector3 screenPosition;//Mouse position on screen
    public Vector3 worldPosition;//position mouse is aiming at in world

    private Vector3 moveVector;
    private float speed = 50;
    private Vector2 bounds = new Vector2(40, 25);
    private float turnspeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Aiming Rotation code -------------------
        screenPosition = Input.mousePosition; //gets screen position of mouse
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);//Shoots a beam from camera to mouse point
        if (Physics.Raycast(ray, out RaycastHit hitData)){
            worldPosition = hitData.point;//world position is where we want to aim the player at.
            var direction = (worldPosition - transform.position).normalized;//takes  target direction
            var rotGoal = Quaternion.LookRotation(direction);// makes a quaternion for the direction
            var lerped = Quaternion.Slerp(transform.rotation, rotGoal, turnspeed); // Smoothly Lerps towards it.
            transform.rotation = lerped; // makes player aim at point. TODO- Change it so it moves smoothly.
            //Debug.Log("Direction_"+direction+"<Rotating by");
        }else{Debug.Log(screenPosition+"No position?");}//This shouln't run but just in case for troubleshooting
        
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

        

    }
}
