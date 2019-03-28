using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashScript : MonoBehaviour {

    public GameObject playerObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ColObject")
        {
            Debug.Log("Player has crashed");
            playerObject.GetComponent<PlayerStatsScript>().hullHP = 0;
        }
    }
}
