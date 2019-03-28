using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartScene : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Scene loadedLevel = SceneManager.GetActiveScene ();


//		if (Input.GetKeyUp ("r")) {
//
//			SceneManager.LoadScene (loadedLevel.buildIndex);
//		}
		

		
	}

	public void RestartScenes()
	{
		Scene loadedLevel = SceneManager.GetActiveScene ();

		SceneManager.LoadScene (loadedLevel.buildIndex);

	}
}
