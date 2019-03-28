using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveLoadoutScript : MonoBehaviour {

    public int noseWeaponInt;
    public GameObject noseWeapon1;
    public GameObject noseWeapon2;
    public GameObject noseWeapon3;
    public GameObject noseWeapon4;
    public GameObject activeNoseWeapon;

    public int wingWeaponInt;
    public GameObject wingWeapon1;
    public GameObject wingWeapon2;
    public GameObject wingWeapon3;
    public GameObject wingWeapon4;
    public GameObject activeWingWeapon;

    public int sideWeaponInt;
    public GameObject sideWeapon1;
    public GameObject sideWeapon2;
    public GameObject sideWeapon3;
    public GameObject sideWeapon4;
    public GameObject activeSideWeapon;

    public int underWeaponInt;
    public GameObject underWeapon1;
    public GameObject underWeapon2;
    public GameObject underWeapon3;
    public GameObject underWeapon4;
    public GameObject activeUnderWeapon;

    public GameObject testPanel;
    public GameObject testObject;

	// Use this for initialization
	void Start () {

        noseWeaponInt = PlayerPrefs.GetInt("SelectedNoseWeapon");
        wingWeaponInt = PlayerPrefs.GetInt("SelectedWingWeapon");
        sideWeaponInt = PlayerPrefs.GetInt("SelectedSideWeapon");
        underWeaponInt = PlayerPrefs.GetInt("SelectedUnderWeapon");

        //noseWeaponInt = 1;
        //wingWeaponInt = 1;
        //sideWeaponInt = 1;
        //underWeaponInt = 1;

    }
	
	// Update is called once per frame
	void Update () {
        //if (testObject == null)
        //{
        //    testPanel.GetComponent<Image>().color = new Color (255, 0, 0, 100);
        //}

        if (noseWeaponInt == 0)
        {
            noseWeaponInt = 1;
        }
        if (wingWeaponInt == 0)
        {
            wingWeaponInt = 1;
        }
        if (sideWeaponInt == 0)
        {
            sideWeaponInt = 1;
        }
        if (underWeaponInt == 0)
        {
            underWeaponInt = 1;
        }

        if (noseWeaponInt == 1)
        {
            activeNoseWeapon = noseWeapon1;
        }
        if (noseWeaponInt == 2)
        {
            activeNoseWeapon = noseWeapon2;
        }
        if (noseWeaponInt == 3)
        {
            activeNoseWeapon = noseWeapon3;
        }
        if (noseWeaponInt == 4)
        {
            activeNoseWeapon = noseWeapon4;
        }

        if (wingWeaponInt == 1)
        {
            activeWingWeapon = wingWeapon1;
        }
        if (wingWeaponInt == 2)
        {
            activeWingWeapon = wingWeapon2;
        }
        if (wingWeaponInt == 3)
        {
            activeWingWeapon = wingWeapon3;
        }
        if (wingWeaponInt == 4)
        {
            activeWingWeapon = wingWeapon4;
        }

        if (sideWeaponInt == 1)
        {
            activeSideWeapon = sideWeapon1;
        }
        if (sideWeaponInt == 2)
        {
            activeSideWeapon = sideWeapon2;
        }
        if (sideWeaponInt == 3)
        {
            activeSideWeapon = sideWeapon3;
        }
        if (sideWeaponInt == 4)
        {
            activeSideWeapon = sideWeapon4;
        }

        if(underWeaponInt == 1)
        {
            activeUnderWeapon = underWeapon1;
        }
        if (underWeaponInt == 2)
        {
            activeUnderWeapon = underWeapon2;
        }
        if (underWeaponInt == 3)
        {
            activeUnderWeapon = underWeapon3;
        }
        if (underWeaponInt == 4)
        {
            activeUnderWeapon = underWeapon4;
        }

    }

    public void NoseInt1()
    {
        noseWeaponInt = 1;
    }
    public void NoseInt2()
    {
        noseWeaponInt = 2;
    }
    public void NoseInt3()
    {
        noseWeaponInt = 3;
    }
    public void NoseInt4()
    {
        noseWeaponInt = 4;
    }

    public void WingInt1()
    {
        wingWeaponInt = 1;
    }
    public void WingInt2()
    {
        wingWeaponInt = 2;
    }
    public void WingInt3()
    {
        wingWeaponInt = 3;
    }
    public void WingInt4()
    {
        wingWeaponInt = 4;
    }

    public void SideInt1()
    {
        sideWeaponInt = 1;
    }
    public void SideInt2()
    {
        sideWeaponInt = 2;
    }
    public void SideInt3()
    {
        sideWeaponInt = 3;
    }
    public void SideInt4()
    {
        sideWeaponInt = 4;
    }

    public void UnderInt1()
    {
        underWeaponInt = 1;
    }
    public void UnderInt2()
    {
        underWeaponInt = 2;
    }
    public void UnderInt3()
    {
        underWeaponInt = 3;
    }
    public void UnderInt4()
    {
        underWeaponInt = 4;
    }

    public void LoadoutSave()
    {
        Debug.Log("Loadout Saved");
        PlayerPrefs.SetInt("SelectedNoseWeapon", noseWeaponInt);
        PlayerPrefs.SetInt("SelectedWingWeapon", wingWeaponInt);
        PlayerPrefs.SetInt("SelectedSideWeapon", sideWeaponInt);
        PlayerPrefs.SetInt("SelectedUnderWeapon", underWeaponInt);

    }
}