using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoardRefScript : MonoBehaviour {

	public bool nothingSelected;

	public GameObject selectedSpace;

	public bool whiteMove;
	public bool blackMove;

	public bool whiteCheck;
	public bool blackCheck;

	public List <GameObject> WhiteSpaceInCheck = new List<GameObject>();
	public List <GameObject> BlackSpaceInCheck = new List<GameObject>();
	// Use this for initialization
	void Start () {
		nothingSelected = true;
		whiteMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (WhiteSpaceInCheck.Count > 0) {
			whiteCheck = true;
			Debug.Log ("White is in check");
		}

		if (BlackSpaceInCheck.Count > 0) {
			blackCheck = true;
			Debug.Log ("Black is in check");
		}

		if (WhiteSpaceInCheck.Count == 0) {
			whiteCheck = false;
		}

		if (BlackSpaceInCheck.Count == 0) {
			blackCheck = false;
		}
		WhiteSpaceInCheck.Clear();
		BlackSpaceInCheck.Clear();

	}

	public void SelectSpace(){

		nothingSelected = false;
	}
	public void DeselectSpace(){
		if (selectedSpace != null) {
			selectedSpace.GetComponent<ChessSpaceScript> ().Unavailable ();
		}

		nothingSelected = true;

		selectedSpace = null;

	}

	public void WhiteTurn(){
		whiteMove = true;
		blackMove = false;
	}
	public void BlackTurn(){
		blackMove = true;
		whiteMove = false;
	}
}
