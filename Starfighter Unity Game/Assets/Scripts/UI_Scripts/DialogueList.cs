using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueList : MonoBehaviour {

    public List<GameObject> Dialogue = new List<GameObject>();

    public GameObject currentDialogue;
    public int currentDialogueNumber;

    public GameObject nextDialogue;
    public int nextDialogueNumber;
    public float sequenceDelay;


    // Use this for initialization
    void Start () {
        currentDialogueNumber = 0;
        nextDialogueNumber = 1;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Dialogue.Count > 0)
        {
            currentDialogue = Dialogue[currentDialogueNumber];

            nextDialogue = Dialogue[nextDialogueNumber];
        }
	}
}
