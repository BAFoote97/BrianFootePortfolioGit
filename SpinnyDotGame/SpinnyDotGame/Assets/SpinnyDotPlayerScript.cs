using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpinnyDotPlayerScript : MonoBehaviour {

	public float spinValue = 1.0f;


	public Text gameOverText;

	public GameObject myPlayer;
	public bool gameOver;


	public GameObject circleDetect;
	public bool circleIsDetected;
	public bool circleInRange;

	public bool canSpin;

	public GameObject circleSpawner;

	public GameObject currentCircleRef;

	public float scoreRef;


	IEnumerator PlayerSpin (){
		transform.Rotate (0, 0, -spinValue);
		yield return new WaitForSeconds (1f);

	}

	void OnTriggerEnter(Collider circleIn)
	{
		if (circleIn.gameObject.tag == "SpinCircleTag")
			circleInRange = true;
	}

	// Use this for initialization
	void Start () {

		canSpin = true;

	}


	
	// Update is called once per frame
	void Update () {



		scoreRef = gameObject.GetComponent<ScoreSystem> ().currentScore;
		scoreRef = scoreRef * 0.0001f;
		currentCircleRef = circleSpawner.GetComponent<SpinnyCircles> ().currentCircle;
		circleIsDetected = circleDetect.GetComponent<DetectCircleScript> ().circleIsIn;

		spinValue = scoreRef + spinValue;

		if (canSpin == true)
		{
		transform.Rotate (0, 0, -spinValue);
		}

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			if (circleIsDetected == false)
			{
				gameObject.GetComponent<CircleCollider2D> ().enabled = true;
//				if (circleInRange == true) {
					gameObject.GetComponent<ScoreSystem> ().currentScore += 1;
					currentCircleRef = null;
					circleSpawner.GetComponent<SpinnyCircles> ().currentCircle = null;

//				}
//			canSpin = false;
			}
			if (circleIsDetected == true)
			{
				gameOverText.enabled = true;
				gameOver = true;
					Destroy (myPlayer);
			}

		}
		if (Input.GetKeyUp (KeyCode.Mouse0)) 
		{
			if (circleIsDetected == true)
			{
				canSpin = true;
			}
			if (circleIsDetected == false)
			{
				
				canSpin = true;
			}

		}


	}


}
