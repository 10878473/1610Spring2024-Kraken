using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //define variables here
    float Speed = 5f;
    public float defaultspeed = 5f;
    public float jumpforce = 0.5f;
    float gravity = -9.8f;
    private CharacterController controller;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    bool isJumping;
    Vector3 movevector = new Vector3(0f,0f,0f);
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    public bool isCrouching;
    
    // Start is called before the first frame update
    void Start()
    {
        //attach Unity objects to variables here
        controller = gameObject.GetComponent<CharacterController>();

        Debug.Log("Hello world!");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(controller.isGrounded);
        //Ground movement
        //gets a vector direction of what direction player wants to move in 
        movevector.x = Input.GetAxis("Horizontal");
        movevector.z = Input.GetAxis("Vertical");
        movevector.y += gravity * Time.deltaTime;// simulates gravity right now 

        //Jumping
        



        
        if (controller.isGrounded && movevector.y < 0){
            movevector.y = 0f;
        }
        if (Input.GetAxis("Jump")>0f && controller.isGrounded && !isCrouching)//check if you can jump 
        {
            isJumping = true;
        }else
        {
            isJumping = false;   
        }
        if (isJumping)//seperates the check from the action
        {
            movevector.y += Mathf.Sqrt(jumpforce * -0.1f * gravity);
        }
        Debug.Log(movevector.y);
        Debug.Log("Jumping ="+isJumping);
        Debug.Log("Grounded? =  " + controller.isGrounded);
        if(movevector.magnitude >= 0.1f){
            controller.Move(Speed*movevector*Time.deltaTime);
            
        }
        
        // Rotation code
        screenPosition = Input.mousePosition; //gets screen position of mouse
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);//Shoots a beam from camera to mouse point
        if (Physics.Raycast(ray, out RaycastHit hitData/*, Mathf.Infinity, groundMask*/)){
            worldPosition = hitData.point;
            Debug.Log(worldPosition);
        }

        float targetAngle = (Mathf.Atan2(transform.position.x - worldPosition.x, transform.position.z - worldPosition.z) * Mathf.Rad2Deg) -180;//targets that point 
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);//rotates player smoothly using math stuff<-^
        //Crouching code 
        if (Input.GetAxis("Crouch") > 0f ){
            isCrouching = true;
            Speed = defaultspeed *0.5f;//slows you down
            controller.height=.5f;//makes collider smaller instantly
            //animates the visual
            if (transform.localScale.y > 0.25f){
                Vector3 changey = new Vector3(0f,-0.1f, 0f);
                transform.localScale += changey;
            }
        }else
        {
            isCrouching = false; 
            Speed = defaultspeed;
            //controller.Move(new Vector3(0,1,0)); isnt needed, but crouching is a lil buggy
            controller.height=2;
            Vector3 changey = new Vector3(0f,0.1f, 0f);
            if (transform.localScale.y < 1f){
                transform.localScale += changey;
            }
        }
        //Sprinting code
        if (Input.GetAxis("Sprint") > 0f && !isCrouching)//simple sprint if pushing button and not crouching
        {
            Speed = defaultspeed *2;//simply doubles the speed based off of default
        } else
        {
            Speed = defaultspeed;
        }

        //Optional - Double jump? Wall run/jump
    }
}
