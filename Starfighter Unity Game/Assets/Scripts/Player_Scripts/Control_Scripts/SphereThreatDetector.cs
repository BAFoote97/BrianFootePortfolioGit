using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereThreatDetector : MonoBehaviour {

    public List<Transform> Team1Threats = new List<Transform>();

    public List<Transform> Team2Threats = new List<Transform>();



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        

        Team1Threats.Clear();
        Team2Threats.Clear();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Team1Body")
        {
            Team1Threats.Add(other.transform);
        }

        if (other.transform.tag == "Team2Body")
        {
            Team2Threats.Add(other.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Team1Body")
        {
            Team1Threats.Remove(other.transform);
        }
        if (other.transform.tag == "Team2Body")
        {
            Team2Threats.Remove(other.transform);
        }
    }
}
