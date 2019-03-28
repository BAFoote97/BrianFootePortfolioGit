using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AITurret : MonoBehaviour {


    public float shieldHP;
    public float shieldMaxHP;
    public float shieldRegen;
    public float shieldMinHP;
    public float hullHP;
    public float hullMaxHP;
    public float hullMinHP;

    public bool usesShield;

    public Slider shieldMeter;
    public Slider hullMeter;

    public GameObject npc;
    public GameObject turretGun;

    public List<Transform> hostiles = new List<Transform>();
    public Transform currentTarget;
    public Transform nextHostile;
    public float currentTargetDist;
    public float playerDistance;
    public Canvas marker;

    public bool canEngage;

    public float rotSpeed;

    public float DelayMin;
    public float DelayMax;

    public float StartMin;
    public float StartMax;

    public bool team1Turret;
    public bool team2Turret;

    public List<GameObject> detectedHostile = new List<GameObject>();
    public List<GameObject> detectedHostile1 = new List<GameObject>();

    public Transform chaseTarget;


    public GameObject Bullet;
    public GameObject bulletEmitter1;
    public GameObject bulletEmitter2;
    public GameObject bulletEmitter3;
    public GameObject bulletEmitter4;
    public GameObject trackingEmitter1;
    public GameObject trackingEmitter2;
    public GameObject trackingEmitter3;
    public GameObject trackingEmitter4;
    public bool canTrack;
    public float trackRotSpeed;
    public float Bullet_Forward_Force;
    public float bulletLifetime;

    public float laserHeat;
    public float laserHeatPlus;
    public float heatMin;
    public float heatMax;
    public float laserCool;
    public float shootDelay;
    public bool overheat;
    public float afterOverheat;

    public float killCooldown;

    public bool permitShoot;
    public bool canShoot;
    public bool shootMissiles;


    // Use this for initialization
    void Start () {

        StartCoroutine(WaitRandomly());

    }
	
	// Update is called once per frame
	void Update () {

        if (team2Turret == true)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Team1Body"))
            {
                hostiles.Add(obj.transform);

            }

            nextHostile = hostiles[0];
            nextHostile = hostiles[Random.Range(0, hostiles.Count)];



            hostiles.Clear();


        }

        if (team1Turret == true)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Team2Body"))
            {
                hostiles.Add(obj.transform);

            }
            if (hostiles[0] != null)
            {
                nextHostile = hostiles[0];
            }

            if (nextHostile != null)
            {
                nextHostile = hostiles[Random.Range(0, hostiles.Count)];
            }


            hostiles.Clear();



        }

        //Debug.Log(currentTarget);

        if (currentTarget == null)
        {
            currentTarget = nextHostile;
        }


        if (usesShield == true)
        {
            shieldMeter.enabled = true;
            shieldMeter.value = shieldHP;
            shieldMeter.maxValue = shieldMaxHP;
        }
        if (usesShield == false)
        {
            shieldMeter.enabled = false;
        }


        hullMeter.value = hullHP;
        hullMeter.maxValue = hullMaxHP;



//        if (npc.GetComponent<BasicAI>().currentTarget != null)
//        {
//            chaseTarget = npc.GetComponent<BasicAI>().currentTarget;
//        }

        if (laserHeat >= heatMax)
        {
            laserHeat = heatMax;
            overheat = true;
        }

        if (laserHeat > heatMin)
        {
            laserHeat -= laserCool * Time.deltaTime;
        }
        if (laserHeat <= heatMin)
        {
            laserHeat = heatMin;
        }
        if (laserHeat <= afterOverheat)
        {
            overheat = false;
        }


        if (team1Turret == true)
        {
            Bullet.GetComponent<BulletScript>().forTeam1 = true;
        }
        if (team2Turret == true)
        {
            Bullet.GetComponent<BulletScript>().forTeam2 = true;
        }
        if (team1Turret == false)
        {
            Bullet.GetComponent<BulletScript>().forTeam1 = false;
        }
        if (team2Turret == false)
        {
            Bullet.GetComponent<BulletScript>().forTeam2 = false;
        }


        if (detectedHostile[0] != null)
        {
            permitShoot = true;
        }
        if (detectedHostile[0] == null)
        {
            detectedHostile.Clear();
            permitShoot = false;
        }



       

        if (turretGun.transform.rotation.y <= 0)
        {
            //turretGun.transform.rotation.y = 0;
        }

        if (canEngage == true)
        {
            turretGun.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentTarget.transform.position - transform.position), rotSpeed * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,currentTarget.transform.rotation.eulerAngles.z);
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (team2Turret == true)
        {
            if (other.gameObject.tag == "Team1Player" || shootMissiles == true && other.gameObject.tag == "Missile" && other.gameObject.GetComponent<MissileScript>().team1 == true)
            {
                //                Debug.Log("Enemy Detected Friendly");
                detectedHostile.Add(other.gameObject);
                //                Debug.Log("Enemy Added Friendly");
                if (other.gameObject == chaseTarget)
                {
                    canTrack = true;
                }
            }
        }
        if (team1Turret == true)
        {
            if (other.gameObject.tag == "Team2Player" || shootMissiles == true && other.gameObject.tag == "Missile" && other.gameObject.GetComponent<MissileScript>().team2 == true)
            {
                //                Debug.Log("Friendly Detected Enemy");
                detectedHostile.Add(other.gameObject);
                //                Debug.Log("Friendly Added Enemy");
                if (other.gameObject == chaseTarget)
                {
                    canTrack = true;
                }
            }



        }


    }
    void OnTriggerExit(Collider other)
    {
        if (team2Turret == true)
        {
            if (other.gameObject.tag == "Team1Player" || shootMissiles == true && other.gameObject.tag == "Missile" && other.gameObject.GetComponent<MissileScript>().team1 == true)
            {
                //                Debug.Log("Enemy Lost Friendly");
                detectedHostile.Remove(other.gameObject);
                //                Debug.Log("Enemy Removed Friendly");
                if (other.gameObject == chaseTarget)
                {
                    canTrack = false;
                }
            }
        }
        if (team1Turret == true)
        {
            if (other.gameObject.tag == "Team2Player" || shootMissiles == true && other.gameObject.tag == "Missile" && other.gameObject.GetComponent<MissileScript>().team2 == true)
            {
                //                Debug.Log("Friendly Lost Enemy");
                detectedHostile.Remove(other.gameObject);
                //                Debug.Log("Friendly Removed Enemy");
                if (other.gameObject == chaseTarget)
                {
                    canTrack = false;
                }

            }
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
}
