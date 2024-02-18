using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //define variables here
    public float Speed = 5f;
    public float jumpforce = 0.5f;
    float gravity = -9.8f;
    private CharacterController controller;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    bool isJumping;
    Vector3 movevector = new Vector3(0f,0f,0f);


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
        //Ground movement
        //gets a vector direction of what direction player wants to move in 
        movevector.x = Input.GetAxis("Horizontal");
        movevector.z = Input.GetAxis("Vertical");
        movevector.y += gravity * Time.deltaTime;// simulates gravity right now 

        //Jumping
        if (controller.isGrounded && movevector.y < 0){
            movevector.y = 0f;
        }
        if (Input.GetAxis("Jump")>0f && controller.isGrounded)
        {
            isJumping = true;
        }else
        {
            isJumping = false;   
        }
        if (isJumping)
        {
            movevector.y += Mathf.Sqrt(jumpforce * -0.1f * gravity);
        }
        Debug.Log(movevector.y);
        Debug.Log("Jumping ="+isJumping);
        Debug.Log("Grounded? =  " + controller.isGrounded);
        if(movevector.magnitude >= 0.1f){
            controller.Move(Speed*movevector*Time.deltaTime);
            //Followed a youtube tutorial to get some smooth rotation
            float targetAngle = Mathf.Atan2(movevector.x, movevector.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);//rotates player smoothly using math stuff
        }
        

    }
}
