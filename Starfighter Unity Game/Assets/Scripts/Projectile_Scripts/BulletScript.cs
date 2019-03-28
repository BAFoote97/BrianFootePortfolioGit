using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public int bulletDmg = 1;

	public GameObject player;

	public AudioSource bulletSFX;
    public float pitchMin;
    public float pitchMax;
	public GameObject Projectile;
	public GameObject explosionArea;
	public GameObject explosionFX;
	public ParticleSystem bulletFire;
	public float explosionTime;
	public bool canPassThru;
	public BoxCollider hitBox;


	public bool forTeam1;
	public bool forTeam2;

    public bool isPlayerBullet;

    public bool canKill;

	// Use this for initialization
	void Start () {
		bulletSFX.GetComponent<AudioSource> ().pitch = (Random.Range (pitchMin,pitchMax));
        canKill = true;
        if (isPlayerBullet == true)
        {
            bulletSFX.GetComponent<AudioSource>().spatialBlend = 0.5f;
        }
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}

	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.tag == "ColObject") {


            if (other.gameObject.GetComponent<AsteroidScript>() == true)
            {
                other.gameObject.GetComponent<AsteroidScript>().asteroidHP -= bulletDmg;
            }

//				Debug.Log ("Bullet hit");
//			bulletDestroySFX.PlayOneShot (bulletDestroySFX.clip);
				//Projectile.GetComponent<MeshRenderer> ().enabled = false;
			Destroy (bulletFire);
			Destroy (Projectile);
			Destroy (hitBox);


				//this.bulletDestroySFX.GetComponent<BoxCollider> ().enabled = false;

			GameObject FX_Handler;


			FX_Handler = Instantiate (explosionFX, explosionArea.transform.position, explosionArea.transform.rotation) as GameObject;

			Destroy (this.gameObject, 0.2f);
			Destroy (FX_Handler, explosionTime);
		}
		if (forTeam1 == true) {

			if (other.gameObject.tag == "Team2Player" && other.gameObject.GetComponent<BasicAI>().untouchable == false) {
                

                if (other.gameObject.GetComponent<BasicAI>().dead == false && other.gameObject.GetComponent<BasicAI>().dying == false)
                {
                    other.GetComponent<BasicAI>().hitBy = player;
                }
                    other.gameObject.GetComponent<BasicAI>().shieldHP -= bulletDmg;

                    if (other.gameObject.GetComponent<BasicAI>().shieldHP <= 0)
                    {
                        other.gameObject.GetComponent<BasicAI>().hullHP -= bulletDmg;
                    if (player.GetComponent<PlayerStatsScript>() == true)
                    {
                        player.GetComponent<PlayerStatsScript>().scoreValue += other.gameObject.GetComponent<BasicAI>().scoreValue * bulletDmg;
                    }
                    }

                    //				Debug.Log ("Bullet hit");
                    //			bulletDestroySFX.PlayOneShot (bulletDestroySFX.clip);
                    //Projectile.GetComponent<MeshRenderer> ().enabled = false;
                    Destroy(bulletFire);
                    Destroy(Projectile);
                    Destroy(hitBox);
                

                //this.bulletDestroySFX.GetComponent<BoxCollider> ().enabled = false;

                GameObject FX_Handler;


                    FX_Handler = Instantiate(explosionFX, explosionArea.transform.position, explosionArea.transform.rotation) as GameObject;
                
                canKill = false;
                if (player != null && other.gameObject.GetComponent<BasicAI>().dead == true) {
					player.GetComponent<PlayerStatsScript> ().scoreValue += other.gameObject.GetComponent<BasicAI> ().scoreValue;
				}
                    Destroy(this.gameObject, 0.2f);
                    Destroy(FX_Handler, explosionTime);
                
			}

            if (other.gameObject.tag == "Missile" && other.gameObject.GetComponent<MissileScript>().invincible == false && other.gameObject.GetComponent<MissileScript>().team1 == false)
            {
                other.gameObject.GetComponent<MissileScript>().missileHealth -= bulletDmg;
                //				Debug.Log ("Bullet hit");
                //			bulletDestroySFX.PlayOneShot (bulletDestroySFX.clip);
                //Projectile.GetComponent<MeshRenderer> ().enabled = false;
                Destroy(bulletFire);
                Destroy(Projectile);
                Destroy(hitBox);


                //this.bulletDestroySFX.GetComponent<BoxCollider> ().enabled = false;

                GameObject FX_Handler;


                FX_Handler = Instantiate(explosionFX, explosionArea.transform.position, explosionArea.transform.rotation) as GameObject;


                Destroy(this.gameObject, 0.2f);
                Destroy(FX_Handler, explosionTime);
            }

            if (other.gameObject.tag == "ColObject" && other.gameObject.GetComponent<MiscColHealthScript>() == true && other.gameObject.GetComponent<MiscColHealthScript>().team2 == true)
            {

                if (other.gameObject.GetComponent<MiscColHealthScript>().usesShield == true && other.gameObject.GetComponent<MiscColHealthScript>().singlePiece == true)
                {
                    other.gameObject.GetComponent<MiscColHealthScript>().shieldHP -= bulletDmg;
                }
                if (other.gameObject.GetComponent<MiscColHealthScript>().usesShield == true && other.gameObject.GetComponent<MiscColHealthScript>().singlePiece == false)
                {
                    other.gameObject.GetComponent<MiscColHealthScript>().wholeObject.GetComponent<StationAIScript>().shieldHP -= bulletDmg;
                }

                if (other.gameObject.GetComponent<MiscColHealthScript>().usesShield == true && other.gameObject.GetComponent<MiscColHealthScript>().shieldHP <= 0 || other.gameObject.GetComponent<MiscColHealthScript>().usesShield == false)
                {
                    other.gameObject.GetComponent<MiscColHealthScript>().hullHP -= bulletDmg;
                    
                }
            }
            
            }
            if (forTeam2 == true) {
			if (other.gameObject.tag == "Team1Player" && other.gameObject.GetComponent<PlayerStatsScript>() == true) {
                other.gameObject.GetComponent<PlayerStatsScript>().shieldHP -= bulletDmg;
                if (other.gameObject.GetComponent<PlayerStatsScript>().shieldHP <= 0)
                {
                    other.gameObject.GetComponent<PlayerStatsScript>().hullHP -= bulletDmg;
                }
                //				Debug.Log ("Bullet hit");
                //			bulletDestroySFX.PlayOneShot (bulletDestroySFX.clip);
                //Projectile.GetComponent<MeshRenderer> ().enabled = false;
                Destroy (bulletFire);
				Destroy (Projectile);
				Destroy (hitBox);


				//this.bulletDestroySFX.GetComponent<BoxCollider> ().enabled = false;

				GameObject FX_Handler;


				FX_Handler = Instantiate (explosionFX, explosionArea.transform.position, explosionArea.transform.rotation) as GameObject;

                

                Destroy(this.gameObject, 0.2f);
				Destroy (FX_Handler, explosionTime);
			}
			if (other.gameObject.tag == "Team1Player" && other.gameObject.GetComponent<BasicAI>() == true) {
				other.gameObject.GetComponent<BasicAI>().shieldHP -= bulletDmg;
				if (other.gameObject.GetComponent<BasicAI>().shieldHP <= 0)
				{
					other.gameObject.GetComponent<BasicAI>().hullHP -= bulletDmg;
				}
				//				Debug.Log ("Bullet hit");
				//			bulletDestroySFX.PlayOneShot (bulletDestroySFX.clip);
				//Projectile.GetComponent<MeshRenderer> ().enabled = false;
				Destroy (bulletFire);
				Destroy (Projectile);
				Destroy (hitBox);


				//this.bulletDestroySFX.GetComponent<BoxCollider> ().enabled = false;

				GameObject FX_Handler;


				FX_Handler = Instantiate (explosionFX, explosionArea.transform.position, explosionArea.transform.rotation) as GameObject;



				Destroy (this.gameObject, 0.2f);
				Destroy (FX_Handler, explosionTime);
			}

            if (other.gameObject.tag == "Missile" && other.gameObject.GetComponent<MissileScript>().invincible == false && other.gameObject.GetComponent<MissileScript>().team2 == false)
            {
                other.gameObject.GetComponent<MissileScript>().missileHealth -= bulletDmg;
                //				Debug.Log ("Bullet hit");
                //			bulletDestroySFX.PlayOneShot (bulletDestroySFX.clip);
                //Projectile.GetComponent<MeshRenderer> ().enabled = false;
                Destroy(bulletFire);
                Destroy(Projectile);
                Destroy(hitBox);


                //this.bulletDestroySFX.GetComponent<BoxCollider> ().enabled = false;

                GameObject FX_Handler;


                FX_Handler = Instantiate(explosionFX, explosionArea.transform.position, explosionArea.transform.rotation) as GameObject;


                Destroy(this.gameObject, 0.2f);
                Destroy(FX_Handler, explosionTime);
            }
        }
	}
}
