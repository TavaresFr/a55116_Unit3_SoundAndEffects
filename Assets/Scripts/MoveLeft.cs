using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 10;
    private PlayerControler playerControlerScript;
    private float leftBound = -15;

    void Start()
    {
        playerControlerScript = GameObject.Find("Player").GetComponent<PlayerControler>();
    }


    void Update()
    {
        if (playerControlerScript.gameOver != false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

    }
}
