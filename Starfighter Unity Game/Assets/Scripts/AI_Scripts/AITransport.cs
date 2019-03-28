using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITransport : MonoBehaviour {


    public float transportShieldHP;
    public float transportShieldHPMax;
    public float transportHullHP;
    public float transportHullHPMax;

    public bool onPath;
    public GameObject flightPath;
    public int pathValue;
    public Transform nextCheckpoint;
    public float distanceMinimum;
    public bool transitionBool;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
