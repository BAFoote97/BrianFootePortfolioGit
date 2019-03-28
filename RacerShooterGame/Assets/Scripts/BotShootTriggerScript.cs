using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotShootTriggerScript : MonoBehaviour {

	public GameObject myPlayer;
	public List<GameObject> ShootTargets = new List<GameObject> ();



	void OnTriggerStay (Collider other){
		if (other.gameObject.tag == "ObstacleTag" || other.gameObject.GetComponent<PlayerScript>() == true && other.gameObject != myPlayer) {
			ShootTargets.Add (other.gameObject);
		}
	}

	void LateUpdate(){
		//ShootTargets.Clear();
	}
}
