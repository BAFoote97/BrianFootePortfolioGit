using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScriptTrigger : MonoBehaviour {

    public List<GameObject> TimeConversations = new List<GameObject>();
    public List<float> TimeThreshholds = new List<float>();
    public List<GameObject> Objective1Conversations = new List<GameObject>();
    public List<float> Objective1ScoreThreshholds = new List<float>();
    public List<GameObject> Objective2Conversations = new List<GameObject>();
    public List<float> Objective2ScoreThreshholds = new List<float>();

    public float totalTimer;
    public GameObject subtitleRef;
    public bool timerActive;
    public int timeThreshInt;
    public float currentTimeThresh;


    public float objective1ScoreThresh;
    public int objective1ScoreInt;

    public float objective2ScoreThresh;
    public int objective2ScoreInt;


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (timerActive == true)
        {
            totalTimer += Time.deltaTime;
        }
        if (TimeThreshholds.Count > 0)
        {
            currentTimeThresh = TimeThreshholds[timeThreshInt];
        }
        if (totalTimer >= currentTimeThresh && TimeThreshholds.Count > 0)
        {
            subtitleRef.GetComponent<DialogueScript>().dialogueSequenceList = TimeConversations[timeThreshInt];
            timeThreshInt += 1;
        }
        if (Objective1ScoreThreshholds.Count > 0 && objective1ScoreInt > 0)
        {
            objective1ScoreThresh = Objective1ScoreThreshholds[objective1ScoreInt];
        }
        if (gameObject.GetComponent<MissionScript>().objective1Count >= objective1ScoreThresh && Objective1Conversations.Count > 0 && Objective1ScoreThreshholds.Count > 0)
        {
            subtitleRef.GetComponent<DialogueScript>().dialogueSequenceList = Objective1Conversations[objective1ScoreInt];
            if (objective1ScoreInt < Objective1ScoreThreshholds.Count)
            {
                objective1ScoreInt += 1;
            }

        }

        objective2ScoreThresh = Objective2ScoreThreshholds[objective2ScoreInt];

        if (gameObject.GetComponent<MissionScript>().objective2Count >= objective2ScoreThresh)
        {
            subtitleRef.GetComponent<DialogueScript>().textHolder = null;
            subtitleRef.GetComponent<DialogueScript>().dialogueSequenceList = null;
            subtitleRef.GetComponent<DialogueScript>().sequenceTextHolder = null;
            subtitleRef.GetComponent<DialogueScript>().dialogueSequenceList = Objective2Conversations[objective2ScoreInt];
            objective2ScoreInt += 1;

        }

        

    }
}
