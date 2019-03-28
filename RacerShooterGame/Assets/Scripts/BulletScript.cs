using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public GameObject myPlayer;

	public float bulletSpeed;
	public float bulletLife;
	public float bulletDmg;

	public ParticleSystem myParticles;

	// Use this for initialization
	void Start () {
		StartCoroutine (TimeToDeath ());
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, 0, bulletSpeed);
		
	}

	public IEnumerator TimeToDeath(){
		yield return new WaitForSeconds (bulletLife);
		Destroy (gameObject);
	}

	void OnTriggerEnter(Collider other){
		if (other.GetComponent<ObstacleScript> () == true) {
			other.GetComponent<ObstacleScript> ().HP -= bulletDmg;
			other.GetComponent<ObstacleScript> ().SpawnBoom ();
			Destroy (gameObject);
		}

		if (other.GetComponent<PlayerScript> () == true && other.gameObject != myPlayer) {
			other.GetComponent<PlayerScript> ().myHP -= bulletDmg;
			Destroy (gameObject);
		}
	}
}
