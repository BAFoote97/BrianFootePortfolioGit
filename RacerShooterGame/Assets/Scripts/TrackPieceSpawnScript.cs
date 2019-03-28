using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPieceSpawnScript : MonoBehaviour {

	public SceneRefScript sceneRef;

	public bool isCurrentPiece;
	public GameObject nextPieceSpawnPoint;
	public GameObject nextPiece;
	public GameObject nextNextPiece;
	public GameObject nextNextNextPiece;

	public List <GameObject> spawnRef = new List <GameObject>();
	public int spawnsBeforeDestroy;
	public int directionNumber;

	public GameObject myRing;

	// Use this for initialization
	void Start () {
		nextPieceSpawnPoint.transform.rotation = Quaternion.identity;

		sceneRef = FindObjectOfType<SceneRefScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isCurrentPiece == true) {
			sceneRef.GetComponent<SceneRefScript> ().currentPiece = gameObject;
		}

		if (nextPiece != null && nextPiece.GetComponent<TrackPieceSpawnScript> ().nextPiece != null) {
			nextNextPiece = nextPiece.GetComponent<TrackPieceSpawnScript> ().nextPiece;
		}
		if (nextPiece != null && nextPiece.GetComponent<TrackPieceSpawnScript> ().nextNextPiece != null) {
			nextNextNextPiece = nextPiece.GetComponent<TrackPieceSpawnScript> ().nextNextPiece;
		}



		if (spawnsBeforeDestroy <= 0) {
			Destroy(gameObject);
		}




		
	}

	public void SpawnNextTrackPiece(){


		
		if (isCurrentPiece == true) {
			directionNumber = (Random.Range (1, 9));
			if (directionNumber == 5) {
				nextPieceSpawnPoint.transform.Rotate (0, 0, 0);
			}
			if (directionNumber == 1) {
				nextPieceSpawnPoint.transform.Rotate (0, Random.Range(-60,-5), Random.Range(-60,-5));
			}
			if (directionNumber == 2) {
				nextPieceSpawnPoint.transform.Rotate (0, 0, Random.Range(-60,-5));
			}
			if (directionNumber == 3) {
				nextPieceSpawnPoint.transform.Rotate (0, Random.Range(60,5), Random.Range(-60,-5));
			}
			if (directionNumber == 4) {
				nextPieceSpawnPoint.transform.Rotate (0, Random.Range(-60,-5), 0);
			}
			if (directionNumber == 6) {
				nextPieceSpawnPoint.transform.Rotate (0, Random.Range(60,5), 0);
			}
			if (directionNumber == 7) {
				nextPieceSpawnPoint.transform.Rotate (0, Random.Range(-60,-5), Random.Range(60,5));
			}
			if (directionNumber == 8) {
				nextPieceSpawnPoint.transform.Rotate (0, 0, Random.Range(60,5));
			}
			if (directionNumber == 9) {
				nextPieceSpawnPoint.transform.Rotate (0, Random.Range(60,5), Random.Range(60,5));
			}

			GameObject tempSpawn;

			tempSpawn = Instantiate (spawnRef[Random.Range (0, spawnRef.Count)], nextPieceSpawnPoint.transform.position, nextPieceSpawnPoint.transform.rotation) as GameObject;
			tempSpawn.GetComponent<TrackPieceSpawnScript> ().isCurrentPiece = true;
			tempSpawn.GetComponent<TrackPieceSpawnScript> ().spawnsBeforeDestroy = spawnsBeforeDestroy;
			nextPiece = tempSpawn;
		}
		isCurrentPiece = false;
		spawnsBeforeDestroy -= 1;
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.GetComponent<PlayerScript> () == true && isCurrentPiece == true) {
			SpawnNextTrackPiece ();
		}
	}
}
