using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMissileScript : MonoBehaviour {

    public GameObject NPC;
    //public List<GameObject> targets = new List<GameObject>();

    public Transform lockedTarget;

    public float lockValue;
    public float lockIncrease;
    public float lockDecrease;
    public float lockThresh;
    public float lockSnap;
    public float lockMax;
    public bool snapBack;

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

    public float missileShootValue;
    public float missileMax;
    public float missileLimit;
    public float missileIncrease;
    public float missileCooldown;
    public bool overShoot;
    public bool canFire;
    public bool permitFire;
    public bool targetIsHostile;

    public bool alternateEmitters;
    public bool isEmitter1;
    public bool isEmitter2;
    public GameObject currentEmitter;

    public bool team1;
    public bool team2;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (overShoot == false)
        {
            canFire = true;
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

        if (NPC.GetComponent<BasicAI>() == true)
        {
            lockedTarget = NPC.GetComponent<BasicAI>().currentTarget;
        }
        if (lockedTarget == null)
            lockedOn = false;

        if (NPC.GetComponent<BasicAI>().playerIsTarget == true)
        {
            Bullet.GetComponent<MissileScript>().targetIsPlayer = true;
        }

        //        if (NPC.GetComponent<BasicAI>().currentTargetIsFriendly == true)
        //        {
        //            targetIsHostile = false;
        //        }
        //        if (NPC.GetComponent<BasicAI>().currentTargetIsFriendly == false)
        //        {
        //            targetIsHostile = true;
        //        }

        Bullet.GetComponent<MissileScript>().seekTarget = lockedTarget;

        if (lockValue <= 0)
        {
            lockValue = 0;
        }
        if (team1 == true)
        {
            Bullet.GetComponent<MissileScript>().team1 = true;
            if (lockedOn == true)
            {
                //lockedTarget.GetComponent<Team2LockOnMe>().isTargetted = true;
                Bullet.GetComponent<MissileScript>().lockedOnTarget = true;
                if (lockValue < lockMax)
                {
                    lockValue += lockIncrease * Time.deltaTime;
                }


            }
            if (lockedOn == false)
            {
                //lockedTarget.GetComponent<Team2LockOnMe>().isTargetted = false;
                //Bullet.GetComponent<MissileScript>().lockedOnTarget = false;
                lockValue -= lockDecrease * Time.deltaTime;
            }
        }
        if (team2 == true)
        {
            Bullet.GetComponent<MissileScript>().team2 = true;
            if (lockedOn == true)
            {
                //lockedTarget.GetComponent<Team2LockOnMe>().isTargetted = true;
                Bullet.GetComponent<MissileScript>().lockedOnTarget = true;
                if (lockValue < lockMax)
                {
                    lockValue += lockIncrease * Time.deltaTime;
                }


            }
            if (lockedOn == false)
            {
                //lockedTarget.GetComponent<Team2LockOnMe>().isTargetted = false;
                //Bullet.GetComponent<MissileScript>().lockedOnTarget = false;
                lockValue -= lockDecrease * Time.deltaTime;
            }
        }
        if (lockValue < lockThresh)
        {
            permitFire = false;
        }

        if (lockValue >= lockThresh && lockedOn == true)
        {
            permitFire = true;
        }

        if (lockValue >= lockMax && snapBack == true)
        {
            lockValue = lockSnap;
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

        if (overShoot == false)
        {
            canFire = true;
        }
        if (permitFire == true && canFire == true && lockedOn == true && NPC.GetComponent<BasicAI>().onPath == false)
        {
            //canFire = false;
            StartCoroutine(fireDelay());

            if (NPC.GetComponent<BasicAI>().wingman == true)
            {
                NPC.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().WingmanLockedOn();
            }
            if (NPC.GetComponent<BasicAI>().genericEnemy == true)
            {

                NPC.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().GenericEnemyLockedOn();
            }
            if (NPC.GetComponent<BasicAI>().genericAlpha == true)
            {
                NPC.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().GenericEnemyLockedOn();
            }
            if (NPC.GetComponent<BasicAI>().genericBeta == true)
            {
                
                NPC.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().GenericBetaLockedOn();
            }
            if (NPC.GetComponent<BasicAI>().genericDelta == true)
            {
                NPC.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().GenericDeltaLockedOn();
            }
            if (NPC.GetComponent<BasicAI>().genericDelta == true)
            {
                NPC.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().GenericEnemyLockedOn();
            }
            if (NPC.GetComponent<BasicAI>().genericGamma == true)
            {
                NPC.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().GenericEnemyLockedOn();
            }
            if (NPC.GetComponent<BasicAI>().genericOmega == true)
            {
                NPC.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().GenericEnemyLockedOn();
            }
            if (NPC.GetComponent<BasicAI>().genericSigma == true)
            {
                NPC.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().GenericEnemyLockedOn();
            }
            if (NPC.GetComponent<BasicAI>().genericTheta == true)
            {
                NPC.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().GenericEnemyLockedOn();
            }
            if (NPC.GetComponent<BasicAI>().genericZeta == true)
            {
                NPC.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().GenericEnemyLockedOn();
            }
            if (NPC.GetComponent<BasicAI>().usesList1OnLock == true)
            {
                NPC.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().SubtitleList1();
            }
            if (NPC.GetComponent<BasicAI>().usesList2OnLock == true)
            {
                NPC.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().SubtitleList2();
            }
            if (NPC.GetComponent<BasicAI>().usesList3OnLock == true)
            {
                NPC.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().SubtitleList3();
            }
            if (NPC.GetComponent<BasicAI>().usesList4OnLock == true)
            {
                NPC.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().SubtitleList4();
            }
            if (NPC.GetComponent<BasicAI>().usesList5OnLock == true)
            {
                NPC.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().SubtitleList5();
            }
            if (NPC.GetComponent<BasicAI>().usesList6OnLock == true)
            {
                NPC.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().SubtitleList6();
            }
            if (NPC.GetComponent<BasicAI>().usesList7OnLock == true)
            {
                NPC.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().SubtitleList7();
            }
            if (NPC.GetComponent<BasicAI>().usesList8OnLock == true)
            {
                NPC.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().SubtitleList8();
            }
            if (NPC.GetComponent<BasicAI>().usesList9OnLock == true)
            {
                NPC.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().SubtitleList9();
            }
            if (NPC.GetComponent<BasicAI>().usesList10OnLock == true)
            {
                NPC.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().SubtitleList10();
            }

            if (isEmitter1 == true)
            {
                currentEmitter = bulletEmitter1;
            }
            if (isEmitter2 == true)
            {
                currentEmitter = bulletEmitter2;
            }
            if (alternateEmitters == false)

                missileShootValue += missileIncrease;
            //The Bullet Instantiation happens here.
            GameObject Temporary_Bullet_handler;

            //Temporary_Bullet_handler = Instantiate(Bullet, bulletEmitter1.transform.position, bulletEmitter1.transform.rotation) as GameObject;
            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
            //Temporary_Bullet_handler.transform.Rotate(Vector3.left);

            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            Rigidbody Temporary_RigidBody;
            //Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody>();

            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
            //Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force, ForceMode.Impulse);

            //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
            //Destroy(Temporary_Bullet_handler, bulletLifetime);
            {

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
            }
            if (alternateEmitters == true)
            {
                isEmitter1 = !isEmitter1;
                isEmitter2 = !isEmitter2;
                missileShootValue += missileIncrease;
                Temporary_Bullet_handler = Instantiate(Bullet, currentEmitter.transform.position, currentEmitter.transform.rotation) as GameObject;
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
        }
    }
    //void OnTriggerStay(Collider target)
    //{

    //    if (target.gameObject.transform == lockedTarget)
    //        lockedOn = true;

    //    if (team1 == true && team2 == false && lockedTarget.GetComponent<Team2LockOnMe>() == true && lockedOn == true)
    //    {
    //        lockedTarget.GetComponent<Team2LockOnMe>().isLockedOnByEnemy = true;
    //    }
    //    if (team1 == false && team2 == true && lockedTarget.GetComponent<Team1LockOnMe>() == true && lockedOn == true)
    //    {
    //        lockedTarget.GetComponent<Team1LockOnMe>().isLockedOnByEnemy = true;
    //    }

    //}
    //void OnTriggerExit(Collider target)
    //{

    //    if (target.gameObject.transform == lockedTarget || NPC.GetComponent<BasicAI>().dead == true)
    //        lockedOn = false;

    //    if (team1 == true && team2 == false && lockedTarget.GetComponent<Team2LockOnMe>() == true && lockedOn == false)
    //    {
    //        lockedTarget.GetComponent<Team2LockOnMe>().isLockedOnByEnemy = false;
    //    }
    //    if (team1 == false && team2 == true && lockedTarget.GetComponent<Team1LockOnMe>() == true && lockedOn == false)
    //    {
    //        lockedTarget.GetComponent<Team1LockOnMe>().isLockedOnByEnemy = false;
    //    }

    //}

    void OnTriggerStay(Collider target)
    {

        if (team1 == true && target.GetComponent<Team2LockOnMe>() == true && target.gameObject.transform == lockedTarget || team2 == true && target.GetComponent<Team1LockOnMe>() == true && target.gameObject.transform == lockedTarget)
        {

            lockedOn = true;
        }

        //if (team1 == true && team2 == false && lockedTarget.GetComponent<Team2LockOnMe>() == true && lockedOn == true)
        //{
        //    lockedTarget.GetComponent<Team2LockOnMe>().isLockedOnByEnemy = true;
        //}
        //if (team1 == false && team2 == true && lockedTarget.GetComponent<Team1LockOnMe>() == true && lockedOn == true)
        //{
        //    lockedTarget.GetComponent<Team1LockOnMe>().isLockedOnByEnemy = true;
        //}

    }
    void OnTriggerExit(Collider target)
    {

        if (target.gameObject.transform == lockedTarget || NPC.GetComponent<BasicAI>().dead == true)
            lockedOn = false;

        //if (team1 == true && team2 == false && lockedTarget.GetComponent<Team2LockOnMe>() == true && lockedOn == false)
        //{
        //    lockedTarget.GetComponent<Team2LockOnMe>().isLockedOnByEnemy = false;
        //}
        //if (team1 == false && team2 == true && lockedTarget.GetComponent<Team1LockOnMe>() == true && lockedOn == false)
        //{
        //    lockedTarget.GetComponent<Team1LockOnMe>().isLockedOnByEnemy = false;
        //}

    }

    IEnumerator fireDelay()
    {
        yield return new WaitForSeconds(shootDelay);
        canFire = true;
    }

}
