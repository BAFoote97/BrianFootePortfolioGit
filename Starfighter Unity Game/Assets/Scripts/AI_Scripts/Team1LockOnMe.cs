using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Team1LockOnMe : MonoBehaviour {

	List <Transform> hostiles = new List<Transform> ();

	public GameObject character;
	public Transform characterBody;
    public bool isDead;


    //	public GameObject realIndic;

    public Canvas aiMarker;
    public bool isLockedOnByEnemy;

    public bool isTargetted;
	public bool isTargettedByPlayer;
	public bool isHighlightedByPlayer;
	public GameObject targetSquare;

    public float scaleDefault;
    public float scaleBig;

    public Color blue;
	public bool isBlue;
	public Color green;
	public bool isGreen;
	public Color red;
	public bool isRed;
	public Color white;
	public bool isWhite;
	public Color orange;
	public bool isOrange;
	public Color yellow;
	public bool isYellow;

	public Color defaultColor;
	public bool isDefault;

	public float targetColorChange;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (character != null && character.GetComponent<BasicAI>().dead == true)
        {
            isDead = true;
            isTargettedByPlayer = false;
            //Destroy(aiMarker);
            //Destroy(innerDiamond);
            //Destroy(outerDiamond);

        }

        if (isTargettedByPlayer == true)
		{
//			realIndic.GetComponent<Indicator1>().isCurrent = true;
			//StartCoroutine(MakeTargetBlink());
			isDefault = false;
			isWhite = true;
		}
		if (isTargettedByPlayer == false)
		{
//			realIndic.GetComponent<Indicator1>().isCurrent = false;
			//StopCoroutine(MakeTargetBlink());
			isWhite = false;
			isDefault = true;
		}

        if (isLockedOnByEnemy == true && character.GetComponent<BasicAI>().dead == false)
        {
            
            if (character.GetComponent<BasicAI>().genericBeta == true)
            {

                character.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().GenericBetaLockedOnByEnemy();
            }
            if (character.GetComponent<BasicAI>().usesList1OnPlayerLock == true)
            {
                character.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().SubtitleList1();
            }
            if (character.GetComponent<BasicAI>().usesList2OnPlayerLock == true)
            {
                character.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().SubtitleList2();
            }
            if (character.GetComponent<BasicAI>().usesList3OnPlayerLock == true)
            {
                character.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().SubtitleList3();
            }
            if (character.GetComponent<BasicAI>().usesList4OnPlayerLock == true)
            {
                character.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().SubtitleList4();
            }
            if (character.GetComponent<BasicAI>().usesList5OnPlayerLock == true)
            {
                character.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().SubtitleList5();
            }
            if (character.GetComponent<BasicAI>().usesList6OnPlayerLock == true)
            {
                character.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().SubtitleList6();
            }
            if (character.GetComponent<BasicAI>().usesList7OnPlayerLock == true)
            {
                character.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().SubtitleList7();
            }
            if (character.GetComponent<BasicAI>().usesList8OnPlayerLock == true)
            {
                character.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().SubtitleList8();
            }
            if (character.GetComponent<BasicAI>().usesList9OnPlayerLock == true)
            {
                character.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().SubtitleList9();
            }
            if (character.GetComponent<BasicAI>().usesList10OnPlayerLock == true)
            {
                character.GetComponent<BasicAI>().subtitleObject.GetComponent<DialogueScript>().SubtitleList10();
            }

        }

        if (isBlue == true)
		{
			targetSquare.GetComponent<Image>().color = blue;
			defaultColor = blue;
		}
		if (isGreen == true)
		{
			targetSquare.GetComponent<Image>().color = green;
			green = defaultColor;
		}
		if (isRed == true)
		{
			targetSquare.GetComponent<Image>().color = red;
			defaultColor = red;
		}
		if (isWhite == true)
		{
			targetSquare.GetComponent<Image>().color = white;
		}
		if (isOrange == true)
		{
			targetSquare.GetComponent<Image>().color = orange;
			orange = defaultColor;
		}
		if (isYellow == true)
		{
			targetSquare.GetComponent<Image>().color = yellow;
			yellow = defaultColor;
		}
	}
	IEnumerator MakeTargetBlink()
	{
		isRed = true;
		yield return new WaitForSeconds(targetColorChange);
		isRed = false;
		isWhite = true;
		yield return new WaitForSeconds(targetColorChange);
		isWhite = false;
		StartCoroutine(MakeTargetBlink());

	}
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "PlayerTargetZone" && isDead == false)
		{

			aiMarker.GetComponent<MarkerScript>().objectScale = scaleBig;
            //if (other.GetComponent<TargetZoneScript>().currentAim == null)
            //{
                other.GetComponent<TargetZoneScript>().currentAim = null;


            other.GetComponent<TargetZoneScript>().currentAim = this.transform;

            //}
        }
    }
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "PlayerTargetZone" || isDead == true)
		{
			aiMarker.GetComponent<MarkerScript>().objectScale = scaleDefault;
			if (other.GetComponent<TargetZoneScript>().currentAim == this.transform)
			{
				other.GetComponent<TargetZoneScript>().currentAim = null;
			}
		}
		
	}
}
