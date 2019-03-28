using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessWavesMissionScript : MonoBehaviour {

    public List<GameObject> WaveList = new List<GameObject>();
    public List<float> WaveReq = new List<float>();

    public int currentWave;
    public float nextWaveReq;

    public GameObject waveSpawnPoint;

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<MissionScript>().objective2Count = -1;
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    gameObject.GetComponent<MissionScript>().objective1Count += 1;
        //}
		if (gameObject.GetComponent<MissionScript>().objective1Count == nextWaveReq)
        {
            nextWaveReq = WaveReq[currentWave + 1];
            
            SpawnWave();
            gameObject.GetComponent<MissionScript>().objective2Count += 1;
        }
	}

    public void SpawnWave()
    {
        Debug.Log("Wave " + currentWave + " has spawned");
        GameObject Spawn_handler;

        Spawn_handler = Instantiate(WaveList[currentWave], waveSpawnPoint.transform.position, waveSpawnPoint.transform.rotation) as GameObject;
        currentWave += 1;
    }
}
