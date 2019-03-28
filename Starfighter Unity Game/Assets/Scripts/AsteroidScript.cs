using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour {

    

    public Renderer rend;
    public Collider col;

    public List<GameObject> asteroidFragments = new List<GameObject>();
    public int fragmentAmount;

    public GameObject wholeObject;
    public float asteroidHP;

    public float moveX;
    public float moveY;
    public float moveZ;
    public float rotX;
    public float rotXMin;
    public float rotXMax;
    public float rotY;
    public float rotYMin;
    public float rotYMax;
    public float rotZ;
    public float rotZMin;
    public float rotZMax;
    public float scaleX;
    public float scaleXMin;
    public float scaleXMax;
    public float scaleY;
    public float scaleYMin;
    public float scaleYMax;
    public float scaleZ;
    public float scaleZMin;
    public float scaleZMax;


    public bool destroyed;
    public bool indestructible;

    public GameObject destroyBoom;
    public AudioSource boomSFX;

    // Use this for initialization
    void Start () {
        destroyBoom.SetActive(false);
        rotX = Random.Range(rotXMin, rotXMax);
        rotY = Random.Range(rotYMin, rotYMax);
        rotZ = Random.Range(rotZMin, rotZMax);
        scaleX = Random.Range(scaleXMin, scaleXMax);
        scaleY = Random.Range(scaleYMin, scaleYMax);
        scaleZ = Random.Range(scaleZMin, scaleZMax);
        gameObject.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
    }
	
	// Update is called once per frame
	void Update () {

        if (destroyed == false)
        {
            wholeObject.transform.Translate(moveX * Time.deltaTime, moveY * Time.deltaTime, moveZ * Time.deltaTime);

            gameObject.transform.Rotate(rotX * Time.deltaTime, rotY * Time.deltaTime, rotZ * Time.deltaTime);
        }

        if (asteroidHP <= 0 && destroyed == false && indestructible == false)
        {
            destroyed = true;
            StartCoroutine(DestroyAsteroid());
        }

	}

    public IEnumerator FragmentSpawn()
    {
        

        transform.Rotate(rotX = Random.Range(0, 360), rotY = Random.Range(0, 360), rotZ = Random.Range(0, 360));
        GameObject tempAsteroid;

        

        tempAsteroid = Instantiate(asteroidFragments[Random.Range(0, asteroidFragments.Count)], gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
        //This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
        tempAsteroid.transform.Rotate(Vector3.left);
        tempAsteroid.transform.GetChild(0).GetComponent<AsteroidScript>().rotX = Random.Range(0, 360);
        tempAsteroid.transform.GetChild(0).GetComponent<AsteroidScript>().rotY = Random.Range(0, 360);
        tempAsteroid.transform.GetChild(0).GetComponent<AsteroidScript>().rotZ = Random.Range(0, 360);

        tempAsteroid.transform.GetChild(0).GetComponent<AsteroidScript>().moveX = Random.Range(40, 100);
        tempAsteroid.transform.GetChild(0).GetComponent<AsteroidScript>().moveY = Random.Range(40, 100);
        tempAsteroid.transform.GetChild(0).GetComponent<AsteroidScript>().moveZ = Random.Range(40, 100);


        //Retrieve the Rigidbody component from the instantiated Bullet and control it.
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = tempAsteroid.GetComponent<Rigidbody>();

        //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
        Temporary_RigidBody.AddForce(transform.forward * Random.Range(2000, 5000), ForceMode.Impulse);
        fragmentAmount -= 1;
        
        if (fragmentAmount > 0)
        {
            StartCoroutine(FragmentSpawn());
        }
        yield return new WaitForSeconds(0);

    }

    public IEnumerator DestroyAsteroid()
    {
        destroyBoom.SetActive(true);
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        col = GetComponent<Collider>();
        col.enabled = false;
        boomSFX.enabled = true;
        if (fragmentAmount > 0)
        {
            
            StartCoroutine(FragmentSpawn());
        }
        yield return new WaitForSeconds(10);
        Destroy(wholeObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Team1LockOnMe>() == true && other.gameObject.GetComponent<Team2LockOnMe>() == false && other.gameObject.GetComponent<Team1LockOnMe>().character.GetComponent<BasicAI>().cantCrash == false)
        {
            other.gameObject.GetComponent<Team1LockOnMe>().character.GetComponent<BasicAI>().hullHP = other.gameObject.GetComponent<Team1LockOnMe>().character.GetComponent<BasicAI>().hullMinHP;
        }
        if (other.gameObject.GetComponent<Team2LockOnMe>() == true && other.gameObject.GetComponent<Team1LockOnMe>() == false && other.gameObject.GetComponent<Team2LockOnMe>().character.GetComponent<BasicAI>().cantCrash == false)
        {
            other.gameObject.GetComponent<Team2LockOnMe>().character.GetComponent<BasicAI>().hullHP = other.gameObject.GetComponent<Team2LockOnMe>().character.GetComponent<BasicAI>().hullMinHP;
        }
    }
}
