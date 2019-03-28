using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectScript : MonoBehaviour {

	public List <GameObject> primaryWeapons = new List<GameObject> ();

	public GameObject activePrimary;

	public int primaryNumber;

	public int primaryWeaponMax;

    public AudioSource primaryWeaponSFX;

    public GameObject noseHighlight;
    public GameObject wingsHighlight;

    public Slider primaryHeatMeter1, primaryHeatMeter2;
    public GameObject overheatText;

    public List <GameObject> secondaryWeapons = new List<GameObject> ();

	public GameObject activeSecondary;

	public int secondaryNumber;

	public int secondaryWeaponMax;

    public AudioSource secondaryWeaponSFX;

    public Color ammoTextDefault;
    public Color noAmmoColor;

    public GameObject sidesHighlight;
    public GameObject sidesAmmoHighlight;
    public Text sidesAmmoText;


    public GameObject underHighlight;
    public GameObject underAmmoHighlight;
    public Text underAmmoText;


	// Use this for initialization
	void Start () {

        



    }

    // Update is called once per frame
    void Update()
    {


        primaryWeapons[0] = gameObject.GetComponent<SaveLoadoutScript>().activeNoseWeapon;
        primaryWeapons[1] = gameObject.GetComponent<SaveLoadoutScript>().activeWingWeapon;

        secondaryWeapons[0] = gameObject.GetComponent<SaveLoadoutScript>().activeSideWeapon;
        secondaryWeapons[1] = gameObject.GetComponent<SaveLoadoutScript>().activeUnderWeapon;

        if (gameObject.GetComponent<PauseScript>().paused == false)
        {
            activePrimary = primaryWeapons[primaryNumber];

            activeSecondary = secondaryWeapons[secondaryNumber];



            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                primaryNumber += 1;
                primaryWeaponSFX.Play();
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                secondaryNumber += 1;
                secondaryWeaponSFX.Play();
            }

            if (primaryNumber == primaryWeaponMax)
            {
                primaryNumber = 0;
            }

            if (primaryWeapons[0] == activePrimary)
            {
                noseHighlight.SetActive(true);
                wingsHighlight.SetActive(false);
            }
            if (primaryWeapons[1] == activePrimary)
            {
                noseHighlight.SetActive(false);
                wingsHighlight.SetActive(true);
            }

            if (secondaryWeapons[0] == activeSecondary)
            {
                
                sidesHighlight.SetActive(true);
                sidesAmmoHighlight.SetActive(true);
                underHighlight.SetActive(false);
                underAmmoHighlight.SetActive(false);
                
            }
            if (secondaryWeapons[1] == activeSecondary)
            {
                sidesHighlight.SetActive(false);
                sidesAmmoHighlight.SetActive(false);
                underHighlight.SetActive(true);
                underAmmoHighlight.SetActive(true);
            }

            if (secondaryNumber >= secondaryWeaponMax)
            {
                secondaryNumber = 0;
            }

            primaryHeatMeter1.value = activePrimary.GetComponent<PlayerPrimaryLaserScript>().laserHeat;
            primaryHeatMeter2.value = activePrimary.GetComponent<PlayerPrimaryLaserScript>().laserHeat;
            primaryHeatMeter1.maxValue = activePrimary.GetComponent<PlayerPrimaryLaserScript>().maxLaserHeat;
            primaryHeatMeter2.maxValue = activePrimary.GetComponent<PlayerPrimaryLaserScript>().maxLaserHeat;

            if (activePrimary.GetComponent<PlayerPrimaryLaserScript>().overheated == true)
            {
                overheatText.SetActive(true);
            }
            if (activePrimary.GetComponent<PlayerPrimaryLaserScript>().overheated == false)
            {
                overheatText.SetActive(false);
            }

            sidesAmmoText.text = secondaryWeapons[0].GetComponent<PlayerMissileLauncher>().ammoCount.ToString();
            underAmmoText.text = secondaryWeapons[1].GetComponent<PlayerMissileLauncher>().ammoCount.ToString();



            if (secondaryWeapons[0].GetComponent<PlayerMissileLauncher>().ammoCount >= 0)
            {
                sidesAmmoText.color = ammoTextDefault;
            }
            if (secondaryWeapons[0].GetComponent<PlayerMissileLauncher>().ammoCount <= 0)
            {
                sidesAmmoText.color = noAmmoColor;
            }
            if (secondaryWeapons[1].GetComponent<PlayerMissileLauncher>().ammoCount >= 0)
            {
                underAmmoText.color = ammoTextDefault;
            }
            if (secondaryWeapons[1].GetComponent<PlayerMissileLauncher>().ammoCount <= 0)
            {
                underAmmoText.color = noAmmoColor;
            }
        }
    }
}
