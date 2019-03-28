using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public bool onScreen;
    public float hp;
    public PlayerScript currentTarget;
    public GameScrollScript gamePlayerSystem;
    

    public bool isAgro;

    public GameObject bullet;
    public List<GameObject> bulletSpawnPoint = new List<GameObject>();
    public bool canShoot;
    public List<float> hpSettings = new List<float>();
    public List<float> rotSpeed = new List<float>();
    public List<float> shootDelay = new List<float>();
    public List<float> bulletSpeed = new List<float>();
    public List<float> scoreValues = new List<float>();


    public GameObject movePosition;
    public GameObject baseBody;
    public bool bossPart;
    public List <float> moveSpeeds = new List<float>();
    public List <float> baseBodyTurnSpeeds = new List<float>();
    private bool movingEnemy;



    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        if (movePosition != null && baseBody != null)
        {
            movingEnemy = true;
        }
        
        isAgro = false;
        gamePlayerSystem = FindObjectOfType<GameScrollScript>();
        currentTarget = gamePlayerSystem.gamePlayers[Random.Range(0,gamePlayerSystem.gamePlayers.Count)];
        hp = hpSettings[gamePlayerSystem.difficultyLevel];
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget == null && gamePlayerSystem.gamePlayers.Count > 0)
        {
            currentTarget = gamePlayerSystem.gamePlayers[Random.Range(0, gamePlayerSystem.gamePlayers.Count)];
        }
        if (currentTarget != null)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentTarget.transform.position - transform.position), rotSpeed[gamePlayerSystem.difficultyLevel] * Time.deltaTime);
        }
        if (hp <= 0 && isDead == false)
        {
            isDead = true;
            Dead();
        }

        if (movingEnemy == true)
        {
            baseBody.transform.rotation = Quaternion.Slerp(baseBody.transform.rotation, Quaternion.LookRotation(movePosition.transform.position - transform.position), baseBodyTurnSpeeds[gamePlayerSystem.difficultyLevel] * Time.deltaTime);
            baseBody.transform.Translate(0, 0, moveSpeeds[gamePlayerSystem.difficultyLevel]);
        }

        if (isAgro == true && canShoot == true && currentTarget != null && bossPart == false 
            || isAgro == true && canShoot == true && currentTarget != null && bossPart == true && baseBody.gameObject.GetComponent<BigBossScript>().isAgro == true)
        {
            canShoot = false;
            Fire();
        }

    }

    public void Fire()
    {
        StartCoroutine(ShootReload());
        foreach (GameObject shootPoint in bulletSpawnPoint)
        {
            GameObject newBullet = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
            newBullet.GetComponent<BulletScript>().myPlayer = gameObject;
            newBullet.GetComponent<BulletScript>().enemyBullet = true;
            newBullet.GetComponent<BulletScript>().speed = bulletSpeed[gamePlayerSystem.difficultyLevel];
        }
    }

    public IEnumerator ShootReload()
    {
        yield return new WaitForSeconds(shootDelay[gamePlayerSystem.difficultyLevel]);
        canShoot = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyTrigger")
        {
            isAgro = true;
            if (canShoot == false)
            {
                StartCoroutine(ShootReload());
            }
        }

        if (other.gameObject == movePosition)
        {
            if (other.gameObject == movePosition && other.gameObject.GetComponent<EnemyPathScript>().nextPosition != null)
            {
                movePosition = other.gameObject.GetComponent<EnemyPathScript>().nextPosition;
            }
            if (other.gameObject == movePosition && other.gameObject.GetComponent<EnemyPathScript>().killBox == true)
            {
                baseBody.SetActive(false);
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "EnemyTrigger")
        {
            isAgro = false;
        }
    }

    public void Dead()
    {
        gamePlayerSystem.myScore += scoreValues[gamePlayerSystem.difficultyLevel];
        Destroy(gameObject);
    
    }
}
