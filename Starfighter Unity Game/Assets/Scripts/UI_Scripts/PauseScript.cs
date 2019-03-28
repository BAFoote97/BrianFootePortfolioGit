using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

    public bool paused;
    public GameObject pauseMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P))
        {
            
            
            paused = !paused;
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                paused = true;
                pauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Time.timeScale = 1;
                paused = false;
                pauseMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }

        }

    }

    
}
