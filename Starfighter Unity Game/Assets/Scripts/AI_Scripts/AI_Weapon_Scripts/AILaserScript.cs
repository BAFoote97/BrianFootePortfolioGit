using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILaserScript : MonoBehaviour {

	public GameObject npc;
	public Transform chaseTarget;
    //	public GameObject coneTrigger;

    public List<GameObject> detectedHostile = new List<GameObject>();

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


	public bool team1;
	public bool team2;



	// Use this for initialization
	void Start () {
		
	}


	
	// Update is called once per frame
	void Update () {
		//if (npc.GetComponent<BasicAI> ().currentTarget != null) {
		//	chaseTarget = npc.GetComponent<BasicAI> ().currentTarget;
		//}

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

		if (team1 == true) {
			Bullet.GetComponent<BulletScript> ().forTeam1 = true;
		}
		if (team2 == true) {
			Bullet.GetComponent<BulletScript> ().forTeam2 = true;
		}
		if (team1 == false) {
			Bullet.GetComponent<BulletScript> ().forTeam1 = false;
		}
		if (team2 == false) {
			Bullet.GetComponent<BulletScript> ().forTeam2 = false;
		}

        if (detectedHostile.Count > 0)
        {
            permitShoot = true;
        }
        if (detectedHostile.Count == 0)
        {
            detectedHostile.Clear();
            permitShoot = false;
        }

 //       if (detectedHostile[0] != null && team2 == true)
 //       {
 //           permitShoot = true;
 //       }
 //       if (detectedHostile[0] == null && team2 == true)
 //       {
 //           detectedHostile.Clear();
 //           permitShoot = false;
 //       }

		if (canTrack == true) {
			if (trackingEmitter1 != null) 
			{
				trackingEmitter1.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (chaseTarget.transform.position + transform.position), trackRotSpeed * Time.deltaTime);
			}
			if (trackingEmitter2 != null) 
			{
				trackingEmitter2.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (chaseTarget.transform.position + transform.position), trackRotSpeed * Time.deltaTime);
			}
			if (trackingEmitter3 != null) 
			{
				trackingEmitter3.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (chaseTarget.transform.position + transform.position), trackRotSpeed * Time.deltaTime);
			}
			if (trackingEmitter4 != null) 
			{
				trackingEmitter4.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (chaseTarget.transform.position + transform.position), trackRotSpeed * Time.deltaTime);
			}
			
		}

		if (canTrack == false) {
			if (trackingEmitter1 != null) {
				trackingEmitter1.transform.rotation = Quaternion.Euler(0, 0, 0);
			}
			if (trackingEmitter2 != null) {
				trackingEmitter2.transform.rotation = Quaternion.Euler (0, 0, 0);
			}
			if (trackingEmitter3 != null) {
				trackingEmitter3.transform.rotation = Quaternion.Euler (0, 0, 0);
			}
			if (trackingEmitter4 != null) {
				trackingEmitter4.transform.rotation = Quaternion.Euler (0, 0, 0);
			}
		}

        if (npc != null && npc.GetComponent<BasicAI>().onOffense == true && permitShoot == true && canShoot == true && overheat == false || 
            npc == null && permitShoot == true && canShoot == true && overheat == false) {

			//The Bullet Instantiation happens here.
			GameObject Temporary_Bullet_handler;

//			Temporary_Bullet_handler = Instantiate (Bullet, bulletEmitter1.transform.position, bulletEmitter1.transform.rotation) as GameObject;
//			//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
//			//This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
//			Temporary_Bullet_handler.transform.Rotate (Vector3.left);

			//Retrieve the Rigidbody component from the instantiated Bullet and control it.
			Rigidbody Temporary_RigidBody;
//			Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody> ();
//
//			//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
//			Temporary_RigidBody.AddForce (transform.forward * Bullet_Forward_Force, ForceMode.Impulse);
//
//			//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
//			Destroy (Temporary_Bullet_handler, bulletLifetime);
			if (bulletEmitter1 != null)
			{

				Temporary_Bullet_handler = Instantiate(Bullet, bulletEmitter1.transform.position, bulletEmitter1.transform.rotation) as GameObject;
				//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
				//This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
				Temporary_Bullet_handler.transform.Rotate(Vector3.left);

				//Retrieve the Rigidbody component from the instantiated Bullet and control it.
				Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody>();

				//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
				Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force, ForceMode.Impulse);

				//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
				Destroy(Temporary_Bullet_handler, bulletLifetime);
			}

            if (bulletEmitter2 != null)
                {

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
                }
			if (bulletEmitter3 != null)
			{

				Temporary_Bullet_handler = Instantiate(Bullet, bulletEmitter3.transform.position, bulletEmitter3.transform.rotation) as GameObject;
				//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
				//This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
				Temporary_Bullet_handler.transform.Rotate(Vector3.left);

				//Retrieve the Rigidbody component from the instantiated Bullet and control it.
				Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody>();

				//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
				Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force, ForceMode.Impulse);

				//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
				Destroy(Temporary_Bullet_handler, bulletLifetime);
			}
			if (bulletEmitter4 != null)
			{

				Temporary_Bullet_handler = Instantiate(Bullet, bulletEmitter4.transform.position, bulletEmitter4.transform.rotation) as GameObject;
				//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
				//This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
				Temporary_Bullet_handler.transform.Rotate(Vector3.left);

				//Retrieve the Rigidbody component from the instantiated Bullet and control it.
				Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody>();

				//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
				Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force, ForceMode.Impulse);

				//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
				Destroy(Temporary_Bullet_handler, bulletLifetime);
			}
			if (trackingEmitter1 != null)
			{

				Temporary_Bullet_handler = Instantiate(Bullet, trackingEmitter1.transform.position, trackingEmitter1.transform.rotation) as GameObject;
				//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
				//This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
				Temporary_Bullet_handler.transform.Rotate(Vector3.left);

				//Retrieve the Rigidbody component from the instantiated Bullet and control it.
				Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody>();

				//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
				Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force, ForceMode.Impulse);

				//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
				Destroy(Temporary_Bullet_handler, bulletLifetime);
			}
			if (trackingEmitter2 != null)
			{

				Temporary_Bullet_handler = Instantiate(Bullet, trackingEmitter2.transform.position, trackingEmitter2.transform.rotation) as GameObject;
				//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
				//This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
				Temporary_Bullet_handler.transform.Rotate(Vector3.left);

				//Retrieve the Rigidbody component from the instantiated Bullet and control it.
				Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody>();

				//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
				Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force, ForceMode.Impulse);

				//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
				Destroy(Temporary_Bullet_handler, bulletLifetime);
			}
			if (trackingEmitter3 != null)
			{

				Temporary_Bullet_handler = Instantiate(Bullet, trackingEmitter3.transform.position, trackingEmitter3.transform.rotation) as GameObject;
				//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
				//This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
				Temporary_Bullet_handler.transform.Rotate(Vector3.left);

				//Retrieve the Rigidbody component from the instantiated Bullet and control it.
				Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody>();

				//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
				Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force, ForceMode.Impulse);

				//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
				Destroy(Temporary_Bullet_handler, bulletLifetime);
			}
			if (trackingEmitter4 != null)
			{

				Temporary_Bullet_handler = Instantiate(Bullet, trackingEmitter4.transform.position, trackingEmitter4.transform.rotation) as GameObject;
				//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
				//This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
				Temporary_Bullet_handler.transform.Rotate(Vector3.left);

				//Retrieve the Rigidbody component from the instantiated Bullet and control it.
				Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody>();

				//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
				Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force, ForceMode.Impulse);

				//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
				Destroy(Temporary_Bullet_handler, bulletLifetime);
			}

            laserHeat += laserHeatPlus;
			canShoot = false;
			StartCoroutine (fireDelay());
		}

        detectedHostile.Clear();
	}



	IEnumerator fireDelay ()
	{
		yield return new WaitForSeconds(shootDelay);
		canShoot = true;
	}

    
	void OnTriggerStay (Collider other){
		if (team2 == true) {
            if (other.gameObject.tag == "Team1Player" || shootMissiles == true && other.gameObject.tag == "Missile" && other.gameObject.GetComponent<MissileScript>().team1 == true)
            {
                //Debug.Log("Enemy Detected Friendly");
                detectedHostile.Add(other.gameObject);
                //Debug.Log("Enemy Added Friendly");
				if (other.gameObject == chaseTarget)
				{
					canTrack = true;
				}
            }
        }
        if (team1 == true)
        {
            if (other.gameObject.tag == "Team2Player"  || shootMissiles == true && other.gameObject.tag == "Missile" && other.gameObject.GetComponent<MissileScript>().team2 == true || 
                other.gameObject.tag == "ColObject" && other.gameObject.GetComponent<MiscColHealthScript>() == true && other.GetComponent<MiscColHealthScript>().team2 == true)
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
    //void ontriggerexit(collider other)
    //{
    //    if (team2 == true)
    //    {
    //        if (other.gameobject.tag == "team1player" || shootmissiles == true && other.gameobject.tag == "missile" && other.gameobject.getcomponent<missilescript>().team1 == true)
    //        {
    //            //                debug.log("enemy lost friendly");
    //            detectedhostile.remove(other.gameobject);
    //            //                debug.log("enemy removed friendly");
    //            if (other.gameobject == chasetarget)
    //            {
    //                cantrack = false;
    //            }
    //        }
    //    }
    //    if (team1 == true)
    //    {
    //        if (other.gameobject.tag == "team2player" || shootmissiles == true && other.gameobject.tag == "missile" && other.gameobject.getcomponent<missilescript>().team2 == true)
    //        {
    //            //                debug.log("friendly lost enemy");
    //            detectedhostile.remove(other.gameobject);
    //            //                debug.log("friendly removed enemy");
    //            if (other.gameobject == chasetarget)
    //            {
    //                cantrack = false;
    //            }

    //        }
    //    }
    //}
}
