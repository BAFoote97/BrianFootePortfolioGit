using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTimeScript : MonoBehaviour {

	public float timeBeforeDestroy;

	// Use this for initialization
	void Start () {
		StartCoroutine (CountdownToDestroy ());
	}
	
	public IEnumerator CountdownToDestroy(){
		yield return new WaitForSeconds (timeBeforeDestroy);
		Destroy (gameObject);
	}
}
