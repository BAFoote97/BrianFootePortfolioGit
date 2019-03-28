using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject myPlayer;
	public GameObject myBullet;
    public float bulletSpeed;
    public float bulletDmg;
    public float bulletLifeTime;
	public float cooldown;
	public bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
		canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
		if (canShoot == true){
			canShoot = false;
			Fire();
			StartCoroutine(WeaponCooldownTimer());
		}
    }

	public void Fire(){
		GameObject newBullet = Instantiate(myBullet, gameObject.transform.position, gameObject.transform.rotation);
        newBullet.GetComponent<BulletScript>().myPlayer = myPlayer;
        newBullet.GetComponent<BulletScript>().playerBullet = true;
        newBullet.GetComponent<BulletScript>().speed = bulletSpeed;
        newBullet.GetComponent<BulletScript>().dmg = bulletDmg;
        newBullet.GetComponent<BulletScript>().timeBeforeDestroy = bulletLifeTime;
	}

	public IEnumerator WeaponCooldownTimer(){
		yield return new WaitForSeconds(cooldown);
		canShoot = true;
	}
}
