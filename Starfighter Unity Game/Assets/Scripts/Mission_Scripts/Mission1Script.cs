using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission1Script : MonoBehaviour {



    public bool step1;
    public bool step2;
    public bool step3;
    public bool step4;
    public bool step5;
    public bool step6;

    public GameObject wingman;

    public GameObject spawnPoint1;
    public GameObject spawnPoint2;

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject bullhornGroup;

    public GameObject BGM1;
    public GameObject BGM2;

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<MissionScript>().objectiveDescriptionText2.SetActive(false);
        gameObject.GetComponent<MissionScript>().objectiveNumberText2.SetActive(false);
        gameObject.GetComponent<MissionScript>().objectiveGoalText2.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

        

        if (gameObject.GetComponent<MissionScript>().objective1Count < 4 && step1 == false)
        {
            StartCoroutine(FirstSpawn());
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().currentSpeed = 4;

            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().speed1 = 4;
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().speed2 = 4;
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().speed3 = 4;
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().speed4 = 4;
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().speed5 = 4;

        }
        if (gameObject.GetComponent<MissionScript>().objective1Count >= 4 && gameObject.GetComponent<MissionScript>().objective1Count < 12 && step2 == false)
        {
            StartCoroutine(SecondSpawn());
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().currentSpeed = 2;
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().speed1 = 2;
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().speed2 = 2;
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().speed3 = 2;
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().speed4 = 2;
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().speed5 = 2;

        }
        if (gameObject.GetComponent<MissionScript>().objective1Count >= 12 && gameObject.GetComponent<MissionScript>().objective1Count < 20 && step3 == false)
        {
            StartCoroutine(ThirdSpawn());
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().currentSpeed = 1;
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().speed1 = 1;
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().speed2 = 1;
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().speed3 = 1;
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().speed4 = 1;
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().speed5 = 1;
        }
        if (gameObject.GetComponent<MissionScript>().objective1Count >= 20 && gameObject.GetComponent<MissionScript>().objective1Count < 28 && step4 == false)
        {
            StartCoroutine(FourthSpawn());
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().currentSpeed = 0;
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().speed1 = 0;
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().speed2 = 0;
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().speed3 = 0;
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().speed4 = 0;
            GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().speed5 = 0;
        }
        if (gameObject.GetComponent<MissionScript>().objective1Count >= 28 && step5 == false)
        {
            StartCoroutine(BullhornSpawn());
            wingman.GetComponent<BasicAI>().currentTarget = gameObject.GetComponent<MissionScript>().gamePlayer.transform;
        }

        if (gameObject.GetComponent<MissionScript>().objective2Count >= 4 && step6 == false)
        {

            gameObject.GetComponent<DialogueScriptTrigger>().timerActive = false;
        }
        if (gameObject.GetComponent<MissionScript>().hasFailed == true)
        {
            StopAllCoroutines();
        }

    }

    public IEnumerator FirstSpawn()
    {
        wingman.GetComponent<BasicAI>().currentTarget = spawnPoint1.transform;
        wingman.GetComponent<BasicAI>().currentSpeed = 9;


        step1 = true;

        yield return new WaitForSeconds(65);
        GameObject Spawn_handler;

        Spawn_handler = Instantiate(spawn1, spawnPoint1.transform.position, spawnPoint1.transform.rotation) as GameObject;
        wingman.GetComponent<BasicAI>().currentTarget = null;

    }
    public IEnumerator SecondSpawn()
    {
        step2 = true;
        GameObject Spawn_handler;

        yield return new WaitForSeconds(6);
        Spawn_handler = Instantiate(spawn1, spawnPoint1.transform.position, spawnPoint1.transform.rotation) as GameObject;
        yield return new WaitForSeconds(6);
        Spawn_handler = Instantiate(spawn1, spawnPoint1.transform.position, spawnPoint1.transform.rotation) as GameObject;

    }
    public IEnumerator ThirdSpawn()
    {
        step3 = true;
        GameObject Spawn_handler;

        yield return new WaitForSeconds(4);
        Spawn_handler = Instantiate(spawn1, spawnPoint1.transform.position, spawnPoint1.transform.rotation) as GameObject;
        yield return new WaitForSeconds(4);
        Spawn_handler = Instantiate(spawn2, spawnPoint1.transform.position, spawnPoint1.transform.rotation) as GameObject;

    }
    public IEnumerator FourthSpawn()
    {
        step4 = true;
        GameObject Spawn_handler;

        yield return new WaitForSeconds(8);
        GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives.GetComponent<BasicAI>().itemHolder.SetActive(false);

        Spawn_handler = Instantiate(spawn2, spawnPoint1.transform.position, spawnPoint1.transform.rotation) as GameObject;
        yield return new WaitForSeconds(2);
        Spawn_handler = Instantiate(spawn2, spawnPoint1.transform.position, spawnPoint1.transform.rotation) as GameObject;

    }

    public IEnumerator BullhornSpawn()
    {
        step5 = true;
        GameObject Spawn_handler;

        yield return new WaitForSeconds(50);
        gameObject.GetComponent<DialogueScriptTrigger>().timerActive = true;
        Spawn_handler = Instantiate(bullhornGroup, spawnPoint2.transform.position, spawnPoint2.transform.rotation) as GameObject;
        gameObject.GetComponent<MissionScript>().objectiveDescriptionText2.SetActive(true);
        gameObject.GetComponent<MissionScript>().objectiveNumberText2.SetActive(true);
        gameObject.GetComponent<MissionScript>().objectiveGoalText2.SetActive(true);
        wingman.GetComponent<BasicAI>().currentTarget = null;



    }
}
