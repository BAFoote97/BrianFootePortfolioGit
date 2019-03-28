using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargettingScript : MonoBehaviour {

    public GameObject targetZone;



    public GameObject missileWeapon1;
	public GameObject missileWeapon2;
    
	public Transform currentTarget;
	public Transform aimTarget;
	public Transform randomTarget;

    public bool currentTargetIsFriendly;

    public GameObject sphereDetector;

    //public Transform[] hostiles;
    public List<Transform> threats = new List<Transform>();

    public Transform topPriority;
    public Transform firstThreat;

    public List<Transform> hostiles = new List<Transform>();

    public Transform firstHostile;

    public Transform closestHostile;
    public float currentTargetDist;

    public GameObject coneCollision;
	public bool lockedOnTarget;

//	public Transform shipObject;
//	public float dotProd;
//	public Vector3 shipDirection;
//	public Vector3 targetPos;

	//public KeyCode RClick;

	public Transform camLookAt;

	private bool camCanLook;

	//public bool trgtSwitch = false;

	public Transform lookAtTarget;
	public Transform lookAtDef;
	public Transform camTransform;
	Vector3 defaultCamPosition = new Vector3 (0f,0f,0);

	public bool canLookAtTarget;
	public float camRotSpeed;

	public Camera cam;

	public float distance = 10.0f;
	public float currentX = 0.0f;
	public float currentY = 0.0f;
	public float sensitivityX = 4.0f;
	public float sensitivityY = 1.0f;

   

	// Use this for initialization
	void Start () {





        canLookAtTarget = false;
////		camTransform = transform;
//		//		cam = Camera.main;
//
//		Vector3 dir = new Vector3 (0, 0, -distance);
//		Quaternion rotation = Quaternion.Euler (lookAtDef.forward);
//		//		camTransform.position = lookAt.rotation * dir;
//		camTransform.LookAt (lookAtDef.position);
//		
	}
	
	// Update is called once per frame
	void Update () {
		missileWeapon1 = this.gameObject.GetComponent<SaveLoadoutScript> ().activeSideWeapon;
		missileWeapon2 = this.gameObject.GetComponent<SaveLoadoutScript> ().activeUnderWeapon;
		//Debug.Log ("Step 1");
        aimTarget = targetZone.GetComponent<TargetZoneScript>().currentAim;
		//Debug.Log ("Step 2");

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Team2Body"))
        {
            //Debug.Log(obj);
            //Debug.Log("Step 2.1");
			if (obj.GetComponent<Team2LockOnMe>() == true && obj.GetComponent<Team2LockOnMe> ().character.GetComponent<BasicAI> ().dead == false) 
			{
                //Debug.Log("Step 2.2");
				hostiles.Add (obj.transform);
			}

        }
        		//Debug.Log ("Step 3");

        //nextHostile = hostiles[0];
        if (randomTarget == null && hostiles.Count > 0)
        {
            randomTarget = hostiles[Random.Range(0, hostiles.Count)];
        }

		//Debug.Log ("Step 4");
                        hostiles.Clear();

		//Debug.Log ("Step 5");


//        currentTargetDist = Vector3.Distance(transform.position, currentTarget.transform.position);


        if (currentTarget != null && currentTarget.GetComponent<Team2LockOnMe>() == true)
        {
            currentTargetIsFriendly = false;
        }
		//Debug.Log ("Step 5.5");
		if (currentTarget != null && currentTarget.GetComponent<Team1LockOnMe>() == true)
        {
            currentTargetIsFriendly = true;
        }
		//Debug.Log ("Step 6");

        if (Input.GetKeyDown("g") && currentTarget != null)
               {
//			Debug.Log ("Pressed G");
                    if (currentTarget.GetComponent<Team2LockOnMe>() == true)
                    {
                        currentTarget.GetComponent<Team2LockOnMe>().isTargettedByPlayer = false;
                        currentTarget.GetComponent<Team2LockOnMe>().isLockedOnByPlayer = false;
                    }
                    missileWeapon1.GetComponent<PlayerMissileLauncher>().lockedOn = false;
					missileWeapon2.GetComponent<PlayerMissileLauncher>().lockedOn = false;


                    currentTarget = null;
                }



        
        if (Input.GetKeyDown("f") && aimTarget != null)
        {
//			Debug.Log ("Pressed F");
            missileWeapon1.GetComponent<PlayerMissileLauncher>().lockedOn = false;
			missileWeapon2.GetComponent<PlayerMissileLauncher>().lockedOn = false;

            lockedOnTarget = false;
            if (currentTarget != null)
            {
                if (currentTarget.GetComponent<Team2LockOnMe>() == true && currentTarget.GetComponent<Team1LockOnMe>() == false)
                {
                    currentTarget.GetComponent<Team2LockOnMe>().isTargettedByPlayer = false;
                    currentTarget.GetComponent<Team2LockOnMe>().isLockedOnByPlayer = false;
                }
                if (currentTarget.GetComponent<Team1LockOnMe>() == true && currentTarget.GetComponent<Team2LockOnMe>() == false)
                {
                    currentTarget.GetComponent<Team1LockOnMe>().isTargettedByPlayer = false;
                }
                currentTarget = null;
            }

            if (aimTarget != null && aimTarget.GetComponent<Team2LockOnMe>() == true && aimTarget.GetComponent<Team2LockOnMe> ().character.GetComponent<BasicAI> ().dead == false) 
			{
				currentTarget = aimTarget;
                aimTarget = null;
                currentTarget.GetComponent<Team2LockOnMe>().isTargettedByPlayer = true;

            }
            if (aimTarget != null && aimTarget.GetComponent<Team1LockOnMe>() == true && aimTarget.GetComponent<Team1LockOnMe>().character.GetComponent<BasicAI>().dead == false)
            {
                
                    currentTarget = aimTarget;
                    aimTarget = null;
                currentTarget.GetComponent<Team1LockOnMe>().isTargettedByPlayer = true;


            }

            //if (currentTarget.GetComponent<Team2LockOnMe>() == true)
            //{
            //    currentTarget.GetComponent<Team2LockOnMe>().isTargettedByPlayer = true;
            //}
            //if (currentTarget.GetComponent<Team1LockOnMe>() == true)
            //{
            //    currentTarget.GetComponent<Team1LockOnMe>().isTargettedByPlayer = true;
            //}
        }
        if (Input.GetKeyDown ("r"))
        {
            if (currentTarget != null && currentTarget.GetComponent<Team2LockOnMe>() == true)
            {
                currentTarget.GetComponent<Team2LockOnMe>().isTargettedByPlayer = false;
                currentTarget.GetComponent<Team2LockOnMe>().isLockedOnByPlayer = false;
            }

            if (currentTarget != null && currentTarget.GetComponent<Team1LockOnMe>() == true)
            {
                currentTarget.GetComponent<Team1LockOnMe>().isTargettedByPlayer = false;
            }

            missileWeapon1.GetComponent<PlayerMissileLauncher>().lockedOn = false;
			missileWeapon2.GetComponent<PlayerMissileLauncher>().lockedOn = false;

            lockedOnTarget = false;

                        //currentTarget = null;
			if (currentTarget == randomTarget) 
			{
				randomTarget = null;
			}

            currentTarget = randomTarget;
            if (currentTarget != null)
            {
                currentTarget.GetComponent<Team2LockOnMe>().isTargettedByPlayer = true;
            }


        }

        

        if (Input.GetKeyDown("e"))
        {
            if (currentTarget.GetComponent<Team2LockOnMe>() == true)
            {
                currentTarget.GetComponent<Team2LockOnMe>().isTargettedByPlayer = false;
                currentTarget.GetComponent<Team2LockOnMe>().isLockedOnByPlayer = false;
            }
            if (currentTarget.GetComponent<Team1LockOnMe>() == true)
            {
                currentTarget.GetComponent<Team1LockOnMe>().isTargettedByPlayer = false;
            }
            missileWeapon1.GetComponent<PlayerMissileLauncher>().lockedOn = false;
			missileWeapon2.GetComponent<PlayerMissileLauncher>().lockedOn = false;

            lockedOnTarget = false;
            randomTarget = null;
            //            currentTarget = null;
            if (sphereDetector.GetComponent<SphereThreatDetector>().Team2Threats.Count > 0)
            {
                currentTarget = sphereDetector.GetComponent<SphereThreatDetector>().Team2Threats[Random.Range(0, sphereDetector.GetComponent<SphereThreatDetector>().Team2Threats.Count)];
            }
            currentTarget.GetComponent<Team2LockOnMe>().isTargettedByPlayer = true;

        }

        
        if (currentTarget == null)
        {

            //currentTarget.GetComponent<Team2LockOnMe>().isTargettedByPlayer = false;
            //currentTarget.GetComponent<Team2LockOnMe>().isLockedOnByPlayer = false;
            if (sphereDetector.GetComponent<SphereThreatDetector>().Team2Threats.Count > 0)
            {
                currentTarget = sphereDetector.GetComponent<SphereThreatDetector>().Team2Threats[Random.Range(0, sphereDetector.GetComponent<SphereThreatDetector>().Team2Threats.Count)]; ;
            }
            if (sphereDetector.GetComponent<SphereThreatDetector>().Team2Threats.Count == 0)
            {

                currentTarget = randomTarget;

            }
            if (currentTarget != null)
            {
                currentTarget.GetComponent<Team2LockOnMe>().isTargettedByPlayer = true;
            }

        }

        //		shipDirection = shipObject.transform.forward;
        //		targetPos = currentTarget.forward;
        //
        //		dotProd = Vector3.Dot (shipDirection, targetPos);

        currentX += Input.GetAxis ("Mouse X");
		currentY += Input.GetAxis ("Mouse Y");


        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    missileWeapon.GetComponent<PlayerMissileLauncher>().lockedOn = false;
        //    currentTarget.GetComponent<Team2LockOnMe>().isTargettedByPlayer = false;
        //    currentTarget.GetComponent<Team2LockOnMe>().isLockedOnByPlayer = false;
        //    lockedOnTarget = false;
        //   currentTarget = null;
        //    currentTarget = nextTarget.GetComponent<Team2LockOnMe>().npcBody;
        //}
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    missileWeapon.GetComponent<PlayerMissileLauncher>().lockedOn = false;
        //    currentTarget.GetComponent<Team2LockOnMe>().isTargettedByPlayer = false;
        //    currentTarget.GetComponent<Team2LockOnMe>().isLockedOnByPlayer = false;
        //    lockedOnTarget = false;
        //    currentTarget = null;
        //    currentTarget = closestHostile.GetComponent<Team2LockOnMe>().npcBody;
        // }



    }

    void LateUpdate () {

        

		if (Input.GetMouseButton (1)) {
//			lookAtDef.rotation = Quaternion.Slerp (lookAtDef.rotation, Quaternion.LookRotation (currentTarget.transform.position - lookAtDef.position), camRotSpeed * Time.deltaTime);
			camTransform.transform.LookAt(currentTarget);
//			StartCoroutine(CamsLookAtTarget());

		}

		if (Input.GetMouseButtonUp (1)) {
			camTransform.transform.rotation = lookAtDef.transform.rotation;


		}
	}


}
