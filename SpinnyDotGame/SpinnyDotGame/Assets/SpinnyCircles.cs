using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnyCircles : MonoBehaviour {

	public float spinValue = 1.0f;
	public bool spinValueNeg;

	public GameObject currentCircle;
	public GameObject currentSpawn;

	public GameObject nextCircle;
	public GameObject nextSpawn;

	public float nextCircleScale = 0.75f;

	public GameObject nextCircle2;
	public GameObject next2Spawn;

	public float nextCircle2Scale = 0.5f;

	public List <GameObject> circles = new List<GameObject> ();






	// Use this for initialization
	void Start () {
		spinValueNeg = false;

	}

	// Update is called once per frame
	void Update () {

		currentSpawn.transform.Rotate (0, 0, -spinValue);


		nextCircle2 = circles[Random.Range (0, circles.Count)];



		if (currentCircle == null) 
		{
			currentCircle = nextCircle;
			nextCircle = nextCircle2;


			GameObject Temporary_Circle_handler;

			Temporary_Circle_handler = Instantiate (currentCircle, currentSpawn.transform.position, currentSpawn.transform.rotation) as GameObject;


		}
			
		if (nextCircle == null)
		{
			GameObject Temporary_Circle_handler;

			Temporary_Circle_handler = Instantiate (currentCircle, currentSpawn.transform.position, currentSpawn.transform.rotation) as GameObject;
		}

		if (nextCircle2 == null)
		{
//			GameObject Temporary_Circle_handler;
//
//			Temporary_Circle_handler = Instantiate (nextCircle2, next2Spawn.transform.position, currentSpawn.transform.rotation) as GameObject;
		}


		if (spinValueNeg == true)
		currentCircle.transform.Rotate (0, 0, -spinValue);
		if (spinValueNeg == false)
			currentCircle.transform.Rotate (0, 0, spinValue);


//		nextCircle.transform.localScale += new Vector3 (nextCircleScale, nextCircleScale, nextCircleScale);
//
//		nextCircle2.transform.localScale += new Vector3 (nextCircle2Scale, nextCircle2Scale, nextCircle2Scale);





		
	}

	 
}
