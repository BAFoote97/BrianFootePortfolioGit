using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMissileLauncher : MonoBehaviour {

	public GameObject playerObject;


	public List <GameObject> targets = new List<GameObject> ();

	public Transform lockedTarget;
	public AudioSource lockedOnSFX;

	public GameObject lockText;

	public float bulletLifetime = 1.0f;
	public GameObject Bullet;
	public GameObject bulletEmitter1;
	public GameObject bulletEmitter2;
	public float Bullet_Forward_Force = 1.0f;
	public bool lockedOn;
	public bool heatCooldown;
	public bool cantCooldown;
	public float shootDelay = 0.1f;
	public float overHeatDelay = 1.0f;

    public bool alternateEmitters;
    public bool isEmitter1;
    public bool isEmitter2;
    public GameObject currentEmitter;
    

	//public Text noAmmoText;

    

	public float missileShootValue;
    public float missileMax;
	public float missileLimit;
	public float missileIncrease;
	public float missileCooldown;
    public bool overShoot;
    public bool canFire;
    public float ammoMax;
    public float ammoCount;
    public float ammoSpend;

    public bool targetIsHostile;

    public bool team1;
    public bool team2;

    public bool isActiveWeapon;
    public GameObject weaponHighlight;
    public GameObject ammoHighlight;

    public bool cantLockOn;

    // Use this for initialization
    void Start () {
        //noAmmoText.enabled = false;
		lockText.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
        if (playerObject.GetComponent<WeaponSelectScript>().activeSecondary == gameObject)
        {
            isActiveWeapon = true;
        }
        if (playerObject.GetComponent<WeaponSelectScript>().activeSecondary != gameObject)
        {
            isActiveWeapon = false;
        }

        if (ammoCount > 0 && overShoot == false)
        {
            canFire = true;
        }

        if (ammoCount <= 0)
        {
            //noAmmoText.enabled = true;
            ammoCount = 0;
            canFire = false;
        }

        if (missileShootValue > 0)
        {
            missileShootValue -= missileCooldown * Time.deltaTime;
        }
        if (missileShootValue >= missileLimit)
        {
            missileShootValue = missileLimit;
        }
        if (missileShootValue > missileMax)
        {
            canFire = false;
            overShoot = true;
        }
        if (missileShootValue < missileMax)
        {
            overShoot = false;
        }

        if (playerObject.GetComponent<TargettingScript>().currentTarget != null)
        {
            lockedTarget = playerObject.GetComponent<TargettingScript>().currentTarget;
        }
        if (lockedTarget == null)
            lockedOn = false;


        if (playerObject.GetComponent<TargettingScript>().currentTargetIsFriendly == true)
        {
            targetIsHostile = false;
        }
        if (playerObject.GetComponent<TargettingScript>().currentTargetIsFriendly == false)
        {
            targetIsHostile = true;
        }

        Bullet.GetComponent<MissileScript>().playerMissile = true;

        Bullet.GetComponent<MissileScript> ().seekTarget = lockedTarget;
        if (team1 == true)
        {
            Bullet.GetComponent<MissileScript>().team1 = true;
        }
        if (team2 == true)
        {
            Bullet.GetComponent<MissileScript>().team2 = true;
        }

        if (isActiveWeapon == true)
        {
            weaponHighlight.SetActive(true);
            ammoHighlight.SetActive(true);
        }
        if (isActiveWeapon == false)
        {
            weaponHighlight.SetActive(false);
            ammoHighlight.SetActive(false);
            lockedOn = false;

        }

        if (lockedOn == true && targetIsHostile == true && isActiveWeapon == true) {

			lockedTarget.GetComponent<Team2LockOnMe> ().isLockedOnByPlayer = true;
            lockText.SetActive(true);


            Bullet.GetComponent<MissileScript> ().lockedOnTarget = true;
			lockedOnSFX.Play();
		}
		if (lockedOn == false) {
            lockedOnSFX.Stop();
            //lockText.SetActive(false);
			//lockedTarget.GetComponent<Team2LockOnMe> ().isLockedOnByPlayer = false;
            
            Bullet.GetComponent<MissileScript> ().lockedOnTarget = false;

		}
        if (isEmitter1 == true)
        {
            currentEmitter = bulletEmitter1;
        }
        if (isEmitter2 == true)
        {
            currentEmitter = bulletEmitter2;
        }

        if (Input.GetMouseButtonDown (2) && canFire == true && isActiveWeapon == true && alternateEmitters == false) 
		{
            Bullet.GetComponent<MissileScript>().playerObject = playerObject;
            Bullet.GetComponent<MissileScript>().isPlayerMissile = true;
            ammoCount = ammoCount - ammoSpend;
            missileShootValue += missileIncrease;
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
		}
        if (Input.GetMouseButtonDown(2) && canFire == true && isActiveWeapon == true && alternateEmitters == true)
        {
            Bullet.GetComponent<MissileScript>().playerObject = playerObject;
            Bullet.GetComponent<MissileScript>().isPlayerMissile = true;
            isEmitter1 = !isEmitter1;
            isEmitter2 = !isEmitter2;
            ammoCount = ammoCount - ammoSpend;
            missileShootValue += missileIncrease;
            //The Bullet Instantiation happens here.
            GameObject Temporary_Bullet_handler;

            Temporary_Bullet_handler = Instantiate(Bullet, currentEmitter.transform.position, currentEmitter.transform.rotation) as GameObject;
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
        }

        if (lockedTarget != null && lockedTarget.GetComponent<Team2LockOnMe>() == true && lockedTarget.GetComponent<Team2LockOnMe>().isDead == true)
        {
            lockedOn = false;
            lockText.SetActive(false);

        }
        //lockedTarget = null;

    }

    private void LateUpdate()
    {

    }

    void SwitchEmitters()
    {
    }

	void OnTriggerStay (Collider target){

		if (target.gameObject.transform == lockedTarget && lockedTarget.GetComponent<Team2LockOnMe>().isDead == false && cantLockOn == false)
		lockedOn = true;
        if (target.gameObject.transform == lockedTarget && lockedTarget.GetComponent<Team2LockOnMe>().isDead == true)
            lockedOn = false;


        //if (target.gameObject.transform != lockedTarget)
        //    lockedOn = false;

    }


	void OnTriggerExit (Collider target){

		if (target.gameObject.transform == lockedTarget)
		lockedOn = false;
        if (targetIsHostile == true)
        {
            lockText.SetActive(false);

            lockedTarget.GetComponent<Team2LockOnMe>().isLockedOnByPlayer = false;
        }


	}
}
