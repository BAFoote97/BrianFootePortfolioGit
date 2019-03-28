using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraSwitchScript : MonoBehaviour {

	public Transform Player;
	public Camera Cam1, Cam2;
	public KeyCode TKey;
	public bool camSwitch = false;

    public GameObject mesh;
    public GameObject thrust;
	
	void Update()
	{
		if (Input.GetKeyDown(TKey))
		{
			camSwitch = !camSwitch;
			Cam1.gameObject.SetActive(camSwitch);
			Cam2.gameObject.SetActive(!camSwitch);
		}

        if (camSwitch == false)
        {
            mesh.GetComponent<Renderer>().enabled = false;
            thrust.SetActive(false);
        }
        if (camSwitch == true)
        {
            mesh.GetComponent<Renderer>().enabled = true;
            thrust.SetActive(true);
        }

    }
}
