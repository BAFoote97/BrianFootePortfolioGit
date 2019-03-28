using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour {

    public GameObject dialogueSequenceList;
	public int dialogueSequenceNumber;


    public List<GameObject> GenericEnemyKillList = new List<GameObject>();
    public float genericEnemyKillCooldown;
    public bool genericEnemyKillBool;

    public List<GameObject> GenericEnemyLockedOnList = new List<GameObject>();
    public float genericEnemyLockedOnCooldown;
    public bool genericEnemyLockedOnBool;

    public List<GameObject> GenericEnemyPlayerLockedOnList = new List<GameObject>();
    public float genericEnemyPlayerLockedOnCooldown;
    public bool genericEnemyPlayerLockedOnBool;


    public List<GameObject> WingmanLockedOnList = new List<GameObject>();
    public float wingmanLockedOnCooldown;
    public bool wingmanLockedOnBool;


    public List<GameObject> GenericBetaKillList = new List<GameObject>();
    public float genericBetaKillCooldown;
    public bool genericBetaKillBool;

    public List<GameObject> GenericBetaLockedOnList = new List<GameObject>();
    public float genericBetaLockedOnCooldown;
    public bool genericBetaLockedOnBool;

    public List<GameObject> GenericBetaLockedOnByEnemyList = new List<GameObject>();
    public float genericBetaLockedOnByEnemyCooldown;
    public bool genericBetaLockedOnByEnemyBool;

    public List<GameObject> GenericDeltaKillList = new List<GameObject>();
    public float genericDeltaKillCooldown;
    public bool genericDeltaKillBool;

    public List<GameObject> GenericDeltaLockedOnList = new List<GameObject>();
    public float genericDeltaLockedOnCooldown;
    public bool genericDeltaLockedOnBool;

    public List<GameObject> GenericDeltaLockedOnByEnemyList = new List<GameObject>();
    public float genericDeltaLockedOnByEnemyCooldown;
    public bool genericDeltaLockedOnByEnemyBool;



    public List<GameObject> List1 = new List<GameObject>();
	public float list1Cooldown;
	public bool list1Bool;

	public List<GameObject> List2 = new List<GameObject>();
	public float list2Cooldown;
	public bool list2Bool;

	public List<GameObject> List3 = new List<GameObject>();
	public float list3Cooldown;
	public bool list3Bool;

	public List<GameObject> List4 = new List<GameObject>();
	public float list4Cooldown;
	public bool list4Bool;

	public List<GameObject> List5 = new List<GameObject>();
	public float list5Cooldown;
	public bool list5Bool;

	public List<GameObject> List6 = new List<GameObject>();
	public float list6Cooldown;
	public bool list6Bool;

	public List<GameObject> List7 = new List<GameObject>();
	public float list7Cooldown;
	public bool list7Bool;

	public List<GameObject> List8 = new List<GameObject>();
	public float list8Cooldown;
	public bool list8Bool;

	public List<GameObject> List9 = new List<GameObject>();
	public float list9Cooldown;
	public bool list9Bool;

	public List<GameObject> List10 = new List<GameObject>();
	public float list10Cooldown;
	public bool list10Bool;



    public Text characterNameText;
    public Text quoteText;

    public Color blue;
    public Color red;

    public GameObject textHolder;
    public GameObject sequenceTextHolder;
    

    public bool isAvailable;
    public bool sequenceAvailable;
    public GameObject testList;

	// Use this for initialization
	void Start () {
        characterNameText.enabled = false;
        quoteText.enabled = false;


    }
	
	// Update is called once per frame
	void Update () {
        

        if (dialogueSequenceList != null && sequenceAvailable == true)
        {
            textHolder = null;
            sequenceAvailable = false;
            isAvailable = false;
            StartCoroutine(DialogueSequenceTimer());
        }
		
	}

    public IEnumerator ActiveTimer()
    {
        isAvailable = false;

        
        yield return new WaitForSeconds(textHolder.GetComponent<DialogueHolder>().quoteDelay);

        characterNameText.enabled = true;
        quoteText.enabled = true;



        yield return new WaitForSeconds(textHolder.GetComponent<DialogueHolder>().quoteTime);
        if (textHolder.GetComponent<DialogueHolder>().isOneTimeUse == true)
        {
            if (GenericEnemyKillList.Contains(textHolder))
            {
                GenericEnemyKillList.Remove(textHolder);
            }
            if (GenericEnemyLockedOnList.Contains(textHolder))
            {
                GenericEnemyLockedOnList.Remove(textHolder);
            }
            if (GenericEnemyPlayerLockedOnList.Contains(textHolder))
            {
                GenericEnemyPlayerLockedOnList.Remove(textHolder);
            }
            if (GenericBetaKillList.Contains(textHolder))
            {
                GenericBetaKillList.Remove(textHolder);
            }
            if (GenericBetaLockedOnList.Contains(textHolder))
            {
                GenericBetaLockedOnList.Remove(textHolder);
            }
            if (GenericBetaLockedOnByEnemyList.Contains(textHolder))
            {
                GenericBetaLockedOnByEnemyList.Remove(textHolder);
            }
            if (GenericDeltaKillList.Contains(textHolder))
            {
                GenericDeltaKillList.Remove(textHolder);
            }
            if (GenericDeltaLockedOnList.Contains(textHolder))
            {
                GenericDeltaLockedOnList.Remove(textHolder);
            }
            if (GenericDeltaLockedOnByEnemyList.Contains(textHolder))
            {
                GenericDeltaLockedOnByEnemyList.Remove(textHolder);
            }
            if (List1.Contains(textHolder))
            {
                List1.Remove(textHolder);
            }
            if (List2.Contains(textHolder))
            {
                List2.Remove(textHolder);
            }
            if (List3.Contains(textHolder))
            {
                List3.Remove(textHolder);
            }
            if (List4.Contains(textHolder))
            {
                List4.Remove(textHolder);
            }
            if (List5.Contains(textHolder))
            {
                List5.Remove(textHolder);
            }
            if (List6.Contains(textHolder))
            {
                List6.Remove(textHolder);
            }
            if (List7.Contains(textHolder))
            {
                List7.Remove(textHolder);
            }
            if (List8.Contains(textHolder))
            {
                List8.Remove(textHolder);
            }
            if (List9.Contains(textHolder))
            {
                List9.Remove(textHolder);
            }
            if (List10.Contains(textHolder))
            {
                List10.Remove(textHolder);
            }
            textHolder.GetComponent<DialogueHolder>().RemoveHolder();
        }
        characterNameText.enabled = false;
        quoteText.enabled = false;
        isAvailable = true;
    }

    public void IncreaseDialogueNumber()
    {
        dialogueSequenceNumber += 1;

    }
    public IEnumerator DialogueSequenceTimer()
    {
        yield return new WaitForSeconds(dialogueSequenceList.GetComponent<DialogueList>().sequenceDelay);
        //IncreaseDialogueNumber();
        //dialogueSequenceNumber += 1;
        characterNameText.enabled = false;

        quoteText.enabled = false;

        sequenceTextHolder = dialogueSequenceList.GetComponent<DialogueList>().Dialogue[dialogueSequenceNumber];

        characterNameText.text = sequenceTextHolder.GetComponent<DialogueHolder>().characterName.text;

        characterNameText.color = sequenceTextHolder.GetComponent<DialogueHolder>().characterColor;

        quoteText.text = sequenceTextHolder.GetComponent<DialogueHolder>().quote.text;


        yield return new WaitForSeconds(sequenceTextHolder.GetComponent<DialogueHolder>().quoteDelay);

        characterNameText.enabled = true;

        quoteText.enabled = true;


        yield return new WaitForSeconds(sequenceTextHolder.GetComponent<DialogueHolder>().quoteTime);

        


        if (dialogueSequenceNumber < dialogueSequenceList.GetComponent<DialogueList>().Dialogue.Count)
        {
            dialogueSequenceList.GetComponent<DialogueList>().currentDialogueNumber += 1;

            dialogueSequenceList.GetComponent<DialogueList>().nextDialogueNumber += 1;
            sequenceTextHolder = dialogueSequenceList.GetComponent<DialogueList>().currentDialogue;

            characterNameText.text = sequenceTextHolder.GetComponent<DialogueHolder>().characterName.text;

            characterNameText.color = sequenceTextHolder.GetComponent<DialogueHolder>().characterColor;
            IncreaseDialogueNumber();
            StartCoroutine(DialogueSequenceTimer());
        }
        if (dialogueSequenceNumber == dialogueSequenceList.GetComponent<DialogueList>().Dialogue.Count)
        {
            StartCoroutine(EndDialogueSequence());
        }

    }
    public IEnumerator EndDialogueSequence()
    {
        yield return new WaitForSeconds(sequenceTextHolder.GetComponent<DialogueHolder>().quoteTime);

        sequenceTextHolder = null;
        dialogueSequenceList = null;
        dialogueSequenceNumber = 0;
        characterNameText.enabled = false;
        quoteText.enabled = false;
        isAvailable = true;
        sequenceAvailable = true;
    }

    public void WingmanLockedOn()
    {

        if (isAvailable == true && wingmanLockedOnBool == true)
        {
            textHolder = WingmanLockedOnList[Random.Range(0, WingmanLockedOnList.Count)];

            characterNameText.text = textHolder.GetComponent<DialogueHolder>().characterName.text;

            characterNameText.color = textHolder.GetComponent<DialogueHolder>().characterColor;

            quoteText.text = textHolder.GetComponent<DialogueHolder>().quote.text;

            StartCoroutine(ActiveTimer());

            wingmanLockedOnBool = false;

            StartCoroutine(WingmanLockedOnCooldown());
        }
    }

    public IEnumerator WingmanLockedOnCooldown()
    {
        yield return new WaitForSeconds(wingmanLockedOnCooldown);
        wingmanLockedOnBool = true;

    }


    public void GenericEnemyKilled()
    {
        

		if (isAvailable == true && genericEnemyKillBool == true && GenericEnemyKillList.Count > 0)
        {

            textHolder = GenericEnemyKillList[Random.Range(0, GenericEnemyKillList.Count)];

            characterNameText.text = textHolder.GetComponent<DialogueHolder>().characterName.text;

            characterNameText.color = textHolder.GetComponent<DialogueHolder>().characterColor;

            quoteText.text = textHolder.GetComponent<DialogueHolder>().quote.text;

            StartCoroutine(ActiveTimer());

            genericEnemyKillBool = false;

            StartCoroutine(GenericEnemyKilledCooldown());
        }
    }

    public IEnumerator GenericEnemyKilledCooldown()
    {
        yield return new WaitForSeconds(genericEnemyKillCooldown);
        genericEnemyKillBool = true;

    }

    public void GenericEnemyLockedOn()
    {

		if (isAvailable == true && genericEnemyLockedOnBool == true && GenericEnemyLockedOnList.Count > 0)
        {
			textHolder = GenericEnemyLockedOnList[Random.Range(0, GenericEnemyLockedOnList.Count)];

            characterNameText.text = textHolder.GetComponent<DialogueHolder>().characterName.text;

            characterNameText.color = textHolder.GetComponent<DialogueHolder>().characterColor;

            quoteText.text = textHolder.GetComponent<DialogueHolder>().quote.text;

            StartCoroutine(ActiveTimer());

            genericEnemyLockedOnBool = false;

            StartCoroutine(GenericEnemyLockedOnCooldown());
        }
    }

    public IEnumerator GenericEnemyLockedOnCooldown()
    {
        yield return new WaitForSeconds(genericEnemyLockedOnCooldown);
        genericEnemyLockedOnBool = true;

    }

    

    public void GenericEnemyPlayerLockedOn()
    {


		if (isAvailable == true && genericEnemyPlayerLockedOnBool == true && GenericEnemyPlayerLockedOnList.Count > 0)
        {
            textHolder = GenericEnemyPlayerLockedOnList[Random.Range(0, GenericEnemyPlayerLockedOnList.Count)];

            characterNameText.text = textHolder.GetComponent<DialogueHolder>().characterName.text;

            characterNameText.color = textHolder.GetComponent<DialogueHolder>().characterColor;

            quoteText.text = textHolder.GetComponent<DialogueHolder>().quote.text;

            StartCoroutine(ActiveTimer());

            genericEnemyPlayerLockedOnBool = false;

            StartCoroutine(GenericEnemyPlayerLockedOnCooldown());
        }
    }

    public IEnumerator GenericEnemyPlayerLockedOnCooldown()
    {
        yield return new WaitForSeconds(genericEnemyPlayerLockedOnCooldown);
        genericEnemyPlayerLockedOnBool = true;

    }

    public void GenericBetaKilled()
    {

		if (isAvailable == true && genericBetaKillBool == true && GenericBetaKillList.Count > 0)
        {

            textHolder = GenericBetaKillList[Random.Range(0, GenericBetaKillList.Count)];

            characterNameText.text = textHolder.GetComponent<DialogueHolder>().characterName.text;

            characterNameText.color = textHolder.GetComponent<DialogueHolder>().characterColor;

            quoteText.text = textHolder.GetComponent<DialogueHolder>().quote.text;

            StartCoroutine(ActiveTimer());

            genericBetaKillBool = false;

            StartCoroutine(GenericBetaKilledCooldown());
        }
    }

    public IEnumerator GenericBetaKilledCooldown()
    {
        yield return new WaitForSeconds(genericBetaKillCooldown);
        genericBetaKillBool = true;

    }

    public void GenericBetaLockedOn()
    {


		if (isAvailable == true && genericBetaLockedOnBool == true && GenericBetaLockedOnList.Count > 0)
        {
            textHolder = GenericBetaLockedOnList[Random.Range(0, GenericBetaLockedOnList.Count)];

            characterNameText.text = textHolder.GetComponent<DialogueHolder>().characterName.text;

            characterNameText.color = textHolder.GetComponent<DialogueHolder>().characterColor;

            quoteText.text = textHolder.GetComponent<DialogueHolder>().quote.text;

            StartCoroutine(ActiveTimer());

            genericBetaLockedOnBool = false;

            StartCoroutine(GenericBetaLockedOnCooldown());
        }
    }

    public IEnumerator GenericBetaLockedOnCooldown()
    {
        yield return new WaitForSeconds(genericBetaLockedOnCooldown);
        genericBetaLockedOnBool = true;

    }

    public void GenericBetaLockedOnByEnemy()
    {


		if (isAvailable == true && genericBetaLockedOnByEnemyBool == true && GenericBetaLockedOnByEnemyList.Count > 0)
        {
            textHolder = GenericBetaLockedOnByEnemyList[Random.Range(0, GenericBetaLockedOnByEnemyList.Count)];

            characterNameText.text = textHolder.GetComponent<DialogueHolder>().characterName.text;

            characterNameText.color = textHolder.GetComponent<DialogueHolder>().characterColor;

            quoteText.text = textHolder.GetComponent<DialogueHolder>().quote.text;

            StartCoroutine(ActiveTimer());

            genericBetaLockedOnByEnemyBool = false;

            StartCoroutine(GenericBetaLockedOnByEnemyCooldown());
        }
    }

    public IEnumerator GenericBetaLockedOnByEnemyCooldown()
    {
        yield return new WaitForSeconds(genericBetaLockedOnByEnemyCooldown);
        genericBetaLockedOnByEnemyBool = true;

    }

    public void GenericDeltaKilled()
    {

		if (isAvailable == true && genericDeltaKillBool == true && GenericDeltaKillList.Count > 0)
        {

            textHolder = GenericDeltaKillList[Random.Range(0, GenericDeltaKillList.Count)];

            characterNameText.text = textHolder.GetComponent<DialogueHolder>().characterName.text;

            characterNameText.color = textHolder.GetComponent<DialogueHolder>().characterColor;

            quoteText.text = textHolder.GetComponent<DialogueHolder>().quote.text;

            StartCoroutine(ActiveTimer());

            genericDeltaKillBool = false;

            StartCoroutine(GenericDeltaKilledCooldown());
        }
    }

    public IEnumerator GenericDeltaKilledCooldown()
    {
        yield return new WaitForSeconds(genericDeltaKillCooldown);
        genericDeltaKillBool = true;

    }

    public void GenericDeltaLockedOn()
    {


		if (isAvailable == true && genericDeltaLockedOnBool == true && GenericDeltaLockedOnList.Count > 0)
        {
            textHolder = GenericDeltaLockedOnList[Random.Range(0, GenericDeltaLockedOnList.Count)];

            characterNameText.text = textHolder.GetComponent<DialogueHolder>().characterName.text;

            characterNameText.color = textHolder.GetComponent<DialogueHolder>().characterColor;

            quoteText.text = textHolder.GetComponent<DialogueHolder>().quote.text;

            StartCoroutine(ActiveTimer());

            genericDeltaLockedOnBool = false;

            StartCoroutine(GenericDeltaLockedOnCooldown());
        }
    }

    public IEnumerator GenericDeltaLockedOnCooldown()
    {
        yield return new WaitForSeconds(genericDeltaLockedOnCooldown);
        genericDeltaLockedOnBool = true;

    }

    public void GenericDeltaLockedOnByEnemy()
    {


		if (isAvailable == true && genericDeltaLockedOnByEnemyBool == true && GenericDeltaLockedOnByEnemyList.Count > 0)
        {
            textHolder = GenericDeltaLockedOnByEnemyList[Random.Range(0, GenericDeltaLockedOnByEnemyList.Count)];

            characterNameText.text = textHolder.GetComponent<DialogueHolder>().characterName.text;

            characterNameText.color = textHolder.GetComponent<DialogueHolder>().characterColor;

            quoteText.text = textHolder.GetComponent<DialogueHolder>().quote.text;

            StartCoroutine(ActiveTimer());

            genericDeltaLockedOnByEnemyBool = false;

            StartCoroutine(GenericDeltaLockedOnByEnemyCooldown());
        }
    }

    public IEnumerator GenericDeltaLockedOnByEnemyCooldown()
    {
        yield return new WaitForSeconds(genericDeltaLockedOnByEnemyCooldown);
        genericDeltaLockedOnByEnemyBool = true;

    }

    public void SubtitleList1()
	{


		if (isAvailable == true && list1Bool == true && List1.Count > 0)
		{
			textHolder = List1[Random.Range(0, List1.Count)];

			characterNameText.text = textHolder.GetComponent<DialogueHolder>().characterName.text;

			characterNameText.color = textHolder.GetComponent<DialogueHolder>().characterColor;

			quoteText.text = textHolder.GetComponent<DialogueHolder>().quote.text;

			StartCoroutine(ActiveTimer());

			list1Bool = false;

			StartCoroutine(List1Cooldown());
		}
	}

	public IEnumerator List1Cooldown()
	{
		yield return new WaitForSeconds(list1Cooldown);
		list1Bool = true;

	}

	public void SubtitleList2()
	{


		if (isAvailable == true && list2Bool == true && List2.Count > 0)
		{
			textHolder = List2[Random.Range(0, List2.Count)];

			characterNameText.text = textHolder.GetComponent<DialogueHolder>().characterName.text;

			characterNameText.color = textHolder.GetComponent<DialogueHolder>().characterColor;

			quoteText.text = textHolder.GetComponent<DialogueHolder>().quote.text;

			StartCoroutine(ActiveTimer());

			list2Bool = false;

			StartCoroutine(List2Cooldown());
		}
	}

	public IEnumerator List2Cooldown()
	{
		yield return new WaitForSeconds(list2Cooldown);
		list2Bool = true;

	}

	public void SubtitleList3()
	{


		if (isAvailable == true && list3Bool == true && List3.Count > 0)
		{
			textHolder = List3[Random.Range(0, List3.Count)];

			characterNameText.text = textHolder.GetComponent<DialogueHolder>().characterName.text;

			characterNameText.color = textHolder.GetComponent<DialogueHolder>().characterColor;

			quoteText.text = textHolder.GetComponent<DialogueHolder>().quote.text;

			StartCoroutine(ActiveTimer());

			list3Bool = false;

			StartCoroutine(List3Cooldown());
		}
	}

	public IEnumerator List3Cooldown()
	{
		yield return new WaitForSeconds(list3Cooldown);
		list3Bool = true;

	}

	public void SubtitleList4()
	{


		if (isAvailable == true && list4Bool == true && List4.Count > 0)
		{
			textHolder = List4[Random.Range(0, List4.Count)];

			characterNameText.text = textHolder.GetComponent<DialogueHolder>().characterName.text;

			characterNameText.color = textHolder.GetComponent<DialogueHolder>().characterColor;

			quoteText.text = textHolder.GetComponent<DialogueHolder>().quote.text;

			StartCoroutine(ActiveTimer());

			list4Bool = false;

			StartCoroutine(List4Cooldown());
		}
	}

	public IEnumerator List4Cooldown()
	{
		yield return new WaitForSeconds(list4Cooldown);
		list4Bool = true;

	}

	public void SubtitleList5()
	{


		if (isAvailable == true && list5Bool == true && List5.Count > 0)
		{
			textHolder = List5[Random.Range(0, List5.Count)];

			characterNameText.text = textHolder.GetComponent<DialogueHolder>().characterName.text;

			characterNameText.color = textHolder.GetComponent<DialogueHolder>().characterColor;

			quoteText.text = textHolder.GetComponent<DialogueHolder>().quote.text;

			StartCoroutine(ActiveTimer());

			list5Bool = false;

			StartCoroutine(List5Cooldown());
		}
	}

	public IEnumerator List5Cooldown()
	{
		yield return new WaitForSeconds(list5Cooldown);
		list5Bool = true;

	}

	public void SubtitleList6()
	{


		if (isAvailable == true && list6Bool == true && List6.Count > 0)
		{
			textHolder = List6[Random.Range(0, List6.Count)];

			characterNameText.text = textHolder.GetComponent<DialogueHolder>().characterName.text;

			characterNameText.color = textHolder.GetComponent<DialogueHolder>().characterColor;

			quoteText.text = textHolder.GetComponent<DialogueHolder>().quote.text;

			StartCoroutine(ActiveTimer());

			list6Bool = false;

			StartCoroutine(List6Cooldown());
		}
	}

	public IEnumerator List6Cooldown()
	{
		yield return new WaitForSeconds(list6Cooldown);
		list6Bool = true;

	}

	public void SubtitleList7()
	{


		if (isAvailable == true && list7Bool == true && List7.Count > 0)
		{
			textHolder = List7[Random.Range(0, List7.Count)];

			characterNameText.text = textHolder.GetComponent<DialogueHolder>().characterName.text;

			characterNameText.color = textHolder.GetComponent<DialogueHolder>().characterColor;

			quoteText.text = textHolder.GetComponent<DialogueHolder>().quote.text;

			StartCoroutine(ActiveTimer());

			list7Bool = false;

			StartCoroutine(List7Cooldown());
		}
	}

	public IEnumerator List7Cooldown()
	{
		yield return new WaitForSeconds(list7Cooldown);
		list7Bool = true;

	}

	public void SubtitleList8()
	{


		if (isAvailable == true && list8Bool == true && List8.Count > 0)
		{
			textHolder = List8[Random.Range(0, List8.Count)];

			characterNameText.text = textHolder.GetComponent<DialogueHolder>().characterName.text;

			characterNameText.color = textHolder.GetComponent<DialogueHolder>().characterColor;

			quoteText.text = textHolder.GetComponent<DialogueHolder>().quote.text;

			StartCoroutine(ActiveTimer());

			list8Bool = false;

			StartCoroutine(List8Cooldown());
		}
	}

	public IEnumerator List8Cooldown()
	{
		yield return new WaitForSeconds(list8Cooldown);
		list8Bool = true;

	}

	public void SubtitleList9()
	{


		if (isAvailable == true && list9Bool == true && List9.Count > 0)
		{
			textHolder = List9[Random.Range(0, List9.Count)];

			characterNameText.text = textHolder.GetComponent<DialogueHolder>().characterName.text;

			characterNameText.color = textHolder.GetComponent<DialogueHolder>().characterColor;

			quoteText.text = textHolder.GetComponent<DialogueHolder>().quote.text;

			StartCoroutine(ActiveTimer());

			list9Bool = false;

			StartCoroutine(List9Cooldown());
		}
	}

	public IEnumerator List9Cooldown()
	{
		yield return new WaitForSeconds(list9Cooldown);
		list9Bool = true;

	}

	public void SubtitleList10()
	{


		if (isAvailable == true && list10Bool == true && List10.Count > 0)
		{
			textHolder = List10[Random.Range(0, List10.Count)];

			characterNameText.text = textHolder.GetComponent<DialogueHolder>().characterName.text;

			characterNameText.color = textHolder.GetComponent<DialogueHolder>().characterColor;

			quoteText.text = textHolder.GetComponent<DialogueHolder>().quote.text;

			StartCoroutine(ActiveTimer());

			list10Bool = false;

			StartCoroutine(List10Cooldown());
		}
	}

	public IEnumerator List10Cooldown()
	{
		yield return new WaitForSeconds(list10Cooldown);
		list10Bool = true;

	}



}
