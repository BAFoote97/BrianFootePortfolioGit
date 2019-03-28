using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHangarSettings : MonoBehaviour {

    public GameObject noseWeapon1Indic;
    public GameObject noseWeapon2Indic;
    public GameObject noseWeapon3Indic;
    public GameObject noseWeapon4Indic;

    public GameObject sideWeapon1Indic;
    public GameObject sideWeapon2Indic;
    public GameObject sideWeapon3Indic;
    public GameObject sideWeapon4Indic;

    public GameObject wingWeapon1Indic;
    public GameObject wingWeapon2Indic;
    public GameObject wingWeapon3Indic;
    public GameObject wingWeapon4Indic;

    public GameObject underWeapon1Indic;
    public GameObject underWeapon2Indic;
    public GameObject underWeapon3Indic;
    public GameObject underWeapon4Indic;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (gameObject.GetComponent<SaveLoadoutScript>().noseWeaponInt == 1)
        {
            noseWeapon1Indic.SetActive(true);
            noseWeapon2Indic.SetActive(false);
            noseWeapon3Indic.SetActive(false);
            noseWeapon4Indic.SetActive(false);
        }
        if (gameObject.GetComponent<SaveLoadoutScript>().noseWeaponInt == 2)
        {
            noseWeapon1Indic.SetActive(false);
            noseWeapon2Indic.SetActive(true);
            noseWeapon3Indic.SetActive(false);
            noseWeapon4Indic.SetActive(false);
        }
        if (gameObject.GetComponent<SaveLoadoutScript>().noseWeaponInt == 3)
        {
            noseWeapon1Indic.SetActive(false);
            noseWeapon2Indic.SetActive(false);
            noseWeapon3Indic.SetActive(true);
            noseWeapon4Indic.SetActive(false);
        }
        if (gameObject.GetComponent<SaveLoadoutScript>().noseWeaponInt == 4)
        {
            noseWeapon1Indic.SetActive(false);
            noseWeapon2Indic.SetActive(false);
            noseWeapon3Indic.SetActive(false);
            noseWeapon4Indic.SetActive(true);
        }

        if (gameObject.GetComponent<SaveLoadoutScript>().sideWeaponInt == 1)
        {
            sideWeapon1Indic.SetActive(true);
            sideWeapon2Indic.SetActive(false);
            sideWeapon3Indic.SetActive(false);
            sideWeapon4Indic.SetActive(false);
        }
        if (gameObject.GetComponent<SaveLoadoutScript>().sideWeaponInt == 2)
        {
            sideWeapon1Indic.SetActive(false);
            sideWeapon2Indic.SetActive(true);
            sideWeapon3Indic.SetActive(false);
            sideWeapon4Indic.SetActive(false);
        }
        if (gameObject.GetComponent<SaveLoadoutScript>().sideWeaponInt == 3)
        {
            sideWeapon1Indic.SetActive(false);
            sideWeapon2Indic.SetActive(false);
            sideWeapon3Indic.SetActive(true);
            sideWeapon4Indic.SetActive(false);
        }
        if (gameObject.GetComponent<SaveLoadoutScript>().sideWeaponInt == 4)
        {
            sideWeapon1Indic.SetActive(false);
            sideWeapon2Indic.SetActive(false);
            sideWeapon3Indic.SetActive(false);
            sideWeapon4Indic.SetActive(true);
        }

        if (gameObject.GetComponent<SaveLoadoutScript>().wingWeaponInt == 1)
        {
            wingWeapon1Indic.SetActive(true);
            wingWeapon2Indic.SetActive(false);
            wingWeapon3Indic.SetActive(false);
            wingWeapon4Indic.SetActive(false);
        }
        if (gameObject.GetComponent<SaveLoadoutScript>().wingWeaponInt == 2)
        {
            wingWeapon1Indic.SetActive(false);
            wingWeapon2Indic.SetActive(true);
            wingWeapon3Indic.SetActive(false);
            wingWeapon4Indic.SetActive(false);
        }
        if (gameObject.GetComponent<SaveLoadoutScript>().wingWeaponInt == 3)
        {
            wingWeapon1Indic.SetActive(false);
            wingWeapon2Indic.SetActive(false);
            wingWeapon3Indic.SetActive(true);
            wingWeapon4Indic.SetActive(false);
        }
        if (gameObject.GetComponent<SaveLoadoutScript>().wingWeaponInt == 4)
        {
            wingWeapon1Indic.SetActive(false);
            wingWeapon2Indic.SetActive(false);
            wingWeapon3Indic.SetActive(false);
            wingWeapon4Indic.SetActive(true);
        }

        if (gameObject.GetComponent<SaveLoadoutScript>().underWeaponInt == 1)
        {
            underWeapon1Indic.SetActive(true);
            underWeapon2Indic.SetActive(false);
            underWeapon3Indic.SetActive(false);
            underWeapon4Indic.SetActive(false);
        }
        if (gameObject.GetComponent<SaveLoadoutScript>().underWeaponInt == 2)
        {
            underWeapon1Indic.SetActive(false);
            underWeapon2Indic.SetActive(true);
            underWeapon3Indic.SetActive(false);
            underWeapon4Indic.SetActive(false);
        }
        if (gameObject.GetComponent<SaveLoadoutScript>().underWeaponInt == 3)
        {
            underWeapon1Indic.SetActive(false);
            underWeapon2Indic.SetActive(false);
            underWeapon3Indic.SetActive(true);
            underWeapon4Indic.SetActive(false);
        }
        if (gameObject.GetComponent<SaveLoadoutScript>().underWeaponInt == 4)
        {
            underWeapon1Indic.SetActive(false);
            underWeapon2Indic.SetActive(false);
            underWeapon3Indic.SetActive(false);
            underWeapon4Indic.SetActive(true);
        }



    }
}
