using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private Animator playerAnim;
    public bool gameOver = false;
    public float jumpForce;
    public float gravityMod;
    private Rigidbody playerRB;
    public bool isOnGround = true;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMod;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            dirtParticle.Stop();
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }    
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();

        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("GAME OVER!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
       
    }
}
