using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {

	public float HP;
	public float damageGive;

	public GameObject boomFX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (HP <= 0) {
			SpawnBoom ();
			Destroy (gameObject);
		}
		
	}

	public void SpawnBoom(){
		GameObject temporaryBoomHandler;

		temporaryBoomHandler = Instantiate(boomFX, gameObject.transform.position, gameObject.transform.localRotation) as GameObject;
		temporaryBoomHandler.transform.localScale = gameObject.transform.localScale;
	}

	void OnTriggerEnter(Collider other){
		if (other.GetComponent<PlayerScript>() == true && other.GetComponent<PlayerScript>().noClip == false) {
			SpawnBoom ();
			other.GetComponent<PlayerScript> ().myHP -= damageGive;
			Destroy (gameObject);
		}
	}
}
