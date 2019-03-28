using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicAI : MonoBehaviour {



    public TargettingScript gamePlayer;

    public GameObject subtitleObject;

    public bool wingman;
    public bool wingmanFollow;
    public bool wingmanDisperse;

    public List<Transform> WingmanCommandTargets = new List<Transform>();

    public bool genericEnemy;
    public bool genericAlpha;
    public bool genericBeta;
    public bool genericDelta;
    public bool genericGamma;
    public bool genericOmega;
    public bool genericSigma;
    public bool genericTheta;
    public bool genericZeta;
	public bool usesList1OnDeath;
	public bool usesList1OnPlayerLock;
	public bool usesList1OnLock;
	public bool usesList2OnDeath;
	public bool usesList2OnPlayerLock;
	public bool usesList2OnLock;
	public bool usesList3OnDeath;
	public bool usesList3OnPlayerLock;
	public bool usesList3OnLock;
	public bool usesList4OnDeath;
	public bool usesList4OnPlayerLock;
	public bool usesList4OnLock;
	public bool usesList5OnDeath;
	public bool usesList5OnPlayerLock;
	public bool usesList5OnLock;
	public bool usesList6OnDeath;
	public bool usesList6OnPlayerLock;
	public bool usesList6OnLock;
	public bool usesList7OnDeath;
	public bool usesList7OnPlayerLock;
	public bool usesList7OnLock;
	public bool usesList8OnDeath;
	public bool usesList8OnPlayerLock;
	public bool usesList8OnLock;
	public bool usesList9OnDeath;
	public bool usesList9OnPlayerLock;
	public bool usesList9OnLock;
	public bool usesList10OnDeath;
	public bool usesList10OnPlayerLock;
	public bool usesList10OnLock;


	public int scoreValue;

    public GameObject hitBy;

    public bool isPlayerTarget;

	public float shieldHP;
	public float shieldMaxHP;
	public float shieldRegen;
    public float shieldMinHP;
	public float hullHP;
	public float hullMaxHP;
    public float hullMinHP;

	public Slider shieldMeter;
	public Slider hullMeter;

	public bool shieldProtectsMissiles;

	public float stamCurrent;
	public float stamMax;
    public float stamMin;
	public float stamRegen;
	public float stamSpend;


	public List <Animation> evasiveManeuvers = new List<Animation> ();
	public List <Animation> cManeuvers = new List<Animation> ();

    public List<GameObject> incomingThreats = new List<GameObject>();


	public Transform shipBody;


	public List<Transform> hostiles = new List<Transform>();
	public Transform currentTarget;
	public Transform nextHostile;
	public float currentTargetDist;
    public float playerDistance;
    public Canvas marker;

    public bool playerIsTarget;

	public bool onOffense;
	public bool turnAway;
	public bool onDefense;
    public float turnAwayRateMin;
    public float turnawayRateMax;
    public float evadeThresh;

    public bool canEngage;

    public float DelayMin;
    public float DelayMax;

    public float StartMin;
    public float StartMax;

    public float saveSpeed;
    public float currentSpeed;
	public float speed1 = 1f;
	public float speed2 = 2f;
	public float speed3 = 3f;
	public float speed4 = 4f;
    public float speed5 = 5f;
    public float evadeSpeed = 3f;
    public float accelerationRate;
    public float desiredSpeed;

    public float thrustValue;

    public GameObject thrustFX;
    public GameObject thrustFX2;
	public GameObject thrustFX3;
	public GameObject thrustFX4;
    public GameObject thrustFX5;

    public GameObject deathFire;
    public GameObject killBoom;
    public GameObject deathBoom;
    public GameObject itemHolder;

	public float distThresh1;
    public float distThresh2;
    public float distThresh3;
    public float distThresh4;

    public float rotSpeed = 1f;
    public float rollRate;

	public bool isAttacker;

	public bool isAce;
    public Image emblem;

    public GameObject missionReference;
	public bool objectiveEnemy;
	public Text objectiveText;

    public bool objective1Kill;

    public bool objective2Kill;


	public bool attackMarked;
	public GameObject commandArrow;
    public bool attackMarked2;
    public GameObject commandArrow2;
    public bool attackMarked3;
    public GameObject commandArrow3;

    public bool allyAttacking;
	public GameObject allyAttackingArrow;

	public bool team1NPC;
	public bool team2NPC;

    public bool onPath;
    public GameObject flightPath;
    public int pathValue;
    public Transform nextCheckpoint;
    public float distanceMinimum;
    public bool transitionBool;

    public bool cantDie;
    public bool untouchable;
    public bool cantCrash;
    public bool dead;
    public bool dying;

    public AudioSource deathSound1;
    public AudioSource deathSound2;

    public float timeBeforeDeath;
    public float deathRotateX;
    public float deathRotateY;
    public float deathRotateZ;

    public GameObject spawnReference;
    public bool spawnReferenceGroup1;
    public bool spawnReferenceGroup2;

	// Use this for initialization
	void Start () {

        missionReference = GameObject.FindGameObjectWithTag("MissionReference");
        subtitleObject = GameObject.FindGameObjectWithTag("SubtitleTag");
        //hostiles = GameObject.FindObjectsOfType <Team1LockOnMe> ();
        //currentTarget = hostiles [0];
        //currentTargetDist = Vector3.Distance (transform.position, hostiles [0].transform.position);

            StartCoroutine(WaitRandomly());


    }

    

    // Update is called once per frame
    void Update () {
        gamePlayer = FindObjectOfType<TargettingScript>();

        if (gamePlayer.GetComponent<PauseScript>().paused == false)
        {

            transform.Translate(0, 0, currentSpeed);

            

            

            if (wingman == true && currentTarget != null && currentTarget.GetComponent<Team2LockOnMe>() == true)
            {
                currentTarget.GetComponent<Team2LockOnMe>().character.GetComponent<BasicAI>().allyAttacking = true;
            }


            //        if (Input.GetKeyDown("p"))
            //        {
            //            currentTarget = null;
            //            nextHostile = null;
            //        }

            if (team2NPC == true)
            {
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Team1Body"))
                {
                    hostiles.Add(obj.transform);

                }

                nextHostile = hostiles[0];
                nextHostile = hostiles[Random.Range(0, hostiles.Count)];



                hostiles.Clear();

                if (isAttacker == true)
                {
                    currentTarget = GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team1Objectives;
                }
                if (isAttacker == false && onPath == false)
                {
                    if (currentTarget == null)
                    {
                        currentTarget = nextHostile;
                    }
                }



                if (onPath == true)
                {
                    DelayMin = 0;
                    DelayMax = 0;

                    if (flightPath != null && flightPath.gameObject.GetComponent<AIFlightPathScript>().flightCheckpoints.Count > 0)
                    {
                        currentTarget = flightPath.gameObject.GetComponent<AIFlightPathScript>().flightCheckpoints[pathValue];
                    }

                    if (currentTargetDist <= distanceMinimum && transitionBool == false)
                    {
                        transitionBool = true;
                        pathValue += 1;
                        transitionBool = false;
                    }

                    if (currentTarget == null)
                    {
                        onPath = false;
                    }
                }
            }


            if (team1NPC == true && wingman == false|| wingman == true && WingmanCommandTargets.Count == 0)
            {
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Team2Body"))
                {
                    hostiles.Add(obj.transform);

                }
                if (hostiles.Count > 0)
                {
                    nextHostile = hostiles[0];
                }

                if (nextHostile != null)
                {
                    nextHostile = hostiles[Random.Range(0, hostiles.Count)];
                }

                

                hostiles.Clear();

                if (isAttacker == true)
                {
                    currentTarget = GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().team2Objectives;
                }
                if (isAttacker == false && onPath == false)
                {
                    if (currentTarget == null)
                    {
                        currentTarget = nextHostile;
                    }
                }
                if (onPath == true)
                {
                    DelayMin = 0;
                    DelayMax = 0;

                    currentTarget = flightPath.gameObject.GetComponent<AIFlightPathScript>().flightCheckpoints[pathValue];

                    if (currentTargetDist <= distanceMinimum && transitionBool == false)
                    {
                        transitionBool = true;
                        pathValue += 1;
                        transitionBool = false;
                    }

                    if (currentTarget == null)
                    {
                        onPath = false;
                    }
                }

            }

            
            

            //if (wingman == true && WingmanCommandTargets.Count > 0)
            //{

            //    if (WingmanCommandTargets[0] != null)
            //    {
            //        nextHostile = WingmanCommandTargets[0];
            //    }

            //    if (nextHostile != null)
            //    {
            //        nextHostile = WingmanCommandTargets[Random.Range(0, WingmanCommandTargets.Count)];
            //    }
            //    if (!WingmanCommandTargets.Contains(currentTarget))
            //    {
            //        currentTarget = nextHostile;
            //    }

            //}

            if (onPath == true)
                {
                    DelayMin = 0;
                    DelayMax = 0;

                    currentTarget = flightPath.gameObject.GetComponent<AIFlightPathScript>().flightCheckpoints[pathValue];

                    if (currentTargetDist <= distanceMinimum && transitionBool == false)
                    {
                        transitionBool = true;
                        pathValue += 1;
                        transitionBool = false;
                    }

                    if (currentTarget == null)
                    {
                        onPath = false;
                    }
                }

            }


        //foreach (Team1LockOnMe player in hostiles)
        //{
        //    if (Vector3.Distance(transform.position, player.transform.position) < currentTargetDist)
        //    {
        //        currentTarget = player;
        //        currentTargetDist = Vector3.Distance(transform.position, player.transform.position);
        //    }
        //}


        if (team2NPC == true)
            {

                if (shipBody.gameObject.GetComponent<Team2LockOnMe>().isTargettedByPlayer == true && shipBody != null)
                {
                    isPlayerTarget = true;
                }

                if (shipBody.gameObject.GetComponent<Team2LockOnMe>().isTargettedByPlayer == false && shipBody != null)
                {
                    isPlayerTarget = false;
                }

            }

        if (team1NPC == true)
            {
                if (shipBody.gameObject.GetComponent<Team1LockOnMe>().isTargettedByPlayer == true && shipBody != null)
                {
                    isPlayerTarget = true;
                }

                if (shipBody.gameObject.GetComponent<Team1LockOnMe>().isTargettedByPlayer == false && shipBody != null)
                {
                    isPlayerTarget = false;
                }
            }

        

            shieldMeter.value = shieldHP;
            shieldMeter.maxValue = shieldMaxHP;
            hullMeter.value = hullHP;
            hullMeter.maxValue = hullMaxHP;


            if (shieldHP < shieldMaxHP)
            {
                shieldHP += shieldRegen * Time.deltaTime;
                if (shieldHP > shieldMaxHP)
                {
                    shieldHP = shieldMaxHP;
                }


            }

            if (shieldHP <= shieldMinHP)
            {
                shieldHP = shieldMinHP;
            }
            if (hullHP <= 0 && cantDie == false)
            {
                dead = true;
            }
            if (hullHP <= hullMinHP && dead == true)
            {

                StartCoroutine(DestroyNPC());

            }



        playerDistance = marker.GetComponent<MarkerScript>().distanceValue;


            if (currentTarget != null)
            {
                currentTargetDist = Vector3.Distance(currentTarget.transform.position, shipBody.transform.position);
            }

            if (dead == false)
            {
                if (currentTargetDist < distThresh1 && onOffense == true)
                {
                    desiredSpeed = speed1;
                }


                if (currentTargetDist >= distThresh1 && currentTargetDist < distThresh2 && canEngage == true)
                {
                    desiredSpeed = speed2;
                }
                if (currentTargetDist >= distThresh2 && currentTargetDist < distThresh3 && canEngage == true)
                {
                    desiredSpeed = speed3;
                }
                if (currentTargetDist >= distThresh3 && currentTargetDist < distThresh4 && canEngage == true)
                {
                    desiredSpeed = speed4;
                }
                if (currentTargetDist >= distThresh4 && onOffense == true)
                {
                    desiredSpeed = speed5;
                }

                if (currentSpeed < desiredSpeed)
                {
                    currentSpeed += accelerationRate * Time.deltaTime;
                }
                if (currentSpeed > desiredSpeed)
                {
                    currentSpeed -= accelerationRate * Time.deltaTime;
                }
            }

            //if (currentTarget != null & currentTarget.transform.position.z > transform.position.z)
                //        {
                //            Debug.Log("Target is right");
                //            transform.Rotate(0,0,rollRate);
                //        }
                //if (currentTarget.transform.position.z < transform.position.z)
                //{
                //    Debug.Log("Target is left");

                //            transform.Rotate(0, 0, -rollRate);
                //        }

                if (objectiveEnemy == true)
                    objectiveText.enabled = true;
            if (objectiveEnemy == false)
                objectiveText.enabled = false;


            if (attackMarked == true && commandArrow != null)
                commandArrow.SetActive(true);
            if (attackMarked == false && commandArrow != null)
                commandArrow.SetActive(false);
            if (attackMarked2 == true && commandArrow2 != null)
                commandArrow2.SetActive(true);
            if (attackMarked2 == false && commandArrow2 != null)
                commandArrow2.SetActive(false);
            if (attackMarked3 == true && commandArrow3 != null)
                commandArrow3.SetActive(true);
            if (attackMarked3 == false && commandArrow3 != null)
                commandArrow3.SetActive(false);


            if (allyAttacking == true && allyAttackingArrow != null)
                allyAttackingArrow.SetActive(true);
            if (allyAttacking == false && allyAttackingArrow != null)
                allyAttackingArrow.SetActive(false);
            shieldMeter.value = shieldHP;
            hullMeter.value = hullHP;



            

            //       if (Input.GetKeyDown ("b"))
            //       {
            //           onDefense = true;
            //           onOffense = false;
            //      }
            //       if (Input.GetKeyUp("b"))
            //       {
            //           onOffense = true;
            //           onDefense = false;
            //       }


            if (onOffense == true)
            {
                StopCoroutine(EvasionProcess());
            }
            if (canEngage == true)
            {
                StopCoroutine(EvasionProcess());
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentTarget.transform.position - transform.position), rotSpeed * Time.deltaTime);
                //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,currentTarget.transform.rotation.eulerAngles.z);
            }
            if (onDefense == true && stamCurrent >= stamMin)
            {
                StartCoroutine(EvasionProcess());
            }
            if (turnAway == true && dead == false)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentTarget.transform.position + transform.position), rotSpeed * Time.deltaTime);

            }



            //		if (onEvade == true) 
            //		{
            //			onOffense = false;
            //			transform.LookAt(currentTarget);
            ////			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (currentTarget.transform.position - transform.position), rotSpeed * Time.deltaTime);
            //		}
            thrustValue = currentSpeed * 0.5f;

            thrustFX.GetComponent<ParticleSystem>().startSize = thrustValue;
            if (thrustFX2 != null)
            {
                thrustFX2.GetComponent<ParticleSystem>().startSize = thrustValue;
            }
            if (thrustFX3 != null)
            {
                thrustFX3.GetComponent<ParticleSystem>().startSize = thrustValue;

            }
            if (thrustFX4 != null)
            {
                thrustFX4.GetComponent<ParticleSystem>().startSize = thrustValue;

            }
            if (thrustFX5 != null)
            {
                thrustFX5.GetComponent<ParticleSystem>().startSize = thrustValue;

            }

        if (currentTarget != null && currentTarget.GetComponent<MissileWarningScript>() == true)
            {
                playerIsTarget = true;
            }


            if (isAce == true)
            {
                emblem.enabled = true;
            }
            if (isAce == false)
            {
                emblem.enabled = false;
            }

            if (dead == true && dying == false && untouchable == false && cantDie == false)
            {
                //if (attackMarked == true)
                //{
                //gamePlayer.GetComponent<WingmanCommandScript>().wingmanNPC.GetComponent<BasicAI>().WingmanCommandTargets.Remove(shipBody);
                //}
    

                if (objective1Kill == true)
                {
                    missionReference.GetComponent<MissionScript>().objective1Count += 1;
                }
                if (objective2Kill == true)
                {
                    missionReference.GetComponent<MissionScript>().objective2Count += 1;
                }
                dying = true;
                if (shipBody.transform == gamePlayer.GetComponent<TargettingScript>().currentTarget)
                {
                    gamePlayer.GetComponent<TargettingScript>().currentTarget = null;
                }
                if (genericEnemy == true)
                {
                    subtitleObject.GetComponent<DialogueScript>().GenericEnemyKilled();
                }
                if (genericBeta == true)
                {

                    subtitleObject.GetComponent<DialogueScript>().GenericBetaKilled();
                }
            if (genericDelta == true)
            {

                subtitleObject.GetComponent<DialogueScript>().GenericDeltaKilled();
            }
            if (usesList1OnDeath == true)
				{
					subtitleObject.GetComponent<DialogueScript>().SubtitleList1();
				}
				if (usesList2OnDeath == true)
				{
					subtitleObject.GetComponent<DialogueScript>().SubtitleList2();
				}
				if (usesList3OnDeath == true)
				{
					subtitleObject.GetComponent<DialogueScript>().SubtitleList3();
				}
				if (usesList4OnDeath == true)
				{
					subtitleObject.GetComponent<DialogueScript>().SubtitleList4();
				}
				if (usesList5OnDeath == true)
				{
					subtitleObject.GetComponent<DialogueScript>().SubtitleList5();
				}
				if (usesList6OnDeath == true)
				{
					subtitleObject.GetComponent<DialogueScript>().SubtitleList6();
				}
                if (usesList7OnDeath == true)
                {
                    subtitleObject.GetComponent<DialogueScript>().SubtitleList7();
                }
                if (usesList8OnDeath == true)
				{
					subtitleObject.GetComponent<DialogueScript>().SubtitleList8();
				}
				if (usesList9OnDeath == true)
				{
					subtitleObject.GetComponent<DialogueScript>().SubtitleList9();
				}
				if (usesList10OnDeath == true)
				{
					subtitleObject.GetComponent<DialogueScript>().SubtitleList10();
				}
            //Destroy(gameObject, 0.1f);
            StartCoroutine(TimeToDeath());
            killBoom.SetActive(true);
            deathSound1.Play();
            shipBody.transform.Rotate(0,0,0);
            //hitBy = null;
            canEngage = false;
            currentTarget = null;
            Destroy(itemHolder);
            deathFire.SetActive(true);
        }

        }
    IEnumerator WaitRandomly()
    {
        canEngage = false;
        yield return new WaitForSeconds(Random.Range(DelayMin, DelayMax));
        canEngage = true;
        yield return new WaitForSeconds(Random.Range(StartMin, StartMax));
        StartCoroutine(WaitRandomly());
    }

    IEnumerator EvasionProcess()
    {
        stamCurrent -= stamSpend * Time.deltaTime;

        currentSpeed = evadeSpeed;
        turnAway = true;
        yield return new WaitForSeconds(Random.Range(turnAwayRateMin, turnawayRateMax));
        turnAway = false;
        yield return new WaitForSeconds(Random.Range(turnAwayRateMin, turnawayRateMax));
        StartCoroutine(EvasionProcess());
    }

    IEnumerator TimeToDeath()
    {
        //if (gamePlayer == hitBy)
        //{
        //}

        yield return new WaitForSeconds(timeBeforeDeath);
        StartCoroutine(DestroyNPC());
    }

    IEnumerator DestroyNPC()
    {
        if (spawnReference != null && spawnReferenceGroup1 == true)
        {
            spawnReference.GetComponent<MissionSpawner>().respawnValue1 -= 1;
        }
        if (spawnReference != null && spawnReferenceGroup2 == true)
        {
            spawnReference.GetComponent<MissionSpawner>().respawnValue2 -= 1;
        }

        StopCoroutine(TimeToDeath());

        deathSound2.Play();

        Destroy(shipBody.gameObject);


        GetComponent<Collider>().enabled = false;

        deathBoom.SetActive(true);

        yield return new WaitForSeconds(4);

        

        Destroy(gameObject);
    }

    

}