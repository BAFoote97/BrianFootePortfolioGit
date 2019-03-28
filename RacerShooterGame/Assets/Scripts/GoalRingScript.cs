using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalRingScript : MonoBehaviour {

	public SceneRefScript sceneRef;
	public List<GameObject> KnownPlayers = new List<GameObject>();
	public int currentPlayers;

	public GameObject myTrack;

	public bool ringActive;

	public GameObject myPicker;

	// Use this for initialization
	void Start () {
		sceneRef = GameObject.FindObjectOfType<SceneRefScript> ();
		PlayerCheck ();
		myPicker = null;
		ringActive = true;
		
	}

	void PlayerCheck(){
		if (sceneRef.Players.Count == KnownPlayers.Count) {
			return;
		}
		if (sceneRef.Players.Count > KnownPlayers.Count) {
			KnownPlayers.Add (sceneRef.Players [currentPlayers]);
			currentPlayers += 1;
			PlayerCheck ();
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){


		if (other.gameObject.GetComponent<PlayerScript> () == true) {
			
			myPicker = other.gameObject;


			KnownPlayers.Remove (myPicker);
			RingTaken ();
//			if (other.gameObject.GetComponent<PlayerScript> ().otherPlayer != null) {
//				other.gameObject.GetComponent<PlayerScript> ().otherPlayer.GetComponent<PlayerScript> ().myPoints -= 1;
//			}
		}

	}

	public void RingTaken(){
		ringActive = false;
		gameObject.GetComponent<MeshRenderer> ().enabled = false;
		gameObject.GetComponent<BoxCollider> ().enabled = false;
		myPicker.GetComponent<PlayerScript> ().myPoints += 1;
		Debug.Log ("Point gained for " + myPicker);
		LosePoints ();
	}

	public void LosePoints(){
		if(KnownPlayers.Count > 0 && KnownPlayers[0] == null){
			
			KnownPlayers.Remove (KnownPlayers [0]);
			LosePoints ();
		}
		if(KnownPlayers.Count > 0 && KnownPlayers[0] != null){
			KnownPlayers[0].GetComponent<PlayerScript> ().LosePoint ();
			KnownPlayers.Remove (KnownPlayers [0]);
			LosePoints ();
		}
	}

}
