using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionScript : MonoBehaviour {

    public bool noObjective;

    public TargettingScript gamePlayer;

    public bool objective1;
    public float objective1Count;
    public float objective1Goal;
    public bool failOnObjective1;
    public bool objective2;
    public float objective2Count;
    public float objective2Goal;
    public bool failOnObjective2;

    public GameObject objectiveDescriptionText1;
    public Text objectiveDescription1;
    public GameObject objectiveNumberText1;
    public GameObject objectiveGoalText1;

    public GameObject objectiveDescriptionText2;
    public Text objectiveDescription2;
    public GameObject objectiveNumberText2;
    public GameObject objectiveGoalText2;


    public bool hasFailed;
    public GameObject missionFailedText;
    public AudioSource missionFailedBGM;

	// Use this for initialization
	void Start () {
        gamePlayer = FindObjectOfType<TargettingScript>();
        missionFailedText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (gamePlayer.GetComponent<PauseScript>().paused == false)
        {
            if (noObjective == false)
            {
                if (gamePlayer.GetComponent<PlayerStatsScript>().dead == true)
                {
                    hasFailed = true;
                }
                if (objective1 == false)
                {
                    objectiveDescriptionText1.SetActive(false);
                    objectiveNumberText1.SetActive(false);
                    objectiveGoalText1.SetActive(false);
                }
                objectiveDescriptionText1.GetComponent<Text>().text = objectiveDescription1.text;
                objectiveNumberText1.GetComponent<Text>().text = objective1Count.ToString();
                objectiveGoalText1.GetComponent<Text>().text = objective1Goal.ToString();

                if (objective1Count == objective1Goal)
                {
                    if (failOnObjective1 == true)
                    {
                        hasFailed = true;
                    }
                }




                if (objective2 == false)
                {
                    objectiveDescriptionText2.SetActive(false);
                    objectiveNumberText2.SetActive(false);
                    objectiveGoalText2.SetActive(false);
                }
                objectiveDescriptionText2.GetComponent<Text>().text = objectiveDescription2.text;
                objectiveNumberText2.GetComponent<Text>().text = objective2Count.ToString();
                objectiveGoalText2.GetComponent<Text>().text = objective2Goal.ToString();

                if (objective2Count == objective2Goal)
                {
                    if (failOnObjective2 == true)
                    {
                        hasFailed = true;
                    }
                }

                if (hasFailed == true)
                {
                    missionFailedText.SetActive(true);
                    missionFailedBGM.enabled = true;
                }
            }
        }
    }
}
