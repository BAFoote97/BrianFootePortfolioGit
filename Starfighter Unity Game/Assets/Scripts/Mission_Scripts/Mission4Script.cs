using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission4Script : MonoBehaviour {

    public GameObject whiplashSpawn;
    public GameObject whiplashRef;

    public bool step1;
    public bool step2;

    public GameObject BGM1;
    public GameObject BGM2;

	// Use this for initialization
	void Start () {
        
        gameObject.GetComponent<MissionScript>().objectiveDescriptionText2.SetActive(false);
        gameObject.GetComponent<MissionScript>().objectiveNumberText2.SetActive(false);
        gameObject.GetComponent<MissionScript>().objectiveGoalText2.SetActive(false);

        StartCoroutine(StartMission());

    }
	
	// Update is called once per frame
	void Update () {

        if (gameObject.GetComponent<MissionScript>().objective1Count == 1 && step1 == false)
        {
            step1 = true;
            BeginSpawning();
            
        }

        if (gameObject.GetComponent<MissionScript>().objective1Count == 3 && step2 == false)
        {
            step2 = true;
            StartCoroutine(WhiplashSpawn());

        }

        if (gameObject.GetComponent<MissionScript>().hasFailed == true)
        {
            
            StopAllCoroutines();
        }


    }

    public IEnumerator StartMission()
    {
        yield return new WaitForSeconds(15);
    }

    void BeginSpawning()
    {
        
        gameObject.GetComponent<MissionSpawner>().respawnValue1 = 0;

    }
    public IEnumerator WhiplashSpawn()
    {
        yield return new WaitForSeconds(10);

        Instantiate(whiplashRef, whiplashSpawn.transform.position, whiplashSpawn.transform.rotation);

        gameObject.GetComponent<MissionScript>().objective2 = true;
        gameObject.GetComponent<MissionScript>().objectiveDescriptionText2.SetActive(true);
        gameObject.GetComponent<MissionScript>().objectiveNumberText2.SetActive(true);
        gameObject.GetComponent<MissionScript>().objectiveGoalText2.SetActive(true);


        
    }
}
