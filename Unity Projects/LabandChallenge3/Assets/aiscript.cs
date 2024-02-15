using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiscript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f; // Adjust the movement speed as needed
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from arrow keys or WASD
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        //Debug.Log(movement);
        // Apply movement to the player
        rb.MovePosition(transform.position + movement);
    }
}
