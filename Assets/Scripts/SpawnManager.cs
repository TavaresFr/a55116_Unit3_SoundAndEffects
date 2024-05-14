using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    [SerializeField]private float startDelay = 2;
    [SerializeField]private float repeatRate = 2;
    private PlayerControler playerControlerScript;

    void Start()
    {
        //Step 3.1.9
        //Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);

        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControlerScript = GameObject.Find("Player").GetComponent<PlayerControler>();

    }

    void SpawnObstacle()
    {
        //Step 3.1.9
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);

        /*if(playerControlerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }*/
    }
}
