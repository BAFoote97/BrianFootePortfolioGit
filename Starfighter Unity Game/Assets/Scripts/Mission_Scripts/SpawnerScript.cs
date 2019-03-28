using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

    public GameObject spawnItemL;
    public GameObject spawnItemK;
	public GameObject spawnItemJ;
	public GameObject spawnItemH;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("l"))
        {
            GameObject Spawn_handler;
            
            Spawn_handler = Instantiate(spawnItemL, this.transform.position, this.transform.rotation) as GameObject;
        }
        if (Input.GetKeyDown("k"))
        {
            GameObject Spawn_handler;

            Spawn_handler = Instantiate(spawnItemK, this.transform.position, this.transform.rotation) as GameObject;
        }
		if (Input.GetKeyDown("j"))
		{
			GameObject Spawn_handler;

			Spawn_handler = Instantiate(spawnItemJ, this.transform.position, this.transform.rotation) as GameObject;
		}
		if (Input.GetKeyDown("h"))
		{
			GameObject Spawn_handler;

			Spawn_handler = Instantiate(spawnItemH, this.transform.position, this.transform.rotation) as GameObject;
		}


    }
}
