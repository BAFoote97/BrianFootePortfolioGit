using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission2Script : MonoBehaviour {

    public bool step1;
    public bool step2;
    public bool step3;
    public bool step4;
    public bool step5;
    public bool step6;

    public GameObject wingman;

    public GameObject bullhornSpawnPoint;
    public GameObject genericSpawnPoints;

    public GameObject bullhornRef;
   

    public GameObject BGM1;
    public GameObject BGM2;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<MissionScript>().objectiveDescriptionText2.SetActive(false);
        gameObject.GetComponent<MissionScript>().objectiveNumberText2.SetActive(false);
        gameObject.GetComponent<MissionScript>().objectiveGoalText2.SetActive(false);
        StartCoroutine(BullhornSpawn());

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<MissionScript>().hasFailed == true)
        {
            
            StopAllCoroutines();
        }

    }

    public IEnumerator BullhornSpawn()
    {
        yield return new WaitForSeconds(210);

        yield return new WaitForSeconds(10);
        gameObject.GetComponent<MissionScript>().objectiveDescriptionText2.SetActive(true);
        gameObject.GetComponent<MissionScript>().objectiveNumberText2.SetActive(true);
        gameObject.GetComponent<MissionScript>().objectiveGoalText2.SetActive(true);

        step2 = true;
        gameObject.GetComponent<MissionSpawner>().respawnValue1 = 1000;
        //genericSpawnPoints.SetActive(false);
        //Destroy(genericSpawnPoints);

        GameObject Spawn_handler;


        Spawn_handler = Instantiate(bullhornRef, bullhornSpawnPoint.transform.position, bullhornSpawnPoint.transform.rotation) as GameObject;
        //bullhornRef.SetActive(true);
        //wingman.GetComponent<BasicAI>().currentTarget = null;

    }
   

    
}
