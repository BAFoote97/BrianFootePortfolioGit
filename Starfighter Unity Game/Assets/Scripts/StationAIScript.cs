using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationAIScript : MonoBehaviour {

	public int scoreValue;

    public GameObject ifDeadDestroyObject;

    public GameObject playerCharacter;
    public float distanceValue;
    public float distanceReq;
    public Text distanceHUD;
    public bool playerInRange;
    public GameObject visibleInRange;
    public GameObject visibleOutOfRange;

    public GameObject turret1;
    public Transform turret1Target;
    public GameObject turret2;
    public Transform turret2Target;

    public float shieldRegen;
    public float shieldHPMax;
    public float shieldHP;
    public float shieldHPMin;

    public float hullHPMax;
    public float hullHP;
    public float hullHPMin;

    public bool team1;
    public bool team2;

    public bool threatDetected;
	public GameObject spawnOnThreat;
	public bool spawned;

    public GameObject tagHolder;


    public float rotX;
    public float rotY;
    public float rotZ;

    public bool isDead;

    public GameObject subtitleObject;
    public bool usesList1OnLaunch;
    public bool usesList2OnLaunch;
    public bool usesList3OnLaunch;
    public bool usesList4OnLaunch;
    public bool usesList5OnLaunch;
    public bool usesList6OnLaunch;
    public bool usesList7OnLaunch;
    public bool usesList8OnLaunch;
    public bool usesList9OnLaunch;
    public bool usesList10OnLaunch;

    public bool objective1Kill;
    public bool objective2Kill;

    public GameObject missionReference;

    // Use this for initialization
    void Start () {
        subtitleObject = GameObject.FindGameObjectWithTag("SubtitleTag");
        missionReference = GameObject.FindGameObjectWithTag("MissionReference");

    }
	
	// Update is called once per frame
	void Update () {

        playerCharacter = GameObject.FindGameObjectWithTag("Scene Reference").GetComponent<SceneManageScript>().CurrentPlayer.gameObject;

        if (tagHolder != null)
        {
            tagHolder.transform.Rotate(rotX * Time.deltaTime, rotY * Time.deltaTime, rotZ * Time.deltaTime);
        }

        if (shieldHP < shieldHPMax)
        {
            shieldHP += shieldRegen * Time.deltaTime;
        }
        if (shieldHP >= shieldHPMax)
        {
            shieldHP = shieldHPMax;
        }

        if (shieldHP < shieldHPMin)
        {
            shieldHP = shieldHPMin;
        }

        if (hullHP == 0 && isDead == false)
        {
            isDead = true;
            if (objective1Kill == true)
            {
                missionReference.GetComponent<MissionScript>().objective1Count += 1;
            }
            if (objective2Kill == true)
            {
                missionReference.GetComponent<MissionScript>().objective2Count += 1;
            }
			playerCharacter.GetComponent<PlayerStatsScript> ().scoreValue += scoreValue;
            Destroy(ifDeadDestroyObject);

        }

        if (team2 == true && gameObject.GetComponent<SphereThreatDetector>().Team1Threats.Count > 0)
        {
            threatDetected = true;

        }
        if (team1 == true && gameObject.GetComponent<SphereThreatDetector>().Team2Threats.Count > 0)
        {
            threatDetected = true;
        }

        if (team2 == true && threatDetected == true)
        {
            
            if (turret1Target == null && turret1 != null)
            {
                turret1Target = gameObject.GetComponent<SphereThreatDetector>().Team1Threats[Random.Range(0, gameObject.GetComponent<SphereThreatDetector>().Team1Threats.Count)];
            }
            if (turret2Target == null && turret2 != null)
            {
                turret2Target = gameObject.GetComponent<SphereThreatDetector>().Team1Threats[Random.Range(0, gameObject.GetComponent<SphereThreatDetector>().Team1Threats.Count)];
            }
            
            turret1.transform.rotation = Quaternion.Slerp(turret1.transform.rotation, Quaternion.LookRotation(turret1Target.transform.position + transform.position), 100 * Time.deltaTime);
            turret2.transform.rotation = Quaternion.Slerp(turret2.transform.rotation, Quaternion.LookRotation(turret2Target.transform.position + transform.position), 100 * Time.deltaTime);
            

        }
        if (team1 == true && threatDetected == true)
        {
            if (turret1Target == null && turret1 != null)
            {
                turret1Target = gameObject.GetComponent<SphereThreatDetector>().Team2Threats[Random.Range(0, gameObject.GetComponent<SphereThreatDetector>().Team2Threats.Count)];
            }
            if (turret2Target == null && turret2 != null)
            {
                turret2Target = gameObject.GetComponent<SphereThreatDetector>().Team2Threats[Random.Range(0, gameObject.GetComponent<SphereThreatDetector>().Team2Threats.Count)];
            }

        }

        if (turret1Target != null)
        {
            turret1.transform.rotation = Quaternion.Slerp(turret1.transform.rotation, Quaternion.LookRotation(turret1Target.transform.position + transform.position), 100 * Time.deltaTime);
        }
        if (turret2Target != null)
        {
            turret2.transform.rotation = Quaternion.Slerp(turret2.transform.rotation, Quaternion.LookRotation(turret2Target.transform.position + transform.position), 100 * Time.deltaTime);
        }

		if (threatDetected == true && spawned == false) 
		{
			spawned = true;
			Instantiate (spawnOnThreat, spawnOnThreat.transform.position, spawnOnThreat.transform.rotation);
            if (usesList1OnLaunch == true)
            {
                subtitleObject.GetComponent<DialogueScript>().SubtitleList1();
            }
            if (usesList2OnLaunch == true)
            {
                subtitleObject.GetComponent<DialogueScript>().SubtitleList2();
            }
            if (usesList3OnLaunch == true)
            {
                subtitleObject.GetComponent<DialogueScript>().SubtitleList3();
            }
            if (usesList4OnLaunch == true)
            {
                subtitleObject.GetComponent<DialogueScript>().SubtitleList4();
            }
            if (usesList5OnLaunch == true)
            {
                subtitleObject.GetComponent<DialogueScript>().SubtitleList5();
            }
            if (usesList6OnLaunch == true)
            {
                subtitleObject.GetComponent<DialogueScript>().SubtitleList6();
            }
            if (usesList7OnLaunch == true)
            {
                subtitleObject.GetComponent<DialogueScript>().SubtitleList7();
            }
            if (usesList8OnLaunch == true)
            {
                subtitleObject.GetComponent<DialogueScript>().SubtitleList8();
            }
            if (usesList9OnLaunch == true)
            {
                subtitleObject.GetComponent<DialogueScript>().SubtitleList9();
            }
            if (usesList10OnLaunch == true)
            {
                subtitleObject.GetComponent<DialogueScript>().SubtitleList10();
            }
        }

        if (threatDetected == false)
        {
            turret1Target = null;
            turret2Target = null;
        }

        distanceValue = Vector3.Distance(playerCharacter.transform.position, gameObject.transform.position);
        distanceHUD.text = distanceValue.ToString();

        if (distanceValue <= distanceReq)
        {
            playerInRange = true;
            visibleInRange.SetActive(true);
            visibleOutOfRange.SetActive(false);
        }
        if (distanceValue > distanceReq)
        {
            playerInRange = false;
            visibleInRange.SetActive(false);
            visibleOutOfRange.SetActive(true);
        }

        

    }
}
