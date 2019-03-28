using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrimaryLaserScript : MonoBehaviour {

	public GameObject playerObject;
    public GameObject playerBody;

	public float bulletLifetime = 1.0f;
	public GameObject Bullet;
	public GameObject bulletEmitter1;
	public GameObject bulletEmitter2;
	public float Bullet_Forward_Force = 1.0f;
	public bool canShoot;
	public bool heatCooldown;
	public bool cantCooldown;
	public float shootDelay = 0.1f;
	public float overHeatDelay = 1.0f;

	
    public bool overheated;

	public float laserHeat = 0;
    public float laserHeatMin = 0;
	public float maxLaserHeat = 100;
	public float laserHeatPlus = 5;
	public float laserHeatCooldown = 10;
	public float delayBeforeCooldown = 1;

	public static float laserHeatValuetoScript;
	public static float maxLaserHeatValuetoScript;
	//public static int laserHeatPlusValuetoScript;
	//public static int laserHeatCooldownValuetoScript;

	public bool team1;
	public bool team2;

    public bool isActiveWeapon;

    public bool instantiateAsChild;

	void StaticValues()
	{
		laserHeat = laserHeatValuetoScript;
		maxLaserHeat = maxLaserHeatValuetoScript;
		//laserHeatPlusValuetoScript = laserHeatPlus;
		//laserHeatCooldownValuetoScript = laserHeatCooldown;

	}

	float CalculateHeat()
	{
		return laserHeat / maxLaserHeat;
	}

	// Use this for initialization
	void Start () {

		canShoot = true;
		
	}



	IEnumerator coolDelay ()
	{
		yield return new WaitForSeconds (delayBeforeCooldown);
		cantCooldown = false;
//		StartCoroutine (coolLaser ());
	}
//	IEnumerator coolLaser ()
//	{
//		laserHeat -= laserHeatCooldown * Time.deltaTime;
//		if (laserHeat <= 0f) 
//		{
//			laserHeat = 0f;
//			yield return(coolLaser());
//		}
//	}



	// Update is called once per frame
	void Update () {
        if (playerObject.GetComponent<PauseScript>().paused == false)
        {
            if (playerObject.GetComponent<WeaponSelectScript>().activePrimary == gameObject)
            {
                isActiveWeapon = true;
            }
            if (playerObject.GetComponent<WeaponSelectScript>().activePrimary != gameObject)
            {
                isActiveWeapon = false;
            }

            if (team1 == true)
            {
                Bullet.GetComponent<BulletScript>().forTeam1 = true;
                Bullet.GetComponent<BulletScript>().forTeam2 = false;

            }
            if (team2 == true)
            {
                Bullet.GetComponent<BulletScript>().forTeam2 = true;
                Bullet.GetComponent<BulletScript>().forTeam1 = false;


            }

            

            if (laserHeat >= maxLaserHeat && canShoot == true)
            {
                canShoot = false;
                overheated = true;

            }
            if (laserHeat == laserHeatMin)
            {
                canShoot = true;
                overheated = false;
            }


            if (Input.GetMouseButton(0) && canShoot == true && isActiveWeapon == true && instantiateAsChild == false)
            {
                Bullet.GetComponent<BulletScript>().player = playerObject;
                Bullet.GetComponent<BulletScript>().isPlayerBullet = true;

                //Debug.Log ("Player fired");

                //The Bullet Instantiation happens here.
                GameObject Temporary_Bullet_handler;

                Temporary_Bullet_handler = Instantiate(Bullet, bulletEmitter1.transform.position, bulletEmitter1.transform.rotation) as GameObject;
                //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
                //This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
                Temporary_Bullet_handler.transform.Rotate(Vector3.left);

                //Retrieve the Rigidbody component from the instantiated Bullet and control it.
                Rigidbody Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody>();

                //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
                Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force, ForceMode.Impulse);

                //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
                Destroy(Temporary_Bullet_handler, bulletLifetime);


                Temporary_Bullet_handler = Instantiate(Bullet, bulletEmitter2.transform.position, bulletEmitter2.transform.rotation) as GameObject;
                //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
                //This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
                Temporary_Bullet_handler.transform.Rotate(Vector3.left);

                //Retrieve the Rigidbody component from the instantiated Bullet and control it.
                Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody>();

                //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
                Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force, ForceMode.Impulse);

                //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
                Destroy(Temporary_Bullet_handler, bulletLifetime);

                laserHeat = laserHeat + laserHeatPlus;
                StartCoroutine(coolDelay());

                StopCoroutine(coolDelay());
                //			StopCoroutine (coolLaser ());
                cantCooldown = true;
                heatCooldown = false;
                canShoot = false;
                StartCoroutine(fireDelay());

            }

            if (Input.GetMouseButton(0) && canShoot == true && isActiveWeapon == true && instantiateAsChild == true)
            {
                //Bullet.transform.SetParent(gameObject.transform);
                Bullet.GetComponent<BulletScript>().player = playerObject;


                //Debug.Log ("Player fired");

                //The Bullet Instantiation happens here.
                GameObject Temporary_Bullet_handler;

                Temporary_Bullet_handler = Instantiate(Bullet, (bulletEmitter1.transform.position), Quaternion.identity) as GameObject;
                //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
                //This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
                Temporary_Bullet_handler.transform.parent = bulletEmitter1.transform;

                //Retrieve the Rigidbody component from the instantiated Bullet and control it.
                Rigidbody Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody>();

                //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
                Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force, ForceMode.Impulse);

                //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
                Destroy(Temporary_Bullet_handler, bulletLifetime);


                Temporary_Bullet_handler = Instantiate(Bullet, (bulletEmitter2.transform.position), Quaternion.identity) as GameObject;
                //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
                //This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
                Temporary_Bullet_handler.transform.parent = bulletEmitter2.transform;

                //Retrieve the Rigidbody component from the instantiated Bullet and control it.
                Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody>();

                //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
                Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force, ForceMode.Impulse);

                //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
                Destroy(Temporary_Bullet_handler, bulletLifetime);

                laserHeat = laserHeat + laserHeatPlus;
                StartCoroutine(coolDelay());

                StopCoroutine(coolDelay());
                //			StopCoroutine (coolLaser ());
                cantCooldown = true;
                heatCooldown = false;
                canShoot = false;
                StartCoroutine(fireDelay());

            }


        }
	}


	IEnumerator fireDelay ()
	{
		yield return new WaitForSeconds(shootDelay);
		canShoot = true;
	}

	void LateUpdate ()
	{
		if (cantCooldown == false) 
		{
			laserHeat -= laserHeatCooldown * Time.deltaTime;
			if (laserHeat <= 0f) 
			{
				laserHeat = 0f;
			}
		}

	}
}
