using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	public SceneRefScript sceneRef;
	public List <GameObject> OtherPlayers = new List<GameObject>();
	public int currentPlayers;

	public GameObject myCam;
	public GameObject myCanvas;

	public float defSpeed;
	public float moveSpeed;
	public Text speedText;
	public int nextThresh;
	public int myThresh;
	public int prevThresh;
	public float currentAccelRate;
	public float currentDecelRate;
	public List <float> AccelRates = new List<float>();
	public List <float> DecelRates = new List<float>();
	public List <float> SpeedThreshes = new List<float> ();
	public List <float> TurnRates = new List<float> ();
	public float RotX;
	public float RotY;

	public GameObject bullet;

	public Color myColor;
	public ParticleSystem myExhaust;


	public float myHP;
	public Text HPText;
	public float myPoints;
	public Text scoreText;
	public Text otherPlayerPoints;
	public bool inSafeZone;
	public float safeZoneTimer;
	public bool outsideSafeZoneDamage;

	public GameObject deathBoomFX;
	public GameObject deathCam;

	public GameObject youWinText;

	public bool isBot;
	public GameObject botCurrentTarget;
	public float botTargetDist;
	public float botDesiredSpeed;
	public GameObject botShootZone;
	public bool botCanShoot;
	public float botShootDelay;

	public float botAccelMod;
	public float botDecelMod;
	public float botTurnMod;

	public int randomTargetPicker;

	public bool noClip;


	// Use this for initialization
	void Start () {
		if (myExhaust != null) {
			myExhaust.GetComponent<ParticleSystem> ().startColor = myColor;
		}
		if (youWinText != null) {
			youWinText.SetActive (false);
		}
		sceneRef = GameObject.FindObjectOfType<SceneRefScript> ();
		sceneRef.GetComponent<SceneRefScript> ().Players.Add (gameObject);
		Cursor.lockState = CursorLockMode.Locked;
		myHP = 100;
		moveSpeed = defSpeed;
		if (isBot == true) {
			botCanShoot = true;
		}
		PlayerCheck ();
	}
	void PlayerCheck(){
		if (sceneRef.Players.Count == OtherPlayers.Count) {
			OtherPlayers.Remove (gameObject);
			return;
		}
		if (sceneRef.Players.Count > OtherPlayers.Count) {
			OtherPlayers.Add (sceneRef.Players [currentPlayers]);
			currentPlayers += 1;
			PlayerCheck ();
		}

	}
	
	// Update is called once per frame
	void Update () {
		HPText.text = myHP.ToString ("F0");
		scoreText.text = myPoints.ToString ("F0");
//		if (otherPlayer != null) {
//			otherPlayerPoints.text = otherPlayer.GetComponent<PlayerScript> ().myPoints.ToString ("F0");
//		}
		speedText.text = (moveSpeed * 10).ToString ("F0");
		currentAccelRate = AccelRates[myThresh];
		currentDecelRate = DecelRates [myThresh];

		randomTargetPicker = Random.Range (1, 3);


		if (moveSpeed >= SpeedThreshes[nextThresh]){
			nextThresh += 1;
			myThresh += 1;
			prevThresh += 1;
		}
		if (moveSpeed <= SpeedThreshes[prevThresh]) {
			nextThresh -= 1;
			myThresh -= 1;
			prevThresh -= 1;
		}
		if (moveSpeed >= SpeedThreshes [13]) {
			moveSpeed = SpeedThreshes [13];
		}
		if (moveSpeed <= SpeedThreshes [0]) {
			moveSpeed = SpeedThreshes [0];
		}

		if (isBot == false) {
			myCam.SetActive (true);
			myCanvas.SetActive (true);
			botShootZone.SetActive (false);

			if (Input.GetKey (KeyCode.A)) {
				transform.Rotate (0, 0, 1);
			}
			if (Input.GetKey (KeyCode.D)) {
				transform.Rotate (0, 0, -1);
			}

			if (Input.GetKey (KeyCode.W)) {
				moveSpeed += currentAccelRate;
			}
			if (Input.GetKey (KeyCode.S)) {
				moveSpeed -= currentDecelRate;
			}



			RotX = Input.GetAxis ("Mouse X") * TurnRates[myThresh];
			RotY = Input.GetAxis ("Mouse Y") * -TurnRates[myThresh];
			transform.Rotate (RotY, RotX, 0);
			transform.Translate (0, 0, moveSpeed);

			if (Input.GetKeyDown ("escape"))
				Cursor.lockState = CursorLockMode.Confined;
	
			if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown ("Fire1")) {
				ShootFunction ();

//			//Retrieve the Rigidbody component from the instantiated Bullet and control it.
//			Rigidbody Temporary_RigidBody;
//			Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody>();
//
//			//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
//			Temporary_RigidBody.AddForce(transform.forward * 10000, ForceMode.Impulse);

				//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
//			Destroy(Temporary_Bullet_handler, 10);

			}
		}
		if (isBot == true) {
			myCam.SetActive (false);
			myCanvas.SetActive (false);
			botShootZone.SetActive (true);

			transform.Translate (0, 0, moveSpeed);
			if (botCurrentTarget != null) {
				botTargetDist = Vector3.Distance (botCurrentTarget.transform.position, gameObject.transform.position);
			}

			botDesiredSpeed = (botTargetDist * 0.015f);
			if (moveSpeed < botDesiredSpeed) {
				moveSpeed += (currentAccelRate * botAccelMod);
			}

			if (moveSpeed > botDesiredSpeed) {
				moveSpeed -= (currentDecelRate * botDecelMod);
			}

			if (botCurrentTarget == null && sceneRef.GetComponent<SceneRefScript> ().currentPiece != null) {
				botCurrentTarget = sceneRef.GetComponent<SceneRefScript> ().currentPiece.GetComponent<TrackPieceSpawnScript> ().myRing;
			}

			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(botCurrentTarget.transform.position - transform.position), (TurnRates[myThresh] * botTurnMod) * Time.deltaTime);

			if (botCurrentTarget.GetComponent<GoalRingScript> ().ringActive == false && randomTargetPicker == 1) {
				botCurrentTarget = botCurrentTarget.GetComponent<GoalRingScript> ().myTrack.GetComponent<TrackPieceSpawnScript> ().nextPiece.GetComponent<TrackPieceSpawnScript> ().myRing;
			}
			if (botCurrentTarget.GetComponent<GoalRingScript> ().ringActive == false && randomTargetPicker == 2) {
				botCurrentTarget = botCurrentTarget.GetComponent<GoalRingScript> ().myTrack.GetComponent<TrackPieceSpawnScript> ().nextNextPiece.GetComponent<TrackPieceSpawnScript> ().myRing;
			}
//			if (botCurrentTarget.GetComponent<GoalRingScript> ().ringActive == false && randomTargetPicker == 3) {
//				botCurrentTarget = botCurrentTarget.GetComponent<GoalRingScript> ().myTrack.GetComponent<TrackPieceSpawnScript> ().nextNextNextPiece.GetComponent<TrackPieceSpawnScript> ().myRing;
//			}

			if (botShootZone.GetComponent<BotShootTriggerScript> ().ShootTargets.Count > 0 && botCanShoot == true) {
				ShootFunction ();
				botCanShoot = false;
				botShootZone.GetComponent<BotShootTriggerScript> ().ShootTargets.Clear ();
				StartCoroutine (BotShootCooldown());
			}

		}

		if (inSafeZone == false) {
			safeZoneTimer -= 200 * Time.deltaTime;
		}

		if (inSafeZone == true) {
			safeZoneTimer = 100;
		}

		if (safeZoneTimer <= 0) {
			outsideSafeZoneDamage = true;
			myHP -= 10 * Time.deltaTime;
		}

		if (myHP <= 0) {
			Debug.Log (gameObject + " has 0 HP!");
			DeathBoomFunction ();
		}
		if (myPoints <= 0) {
			Debug.Log (gameObject + " has 0 points!");
			DeathBoomFunction ();
		}

		if (sceneRef.GetComponent<SceneRefScript>().Players.Count == 1 && sceneRef.GetComponent<SceneRefScript>().Players[0] && youWinText != null) {
			YouWinFunction ();
		}
	
	}


	public void ShootFunction(){
		//The Bullet Instantiation happens here.
		GameObject Temporary_Bullet_handler;


		Temporary_Bullet_handler = Instantiate (bullet, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
		Temporary_Bullet_handler.GetComponent<BulletScript> ().myPlayer = gameObject;
		Temporary_Bullet_handler.GetComponent<BulletScript> ().myParticles.startColor = myColor;
		//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
		//This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
		Temporary_Bullet_handler.transform.Rotate (Vector3.left);

	}

	public IEnumerator BotShootCooldown(){
		yield return new WaitForSeconds (botShootDelay);
		botCanShoot = true;
	}


//	void OnTriggerEnter(Collider other){
//
//
//		if (other.gameObject.GetComponent<GoalRingScript> () == true) {
//			other.gameObject.GetComponent<GoalRingScript> ().RingTaken ();
//
//			myPoints += 1;
//		}
//
//	}



	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "SafeZoneTag") {
			inSafeZone = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "SafeZoneTag") {
			inSafeZone = false;
		}
	}

	public void LosePoint(){
		Debug.Log ("Point lost for " + gameObject);
		myPoints -= 1;
	}

	void DeathBoomFunction(){
		GameObject temporaryBoomHandler;

		temporaryBoomHandler = Instantiate(deathBoomFX, gameObject.transform.position, gameObject.transform.localRotation) as GameObject;
		temporaryBoomHandler.transform.localScale = gameObject.transform.localScale;
		temporaryBoomHandler.GetComponent<ParticleSystem> ().startColor = myColor;
		if (isBot == false) {
			GameObject temporaryDeathCamHandler;

			temporaryDeathCamHandler = Instantiate (deathCam, gameObject.transform.position, gameObject.transform.localRotation) as GameObject;
			temporaryDeathCamHandler.transform.localScale = gameObject.transform.localScale;
		}
		sceneRef.GetComponent<SceneRefScript> ().Players.Remove (gameObject);
		Destroy (gameObject);
	}

	void YouWinFunction(){
		youWinText.SetActive (true);
	}
}
