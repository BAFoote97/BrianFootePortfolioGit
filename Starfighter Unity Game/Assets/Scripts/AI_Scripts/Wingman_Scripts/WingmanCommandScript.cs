using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingmanCommandScript : MonoBehaviour {

    public GameObject wingmanNPC;
    public GameObject wingmanFormationPosition;
    public Transform wingmanCurrentTarget;
    public Transform wingmanCommandTarget;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    //    wingmanCurrentTarget = wingmanNPC.GetComponent<BasicAI>().currentTarget;
    //    if (Input.GetKeyDown("c") && gameObject.GetComponent<TargettingScript>().currentTarget.GetComponent<Team2LockOnMe>() == true)
    //    {

    //        gameObject.GetComponent<TargettingScript>().currentTarget.GetComponent<Team2LockOnMe>().character.GetComponent<BasicAI>().attackMarked = true;
    //        wingmanNPC.GetComponent<BasicAI>().WingmanCommandTargets.Add(gameObject.GetComponent<TargettingScript>().currentTarget);
            
    //    }
    //    if (wingmanCurrentTarget != null && wingmanCurrentTarget.GetComponent<Team2LockOnMe>() == true)
    //    {
    //        wingmanCurrentTarget.GetComponent<Team2LockOnMe>().character.GetComponent<BasicAI>().allyAttacking = true;
    //    }

    }

    public void NullifyTarget()
    {
        wingmanCurrentTarget.GetComponent<Team2LockOnMe>().character.GetComponent<BasicAI>().allyAttacking = false;

        //wingmanNPC.GetComponent<BasicAI>().currentTarget = wingmanCommandTarget;
    }
}
