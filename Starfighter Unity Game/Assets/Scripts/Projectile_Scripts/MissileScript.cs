using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour {

    public GameObject playerObject;
    public PauseScript gamePlayer;

    public Transform seekTarget;
    public GameObject missileLauncher;
    public Rigidbody myRigidBody;

    public bool lockedOnTarget;
    public bool targetIsPlayer;

    public float missileHealth = 1;

    public float turnSensitivity = 1.0f;
    public float moveSpeed = 1.0f;

    public float seekTime = 1.0f;

    public int impactDamage = 1;
    public int splashDamage = 1;
    public int explosionRange = 1;

    public AudioSource missileLaunch;
    public GameObject Projectile;
    public GameObject explosionArea;
    public GameObject explosionFX;
    public GameObject explosionSFX;
    public ParticleSystem bulletFire;
    public float explosionTime;
    public bool canPassThru;
    public BoxCollider hitBox;

    public bool invincible;

    public bool playerMissile;

    public bool team1;
    public bool team2;
    public bool isPlayerMissile;

    // Use this for initialization
    void Start() {
        //		lockedOnTarget = false;
        StartCoroutine(CancelSeek());
        missileLaunch.GetComponent<AudioSource>().pitch = (Random.Range(0.95f, 2f));
        if (isPlayerMissile == true)
        {
            missileLaunch.GetComponent<AudioSource>().spatialBlend = 0.5f;
        }

    }

    // Update is called once per frame
    void Update() {
        gamePlayer = FindObjectOfType<PauseScript>();

        if (gamePlayer.GetComponent<PauseScript>().paused == false)
        {


        transform.Translate(0, 0, moveSpeed);
        //myRigidBody.AddForce(transform.forward * moveSpeed);


        if (lockedOnTarget == true && seekTarget != null)
            {

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(seekTarget.transform.position - transform.position), turnSensitivity * Time.deltaTime);
                //			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (seekTarget.transform.position - transform.position), turnSensitivity * Time.deltaTime);
            }

            if (targetIsPlayer == true && seekTarget != null)
            {
                seekTarget.GetComponent<MissileWarningScript>().incomingMissiles.Add(gameObject);
            }

            


            //		if (seekTarget != null) 
            //		{
            //			lockedOnTarget = true;
            //		}
            //		if (seekTarget == null) 
            //		{
            //			lockedOnTarget = false;
            //		}

            if (missileHealth <= 0)
            {
                //				Debug.Log ("Bullet hit");
                //			bulletDestroySFX.PlayOneShot (bulletDestroySFX.clip);
                //Projectile.GetComponent<MeshRenderer> ().enabled = false;
                Destroy(bulletFire);
                Destroy(Projectile);
                Destroy(hitBox);


                //this.bulletDestroySFX.GetComponent<BoxCollider> ().enabled = false;

                GameObject FX_Handler;
                GameObject SFX_Handler;

                explosionSFX.GetComponent<AudioSource>().pitch = (Random.Range(0.85f, 1.1f));


                FX_Handler = Instantiate(explosionFX, explosionArea.transform.position, explosionArea.transform.rotation) as GameObject;
                SFX_Handler = Instantiate(explosionSFX, explosionArea.transform.position, explosionArea.transform.rotation) as GameObject;

                if (targetIsPlayer == true)
                {
                    seekTarget.GetComponent<MissileWarningScript>().incomingMissiles.Remove(gameObject);
                }

                Destroy(this.gameObject);
                Destroy(FX_Handler, explosionTime);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "ColObject")
        {
            if (other.gameObject.GetComponent<AsteroidScript>() == true)
            {
                other.gameObject.GetComponent<AsteroidScript>().asteroidHP -= impactDamage;
            }
            //				Debug.Log ("Bullet hit");
            //			bulletDestroySFX.PlayOneShot (bulletDestroySFX.clip);
            //Projectile.GetComponent<MeshRenderer> ().enabled = false;

            if (targetIsPlayer == true)
            {
                seekTarget.GetComponent<MissileWarningScript>().incomingMissiles.Remove(gameObject);
            }

            Destroy(bulletFire);
            Destroy(Projectile);
            Destroy(hitBox);


            //this.bulletDestroySFX.GetComponent<BoxCollider> ().enabled = false;

            GameObject FX_Handler;
            GameObject SFX_Handler;

            explosionSFX.GetComponent<AudioSource>().pitch = (Random.Range(0.85f, 1.1f));


            FX_Handler = Instantiate(explosionFX, explosionArea.transform.position, explosionArea.transform.rotation) as GameObject;
            SFX_Handler = Instantiate(explosionSFX, explosionArea.transform.position, explosionArea.transform.rotation) as GameObject;


            Destroy(this.gameObject);
            Destroy(FX_Handler, explosionTime);
        }
        //		if (other.gameObject.tag == "Team1Player") {
        //			//				Debug.Log ("Bullet hit");
        //			//			bulletDestroySFX.PlayOneShot (bulletDestroySFX.clip);
        //			//Projectile.GetComponent<MeshRenderer> ().enabled = false;
        //			Destroy (bulletFire);
        //			Destroy (Projectile);
        //			Destroy (hitBox);
        //
        //
        //			//this.bulletDestroySFX.GetComponent<BoxCollider> ().enabled = false;
        //
        //			GameObject FX_Handler;
        //
        //
        //			FX_Handler = Instantiate (explosionFX, explosionArea.transform.position, explosionArea.transform.rotation) as GameObject;
        //
        //			Destroy (this.gameObject, 0.2f);
        //			Destroy (FX_Handler, explosionTime);
        //		}
		if (other.gameObject.tag == "ColObject" && other.gameObject.GetComponent<MiscColHealthScript>() == true && other.gameObject.GetComponent<MiscColHealthScript>().team2 == true)
		{

			if (other.gameObject.GetComponent<MiscColHealthScript>().usesShield == true && other.gameObject.GetComponent<MiscColHealthScript>().singlePiece == true)
			{
				other.gameObject.GetComponent<MiscColHealthScript>().shieldHP -= impactDamage;
			}
			if (other.gameObject.GetComponent<MiscColHealthScript>().usesShield == true && other.gameObject.GetComponent<MiscColHealthScript>().singlePiece == false)
			{
				other.gameObject.GetComponent<MiscColHealthScript>().wholeObject.GetComponent<StationAIScript>().shieldHP -= impactDamage;
			}

			if (other.gameObject.GetComponent<MiscColHealthScript>().usesShield == true && other.gameObject.GetComponent<MiscColHealthScript>().shieldHP <= 0 || other.gameObject.GetComponent<MiscColHealthScript>().usesShield == false)
			{
				other.gameObject.GetComponent<MiscColHealthScript>().hullHP -= impactDamage;

			}
		}

        if (other.gameObject.tag == "Team1Player" && team2 == true)
        {

            if (other.gameObject.GetComponent<PlayerStatsScript>().shieldProtectsMissiles == true)
            {
                other.gameObject.GetComponent<PlayerStatsScript>().shieldHP -= impactDamage;
                if (other.gameObject.GetComponent<PlayerStatsScript>().shieldHP <= 0)
                {
                    other.gameObject.GetComponent<PlayerStatsScript>().hullHP -= impactDamage;
                }
            }
            if (other.gameObject.GetComponent<PlayerStatsScript>().shieldProtectsMissiles == false)
            {
                other.gameObject.GetComponent<PlayerStatsScript>().shieldHP -= impactDamage;
                other.gameObject.GetComponent<PlayerStatsScript>().hullHP -= impactDamage;
            }
            //			Debug.Log ("HitTarget");
            //				Debug.Log ("Bullet hit");
            //			bulletDestroySFX.PlayOneShot (bulletDestroySFX.clip);
            //Projectile.GetComponent<MeshRenderer> ().enabled = false;

            if (targetIsPlayer == true)
            {
                seekTarget.GetComponent<MissileWarningScript>().incomingMissiles.Remove(gameObject);
            }

            Destroy(bulletFire);
            Destroy(Projectile);
            Destroy(hitBox);


            //this.bulletDestroySFX.GetComponent<BoxCollider> ().enabled = false;

            GameObject FX_Handler;
            GameObject SFX_Handler;

            explosionSFX.GetComponent<AudioSource>().pitch = (Random.Range(0.85f, 1.1f));

            FX_Handler = Instantiate(explosionFX, explosionArea.transform.position, explosionArea.transform.rotation) as GameObject;
            SFX_Handler = Instantiate(explosionSFX, explosionArea.transform.position, explosionArea.transform.rotation) as GameObject;


            Destroy(this.gameObject, 0f);
            Destroy(FX_Handler, explosionTime);
        }
        if (other.gameObject.tag == "Team2Player" && team1 == true && other.gameObject.GetComponent<BasicAI>().untouchable == false)
        {
            if (other.gameObject.GetComponent<BasicAI>().dead == false && other.gameObject.GetComponent<BasicAI>().dying == false)
            {
                other.GetComponent<BasicAI>().hitBy = playerObject;
            }
            if (other.gameObject.GetComponent<BasicAI>().shieldProtectsMissiles == true) {
                other.gameObject.GetComponent<BasicAI>().shieldHP -= impactDamage;
                if (other.gameObject.GetComponent<BasicAI>().shieldHP <= 0) {
                    other.gameObject.GetComponent<BasicAI>().hullHP -= impactDamage;
                    if (playerObject.GetComponent<PlayerStatsScript>() == true)
                    {
                            playerObject.GetComponent<PlayerStatsScript>().scoreValue += other.gameObject.GetComponent<BasicAI>().scoreValue * impactDamage;
                    }
                }
            }
            if (other.gameObject.GetComponent<BasicAI>().shieldProtectsMissiles == false) {
                other.gameObject.GetComponent<BasicAI>().shieldHP -= impactDamage;
                other.gameObject.GetComponent<BasicAI>().hullHP -= impactDamage;
                if (playerObject.GetComponent<PlayerStatsScript>() == true)
                {
                    playerObject.GetComponent<PlayerStatsScript>().scoreValue += other.gameObject.GetComponent<BasicAI>().scoreValue * impactDamage;
                }
            }
            //			Debug.Log ("HitTarget");
            //				Debug.Log ("Bullet hit");
            //			bulletDestroySFX.PlayOneShot (bulletDestroySFX.clip);
            //Projectile.GetComponent<MeshRenderer> ().enabled = false;
            Destroy(bulletFire);
            Destroy(Projectile);
            Destroy(hitBox);


            //this.bulletDestroySFX.GetComponent<BoxCollider> ().enabled = false;

            GameObject FX_Handler;
            GameObject SFX_Handler;

            explosionSFX.GetComponent<AudioSource>().pitch = (Random.Range(0.85f, 1.1f));

            FX_Handler = Instantiate(explosionFX, explosionArea.transform.position, explosionArea.transform.rotation) as GameObject;
            SFX_Handler = Instantiate(explosionSFX, explosionArea.transform.position, explosionArea.transform.rotation) as GameObject;


            Destroy(this.gameObject, 0f);
            Destroy(FX_Handler, explosionTime);
        }
    }




    IEnumerator CancelSeek(){
        yield return new WaitForSeconds(seekTime);
        seekTarget = null;
        if (targetIsPlayer == true)
        {
            seekTarget.GetComponent<MissileWarningScript>().incomingMissiles.Remove(gameObject);
        }
    }
}
