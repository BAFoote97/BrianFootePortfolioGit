using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissileWarningScript : MonoBehaviour {

    public List<GameObject> incomingMissiles = new List<GameObject>();


    public bool missileWarning;
    public bool missileIncoming;
    public AudioSource alarm;

    public GameObject outerTarget;
    public GameObject MISSILE;
    public GameObject WARNING;

    public Color red;
    public Color blue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (incomingMissiles.Count == 0)
        {
            missileIncoming = false;
        }

        if (incomingMissiles.Count > 0)
        {
            missileIncoming = true;
        }

        incomingMissiles.Clear();

        if (missileIncoming == true)
        {
            outerTarget.GetComponent<Image>().color = red;
            MISSILE.gameObject.SetActive(true);
            WARNING.gameObject.SetActive(true);
            alarm.enabled = true;
        }
        if (missileIncoming == false)
        {
            outerTarget.GetComponent<Image>().color = blue;
            MISSILE.gameObject.SetActive(false);
            WARNING.gameObject.SetActive(false);
            alarm.enabled = false;
        }
    }
}
