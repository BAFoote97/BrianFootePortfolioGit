using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour {

    public GameObject gamePlayer;

    public bool playerInBoundary;
    public float timeLeft;

    public float maxTime = 10;

	// Use this for initialization
	void Start () {
        playerInBoundary = false;

	}
	
	// Update is called once per frame
	void Update () {
        //if (playerInBoundary == false)
        //{
        //    timeLeft -= Time.deltaTime;
        //}
        //if (timeLeft < 0)
        //{
        //    GameOver();
        //}

        //if (playerInBoundary == true)
        //{
        //    timeLeft = maxTime;
        //}
    }

    void OnTriggerEnter(Collider playerObject)
    {
        Debug.Log(playerObject);
        if (playerObject == gamePlayer)
        {
            playerInBoundary = true;
            Debug.Log("Player is in the boundary");
        }
    }
    void OnTriggerExit(Collider playerObject)
    {
        if (playerObject == gamePlayer)
        {
            playerInBoundary = false;
            Debug.Log("Player has left the boundary");
        }
    }

    public void GameOver()
    {
        Debug.Log("Mission failed");
    }
}
