using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHolder : MonoBehaviour {

    public Text characterName;
    public Text quote;

    public Color characterColor;

    public float quoteDelay;
    public float quoteTime;

    public bool priority;
    public bool isOneTimeUse;

	// Use this for initialization
	void Start () {

        characterName.color = characterColor;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RemoveHolder()
    {
        Destroy(gameObject);
    }
}
