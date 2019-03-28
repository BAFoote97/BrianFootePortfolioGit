using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator1 : MonoBehaviour {

    public GameObject player;
    public GameObject indicArrow;

    public Transform currentTarget;

    public float targetDistance;
    public float arrowLength;
    
    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        currentTarget = player.GetComponent<TargettingScript>().currentTarget;


        if (currentTarget.GetComponent<Team2LockOnMe>() == true && currentTarget.GetComponent<Team1LockOnMe>() == false)
        {
            targetDistance = currentTarget.GetComponent<Team2LockOnMe>().character.GetComponent<BasicAI>().playerDistance;
        }
        if (currentTarget.GetComponent<Team1LockOnMe>() == true && currentTarget.GetComponent<Team2LockOnMe>() == false)
        {
            targetDistance = currentTarget.GetComponent<Team1LockOnMe>().character.GetComponent<BasicAI>().playerDistance;
        }

        arrowLength = targetDistance * 0.0000085f;

        indicArrow.GetComponent<Transform>().localScale = new Vector3(arrowLength, 0.02f, 0.02f);
        //indicArrow.GetComponent<Transform>().localScale = new Vector3(arrowLength, 0, 0);



        gameObject.GetComponent<Transform>().position = Camera.current.GetComponent<CameraIndicPosition>().IndicObject.GetComponent<Transform>().position;


        if (currentTarget != null)
        {
            transform.LookAt(currentTarget);
        }




    }




}
