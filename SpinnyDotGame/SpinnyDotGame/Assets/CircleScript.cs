using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour {

	public float spinValue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			Destroy (this.gameObject);

		}

		gameObject.transform.Rotate (0, 0, -spinValue);

		
	}

	void OnCollisionStay2D (Collision2D destroyDetect)
	{
//		Debug.Log ("I Got Hit!" + gameObject.name);
		//Destroy (this.gameObject);

	}
}
