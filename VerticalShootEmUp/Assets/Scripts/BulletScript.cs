using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float dmg;
	public float speed;
	public float timeBeforeDestroy;

    public GameObject myPlayer;
    public bool playerBullet;
    public bool enemyBullet;

    public GameObject boomFX;
    // Start is called before the first frame update
    void Start()
    {
        if (myPlayer.GetComponent<PlayerScript>() == true && myPlayer != null)
        {
            playerBullet = true;

        }
		StartCoroutine(SelfDestructTime());
    }

    // Update is called once per frame
    void Update()
    {
		gameObject.transform.Translate(0, 0, speed);
    }

	public IEnumerator SelfDestructTime(){
		yield return new WaitForSeconds(timeBeforeDestroy);
		Destroy(gameObject);
	}

	public void OnTriggerEnter(Collider other){
		
        if (playerBullet == true)
        {
            if (other.gameObject.GetComponent<EnemyScript>() == true && other.gameObject.GetComponent<EnemyScript>().isAgro == true && other.gameObject.GetComponent<EnemyScript>().bossPart == false)
            {
                other.gameObject.GetComponent<EnemyScript>().hp -= dmg;
                DestroyBoom();
            }
            if (other.gameObject.GetComponent<EnemyScript>() == true && other.gameObject.GetComponent<EnemyScript>().isAgro == true && other.gameObject.GetComponent<EnemyScript>().bossPart == true)
            {
                other.gameObject.GetComponent<EnemyScript>().hp -= dmg;
                other.gameObject.GetComponent<EnemyScript>().baseBody.GetComponent<BigBossScript>().hp -= dmg;
                DestroyBoom();
            }
            if (other.gameObject.GetComponent<BigBossScript>() == true && other.gameObject.GetComponent<BigBossScript>().isAgro == true && other.gameObject.GetComponent<BigBossScript>().invincibleBase == false)
            {
                other.gameObject.GetComponent<BigBossScript>().hp -= dmg;
                DestroyBoom();
            }
            if (other.gameObject.tag == "BulletBarrierTag")
            {
                DestroyMe();
            }
        }
        if (enemyBullet == true)
        {
            if (other.gameObject.GetComponent<PlayerScript>() == true && other.gameObject.GetComponent<PlayerScript>().isDead == false)
            {

                other.gameObject.GetComponent<PlayerScript>().PlayerDeath();
            }
        }
        if (other.gameObject.tag != "BulletBarrierTag")
        {
            DestroyBoom();
        }
	}

    public void DestroyBoom()
    {
        Instantiate(boomFX, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }

	public void DestroyMe(){
		Destroy(gameObject);
	}
}
