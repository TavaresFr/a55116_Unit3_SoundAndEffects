using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    //Step 3.1.3
    //void Start()
    //{
    //    playerRb = GetComponent<Rigidbody>();
    //    playerRb.AddForce(Vector3.up * 1000);
    //}

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
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

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter (Collision collision)
    {
        isOnGround = true;
    }
}
