using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    private AudioSource playerAudio;
    public AudioClip crashSound;
    //Step 3.1.3
    //void Start()
    //{
    //    playerRb = GetComponent<Rigidbody>();
    //    playerRb.AddForce(Vector3.up * 1000);
    //}

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Step 3.1.4
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    playerRb.AddForce(Vector3.up * 100 , ForceMode.Impulse);
        //}

        //Step 3.1.5
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //}

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Step 3.1.6
        //isOnGround = true;

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }

    }
}
