using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public bool isPlayer1;
    public bool isPlayer2;
    public bool isPlayer3;
    public bool isWingman;
    public Transform myWingmanSpace;

    public GameScrollScript gamePlayerSystem;


	public float moveSpeed;

    public List<WeaponScript> myWeapons = new List<WeaponScript>();

    public bool isDead;
    public float deadTime;

    public GameObject playerBoomFX;

    public Material defaultMat;
    public Material deadMat;
    // Start is called before the first frame update
    void Start()
    {
        if (isWingman == false)
        {
            gamePlayerSystem.gamePlayers.Add(gameObject.GetComponent<PlayerScript>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (isDead == false)
        {
            GetComponent<Renderer>().material = defaultMat;
        }
        if (isDead == true)
        {
            GetComponent<Renderer>().material = deadMat;
        }
        if (isPlayer1 == true && isWingman == false)
        {
            if (Input.GetKey(KeyCode.W) && gameObject.transform.localPosition.z < 15)
            {
                gameObject.transform.Translate(0, 0, moveSpeed);
            }
            if (Input.GetKey(KeyCode.S) && gameObject.transform.localPosition.z > -15)
            {
                gameObject.transform.Translate(0, 0, -moveSpeed);
            }
            if (Input.GetKey(KeyCode.A) && gameObject.transform.localPosition.x > -20)
            {
                gameObject.transform.Translate(-moveSpeed, 0, 0);
            }
            if (Input.GetKey(KeyCode.D) && gameObject.transform.localPosition.x < 20)
            {
                gameObject.transform.Translate(moveSpeed, 0, 0);
            }
        }
        if (isPlayer2 == true && isWingman == false)
        {
            if (Input.GetKey(KeyCode.UpArrow) && gameObject.transform.localPosition.z < 15)
            {
                gameObject.transform.Translate(0, 0, moveSpeed);
            }
            if (Input.GetKey(KeyCode.DownArrow) && gameObject.transform.localPosition.z > -15)
            {
                gameObject.transform.Translate(0, 0, -moveSpeed);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && gameObject.transform.localPosition.x > -20)
            {
                gameObject.transform.Translate(-moveSpeed, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow) && gameObject.transform.localPosition.x < 20)
            {
                gameObject.transform.Translate(moveSpeed, 0, 0);
            }
        }
        if (isPlayer3 == true && isWingman == false)
        {
            if (Input.GetKey(KeyCode.I) && gameObject.transform.localPosition.z < 15)
            {
                gameObject.transform.Translate(0, 0, moveSpeed);
            }
            if (Input.GetKey(KeyCode.K) && gameObject.transform.localPosition.z > -15)
            {
                gameObject.transform.Translate(0, 0, -moveSpeed);
            }
            if (Input.GetKey(KeyCode.J) && gameObject.transform.localPosition.x > -20)
            {
                gameObject.transform.Translate(-moveSpeed, 0, 0);
            }
            if (Input.GetKey(KeyCode.L) && gameObject.transform.localPosition.x < 20)
            {
                gameObject.transform.Translate(moveSpeed, 0, 0);
            }
        }
        if (isWingman == true)
        {
            if (gamePlayerSystem.player1Lives == 0 && isPlayer1 == true || gamePlayerSystem.player2Lives == 0 && isPlayer2 == true
                 || gamePlayerSystem.player3Lives == 0 && isPlayer3 == true)
            {
                PlayerDeath();
            }
            if (myWingmanSpace != null)
            {
                if (myWingmanSpace.transform.position.x > transform.position.x)
                {
                    transform.Translate(moveSpeed, 0, 0);
                }
                if (myWingmanSpace.transform.position.x < transform.position.x)
                {
                    transform.Translate(-moveSpeed, 0, 0);
                }
                if (myWingmanSpace.transform.position.z > transform.position.z)
                {
                    transform.Translate(0, 0, moveSpeed);
                }
                if (myWingmanSpace.transform.position.z < transform.position.z)
                {
                    transform.Translate(0, 0, -moveSpeed);
                }
            }
            
        }
    }

    public void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.GetComponent<BulletScript>() == false)
        {
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        
        isDead = true;
        gameObject.GetComponent<Collider>().enabled = false;
        StartCoroutine(DeadTimer());
        if (isPlayer1 == true && isWingman == false)
        {
            gamePlayerSystem.player1Lives -= 1;
        }
        if (isPlayer2 == true && isWingman == false)
        {
            gamePlayerSystem.player2Lives -= 1;
        }
        if (isPlayer3 == true && isWingman == false)
        {
            gamePlayerSystem.player3Lives -= 1;
        }

        Instantiate(playerBoomFX, gameObject.transform.position, gameObject.transform.rotation);
        if (isPlayer1 == true && gamePlayerSystem.player1Lives == 0)
        {
            gamePlayerSystem.gamePlayers.Remove(gameObject.GetComponent<PlayerScript>());
            Destroy(gameObject);
        }
        if (isPlayer2 == true && gamePlayerSystem.player2Lives == 0)
        {
            gamePlayerSystem.gamePlayers.Remove(gameObject.GetComponent<PlayerScript>());
            Destroy(gameObject);
        }
        if (isPlayer3 == true && gamePlayerSystem.player3Lives == 0)
        {
            gamePlayerSystem.gamePlayers.Remove(gameObject.GetComponent<PlayerScript>());
            Destroy(gameObject);
        }

    }
    public IEnumerator DeadTimer()
    {
        foreach(WeaponScript gun in myWeapons)
        {
            gun.gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(deadTime);
        isDead = false;
        gameObject.GetComponent<Collider>().enabled = true;
        foreach (WeaponScript gun in myWeapons)
        {
            gun.gameObject.SetActive(true);
            gun.canShoot = true;
        }
    }
}
