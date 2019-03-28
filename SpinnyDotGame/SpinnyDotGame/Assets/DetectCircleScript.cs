using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCircleScript : MonoBehaviour {

	public bool circleIsIn;

	void OnCollisionEnter2D(Collision2D circleOut)
	{
		
		//if (circleOut.gameObject.tag == "SpinCircleTag")
			circleIsIn = true;
	}

	void OnCollisionExit2D(Collision2D circleIn)
	{
		//if (circleIn.gameObject.tag == "SpinCircleTag")
			circleIsIn = false;
	}


}
