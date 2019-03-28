using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiscColHealthScript : MonoBehaviour {

    public GameObject ifDeadDestroyItems;
    public GameObject ifDeadAppear;

    public GameObject wholeObject;

    public bool singlePiece;
    public float pieceDamage;

    public bool usesShield;
    public Slider shieldMeter;
    public float shieldRegen;
    public float shieldHPMax;
    public float shieldHP;
    public float shieldHPMin;
    public Slider hullMeter;
    public float hullHPMax;
    public float hullHP;
    public float hullHPMin;

    public bool isDead;

    public bool team1;
    public bool team2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (singlePiece == false)
        {
            shieldHP = wholeObject.GetComponent<StationAIScript>().shieldHP;
            shieldHPMax = wholeObject.GetComponent<StationAIScript>().shieldHPMax;
            shieldHPMin = wholeObject.GetComponent<StationAIScript>().shieldHPMin;
            
        }

		if (hullHP <= 0 && isDead == false)
        {

            isDead = true;
            if (ifDeadDestroyItems != null)
            {
                Destroy(ifDeadDestroyItems);
            }
            if (singlePiece == false)
            {
                wholeObject.GetComponent<StationAIScript>().hullHP -= pieceDamage;
            }
            if (ifDeadAppear != null)
            {
                ifDeadAppear.SetActive(true);
            }
        }
        if (shieldHP < shieldHPMax && singlePiece == true)
        {
            shieldHP += shieldRegen * Time.deltaTime;
        }
        if (shieldHP >= shieldHPMax && singlePiece == true)
        {
            shieldHP = shieldHPMax;
        }

        if (shieldHP < shieldHPMin && singlePiece == true)
        {
            shieldHP = shieldHPMin;
        }

        if (hullHP < hullHPMin)
        {
            hullHP = hullHPMin;
        }
        shieldMeter.value = shieldHP;
        shieldMeter.maxValue = shieldHPMax;
        hullMeter.value = hullHP;
        hullMeter.maxValue = hullHPMax;

    }

   
}
