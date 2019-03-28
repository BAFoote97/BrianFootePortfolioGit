using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsScript : MonoBehaviour {

	public GameObject playerObject;

	public float speedStat;
	public float maxSpeedStat;
	public float shieldHP = 100.0f;
	public float shieldMaxHP = 100.0f;
    public float shieldMinHP = -50.0f;
	public float shieldRegen = 100.0f;
	public float hullHP = 100.0f;
	public float hullMaxHP = 100.0f;
    public float hullMinHP = 0.0f;

    public bool dead;
    public GameObject itemHolder;

	public Vector3 prevPos;
	public Vector3 currVel;

    public bool shieldProtectsMissiles;


    public int scoreValue;

	public Text speedNumberIndic;
    public Text shieldWord;
	public Text shieldNumberIndic;
	public Text hullNumberIndic;
	public Text scoreIndic;

    public GameObject shieldColorRef;
    public GameObject shieldBackgroundRef;
    public Color blue;
    public Color red;

	public Slider speedMeterIndic;
	public Slider shieldMeterIndic;
	public Slider hullMeterIndic;
	

	public float laserHeatValue;
	public float maxLaserHeatValue;
	public float laserHeatPlusValue;
	public float laserHeatCooldownValue;

//	public static Player_Control playerRef;
//	public static PlayerPrimaryLaserScript laserRef;

	float CalculateSpeed()
	{
		return speedStat / maxSpeedStat;
	}

	float CalculateShield()
	{
		return shieldHP / shieldMaxHP;
	}
		
	float CalculateHull()
	{
		return hullHP / hullMaxHP;
	}

	void OnGUI()
	{



	}

	// Use this for initialization
	void Start () {
		StartCoroutine( CalcVelocity() );


//		gameObject.GetComponent<Player_Control> ().speedValue = speedStat;

	}
	
	// Update is called once per frame
	void Update () {


		if (shieldHP < shieldMaxHP) {
			shieldHP += shieldRegen * Time.deltaTime;
			if (shieldHP > shieldMaxHP) 
			{
				shieldHP = shieldMaxHP;
			}


		}

        if (shieldHP <= shieldMinHP)
        {
            shieldHP = shieldMinHP;
        }
        if (shieldHP <= 0)
        {
            shieldWord.GetComponent<Text>().color = red;
            shieldNumberIndic.GetComponent<Text>().color = red;
            shieldColorRef.GetComponent<Image>().color = red;
            shieldBackgroundRef.GetComponent<Image>().color = red;
        }
        if (shieldHP > 0)
        {
            shieldWord.GetComponent<Text>().color = blue;
            shieldNumberIndic.GetComponent<Text>().color = blue;
            shieldColorRef.GetComponent<Image>().color = blue;
            shieldBackgroundRef.GetComponent<Image>().color = blue;
        }
        if (hullHP <= hullMinHP)
        {
            hullHP = hullMinHP;
            dead = true;
        }
        if (dead == true)
        {
            Destroy(itemHolder);
        }

        speedMeterIndic.value = speedStat * 50;
		speedMeterIndic.maxValue = maxSpeedStat * 50;
		shieldMeterIndic.value = shieldHP;
        shieldMeterIndic.maxValue = shieldMaxHP;
		hullMeterIndic.value = hullHP;
        hullMeterIndic.maxValue = hullMaxHP;
		

		speedNumberIndic.text = speedStat.ToString ("F0");
		shieldNumberIndic.text = shieldHP.ToString ("F0");
		hullNumberIndic.text = hullHP.ToString ("F0");
		scoreIndic.text = scoreValue.ToString ("F0");
		
	}

	IEnumerator CalcVelocity()
	{
		while( Application.isPlaying )
		{
			// Position at frame start
			prevPos = gameObject.transform.position;
			// Wait till it the end of the frame
			yield return new WaitForEndOfFrame();
			// Calculate velocity: Velocity = DeltaPosition / DeltaTime
			currVel = (prevPos - gameObject.transform.position) / Time.deltaTime;
			//Debug.Log( currVel );
		}
	}

    
}