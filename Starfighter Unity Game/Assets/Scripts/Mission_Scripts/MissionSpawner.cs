using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSpawner : MonoBehaviour {

    public List<float> SpawnIncreaseFloats1 = new List<float>();
    public List<GameObject> SpawnReferences1 = new List<GameObject>();
    public List<GameObject> SpawnPoints1 = new List<GameObject>();

    public bool randomSpawnRef1;
    public int randomSpawnRefInt1;
    public bool randomSpawnPoint1;
    public int randomSpawnPointInt1;


    public float respawnValueIncrease1;
    public float respawnValue1;
    public float respawnThresh1;

    public int spawnPointInt1;
    public int spawnRefInt1;

    public List<float> SpawnIncreaseFloats2 = new List<float>();
    public List<GameObject> SpawnReferences2 = new List<GameObject>();
    public List<GameObject> SpawnPoints2 = new List<GameObject>();

    public bool randomSpawnRef2;
    public int randomSpawnRefInt2;
    public bool randomSpawnPoint2;
    public int randomSpawnPointInt2;


    public float respawnValueIncrease2;
    public float respawnValue2;
    public float respawnThresh2;

    public int spawnPointInt2;
    public int spawnRefInt2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        randomSpawnRefInt1 = Random.Range(0, SpawnReferences1.Count);
        randomSpawnPointInt1 = Random.Range(0, SpawnPoints1.Count);

        if (respawnValue1 <= respawnThresh1)
        {
            RespawnEvent1();
        }

        randomSpawnRefInt2 = Random.Range(0, SpawnReferences2.Count);
        randomSpawnPointInt2 = Random.Range(0, SpawnPoints2.Count);

        if (respawnValue2 <= respawnThresh2)
        {
            RespawnEvent2();
        }

    }

    void RespawnEvent1()
    {

        if (randomSpawnRef1 == true && randomSpawnPoint1 == false)
        {
            respawnValue1 += SpawnIncreaseFloats1[randomSpawnRefInt1];
            GameObject Spawn_handler;

            Spawn_handler = Instantiate(SpawnReferences1[randomSpawnRefInt1], SpawnPoints1[spawnPointInt1].transform.position, SpawnPoints1[spawnPointInt1].transform.rotation) as GameObject;
        }
        if (randomSpawnRef1 == false && randomSpawnPoint1 == false)
        {
            respawnValue1 += respawnValueIncrease1;
            GameObject Spawn_handler;

            Spawn_handler = Instantiate(SpawnReferences1[spawnRefInt1], SpawnPoints1[spawnPointInt1].transform.position, SpawnPoints1[spawnPointInt1].transform.rotation) as GameObject;
        }
        if (randomSpawnRef1 == true && randomSpawnPoint1 == true)
        {
            respawnValue1 += SpawnIncreaseFloats1[randomSpawnRefInt1];
            GameObject Spawn_handler;

            Spawn_handler = Instantiate(SpawnReferences1[randomSpawnRefInt1], SpawnPoints1[randomSpawnPointInt1].transform.position, SpawnPoints1[randomSpawnPointInt1].transform.rotation) as GameObject;
        }
        if (randomSpawnRef1 == false && randomSpawnPoint1 == true)
        {
            respawnValue1 += respawnValueIncrease1;
            GameObject Spawn_handler;

            Spawn_handler = Instantiate(SpawnReferences1[spawnRefInt1], SpawnPoints1[randomSpawnPointInt1].transform.position, SpawnPoints1[randomSpawnPointInt1].transform.rotation) as GameObject;
        }
    }

    void RespawnEvent2()
    {
        if (randomSpawnRef2 == true && randomSpawnPoint2 == false)
        {
            respawnValue2 += SpawnIncreaseFloats2[randomSpawnRefInt2];
            GameObject Spawn_handler;

            Spawn_handler = Instantiate(SpawnReferences2[randomSpawnRefInt2], SpawnPoints2[spawnPointInt2].transform.position, SpawnPoints2[spawnPointInt2].transform.rotation) as GameObject;
        }
        if (randomSpawnRef2 == false && randomSpawnPoint2 == false)
        {
            respawnValue2 += respawnValueIncrease2;
            GameObject Spawn_handler;

            Spawn_handler = Instantiate(SpawnReferences2[spawnRefInt2], SpawnPoints2[spawnPointInt2].transform.position, SpawnPoints2[spawnPointInt2].transform.rotation) as GameObject;
        }
        if (randomSpawnRef2 == true && randomSpawnPoint2 == true)
        {
            respawnValue2 += SpawnIncreaseFloats2[randomSpawnRefInt2];
            GameObject Spawn_handler;

            Spawn_handler = Instantiate(SpawnReferences2[randomSpawnRefInt2], SpawnPoints2[randomSpawnPointInt2].transform.position, SpawnPoints2[randomSpawnPointInt2].transform.rotation) as GameObject;
        }
        if (randomSpawnRef2 == false && randomSpawnPoint2 == true)
        {
            respawnValue2 += respawnValueIncrease1;
            GameObject Spawn_handler;

            Spawn_handler = Instantiate(SpawnReferences2[spawnRefInt2], SpawnPoints2[randomSpawnPointInt2].transform.position, SpawnPoints2[randomSpawnPointInt2].transform.rotation) as GameObject;
        }
    }

    void RespawnEvent3()
    {

    }
}
