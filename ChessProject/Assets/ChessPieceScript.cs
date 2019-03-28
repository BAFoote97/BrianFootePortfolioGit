using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChessPieceScript : MonoBehaviour {

	public GameObject chessBoardRef;

	public bool isWhite;
	public bool isBlack;

    public bool isPawn;
    public bool isBishop;
    public bool isKnight;
    public bool isRook;
    public bool isQueen;
    public bool isKing;

    public bool firstMove;

    public GameObject mySpace;

	public bool inputAvailable;

	// Use this for initialization
	void Start () {
		inputAvailable = true;
		firstMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isWhite == true) {
			mySpace.GetComponent<ChessSpaceScript> ().occupiedByWhite = true;
			mySpace.GetComponent<ChessSpaceScript> ().occupiedByBlack = false;
		}
		if (isBlack == true) {
			mySpace.GetComponent<ChessSpaceScript> ().occupiedByBlack = true;
			mySpace.GetComponent<ChessSpaceScript> ().occupiedByWhite = false;
		}
		if (isPawn == true) {
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsPawn = true;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsBishop = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsKnight = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsRook = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsQueen = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsKing = false;
		}
		if (isBishop == true) {
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsPawn = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsBishop = true;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsKnight = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsRook = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsQueen = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsKing = false;
		}
		if (isKnight == true) {
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsPawn = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsBishop = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsKnight = true;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsRook = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsQueen = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsKing = false;
		}
		if (isRook == true) {
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsPawn = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsBishop = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsKnight = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsRook = true;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsQueen = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsKing = false;
		}
		if (isQueen == true) {
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsPawn = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsBishop = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsKnight = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsRook = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsQueen = true;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsKing = false;
		}
		if (isKing == true) {
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsPawn = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsBishop = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsKnight = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsRook = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsQueen = false;
			mySpace.GetComponent<ChessSpaceScript> ().currentPieceIsKing = true;
		}
		//gameObject.transform.position = mySpace.transform.position;
		gameObject.transform.position = new Vector3(mySpace.transform.position.x, 0.5f, mySpace.transform.position.z);
		mySpace.GetComponent<ChessSpaceScript> ().currentPiece = gameObject;
		if (chessBoardRef.GetComponent<ChessBoardRefScript> ().whiteMove == true) {
			if (Input.GetMouseButtonDown (0) && mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == true && inputAvailable == true) {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				//if (hit.transform.gameObject.GetComponent<ChessSpaceScript> ().isAvailable == true) {
				//	mySpace = hit.transform.gameObject;
				//}
				if (Physics.Raycast (ray, out hit, 100.0f)) {
					if (mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == true && hit.transform.gameObject.GetComponent<ChessSpaceScript> () == true && hit.transform.gameObject.GetComponent<ChessSpaceScript> ().isAvailable == true) {
						StartCoroutine (InputDelay ());
						//mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock = false;

						chessBoardRef.GetComponent<ChessBoardRefScript> ().DeselectSpace ();
						chessBoardRef.GetComponent<ChessBoardRefScript> ().BlackTurn ();
						firstMove = false;

						mySpace.GetComponent<ChessSpaceScript> ().currentPiece = null;
						mySpace = hit.transform.gameObject;
					}
					if (mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == true && hit.transform.gameObject.GetComponent<ChessSpaceScript> () == true && hit.transform.gameObject.GetComponent<ChessSpaceScript> ().isContested == true 
						|| mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == true && hit.transform.gameObject.GetComponent<ChessPieceScript> () == true && hit.transform.gameObject.GetComponent<ChessPieceScript> ().mySpace.GetComponent<ChessSpaceScript>().isContested) {

						StartCoroutine (InputDelay ());
						//mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock = false;

						chessBoardRef.GetComponent<ChessBoardRefScript> ().DeselectSpace ();
						chessBoardRef.GetComponent<ChessBoardRefScript> ().BlackTurn ();
						firstMove = false;


						mySpace.GetComponent<ChessSpaceScript> ().currentPiece = null;
						if (hit.transform.gameObject.GetComponent<ChessSpaceScript> () == true) {
							mySpace = hit.transform.gameObject;
							Destroy (hit.transform.gameObject.GetComponent<ChessSpaceScript> ().currentPiece.gameObject);
						}
						if (hit.transform.gameObject.GetComponent<ChessPieceScript> () == true) {
							mySpace = hit.transform.gameObject.GetComponent<ChessPieceScript> ().mySpace;
							Destroy (hit.transform.gameObject);
						}
					}

					if (hit.transform.gameObject == mySpace && mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == true 
						|| hit.transform.gameObject == gameObject && mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == true
						|| hit.transform.gameObject.GetComponent<ChessSpaceScript>() == true && hit.transform.gameObject.GetComponent<ChessSpaceScript>().isAvailable != true
						|| hit.transform.gameObject.GetComponent<ChessPieceScript>() == true && hit.transform.gameObject.GetComponent<ChessPieceScript>().mySpace.GetComponent<ChessSpaceScript>().isAvailable != true
						|| hit.transform.gameObject.GetComponent<ChessSpaceScript>() == true && hit.transform.gameObject.GetComponent<ChessSpaceScript>().occupiedByWhite == true
						|| hit.transform.gameObject.GetComponent<ChessPieceScript>() == true && hit.transform.gameObject.GetComponent<ChessPieceScript>().mySpace.GetComponent<ChessSpaceScript>().occupiedByWhite == true) {
						StartCoroutine (InputDelay ());

						//mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock = false;
						chessBoardRef.GetComponent<ChessBoardRefScript> ().DeselectSpace ();
//						if (hit.transform.gameObject.GetComponent<ChessSpaceScript>() == true && hit.transform.gameObject.GetComponent<ChessSpaceScript> ().occupiedByWhite == true && hit.transform.gameObject.GetComponent<ChessSpaceScript> ().isSelectedBlock == false ||
//							hit.transform.gameObject.GetComponent<ChessPieceScript>() == true &&  hit.transform.gameObject.GetComponent<ChessPieceScript> ().isWhite == true && hit.transform.gameObject.GetComponent<ChessPieceScript> ().mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == false) {
//							Debug.Log ("New selection");
//							//chessBoardRef.GetComponent<ChessBoardRefScript> ().SelectSpace ();
//						}
					}
//					if (hit.transform.gameObject.GetComponent<ChessSpaceScript>() == true && hit.transform.gameObject.GetComponent<ChessSpaceScript>().isAvailable == false
//						|| hit.transform.gameObject.GetComponent<ChessPieceScript>() == true && hit.transform.gameObject.GetComponent<ChessPieceScript>().mySpace.GetComponent<ChessSpaceScript>().isAvailable == false) {
//						chessBoardRef.GetComponent<ChessBoardRefScript> ().DeselectSpace ();
//
//						StartCoroutine (InputDelay ());
//
//						mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock = false;
//					}


				}
			}

			//if (Input.GetMouseButtonDown(0) && mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == true) 
			if (Input.GetMouseButtonDown (0) && mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == false && inputAvailable == true && chessBoardRef.GetComponent<ChessBoardRefScript>().selectedSpace == null) {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				//if (hit.transform.gameObject.GetComponent<ChessSpaceScript> ().isAvailable == true) {
				//	mySpace = hit.transform.gameObject;
				//}
				if (Physics.Raycast (ray, out hit, 100.0f)) {
				
					if (hit.transform.gameObject == mySpace && mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == false && isWhite == true
						|| hit.transform.gameObject == gameObject && mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == false && isWhite == true) {
						StartCoroutine (InputDelay ());

						chessBoardRef.GetComponent<ChessBoardRefScript> ().DeselectSpace ();

						chessBoardRef.GetComponent<ChessBoardRefScript> ().SelectSpace ();

						chessBoardRef.GetComponent<ChessBoardRefScript> ().selectedSpace = mySpace;

					}



				}
			}

		}
		if (chessBoardRef.GetComponent<ChessBoardRefScript> ().blackMove == true) {
			if (Input.GetMouseButtonDown (0) && mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == true && inputAvailable == true) {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				//if (hit.transform.gameObject.GetComponent<ChessSpaceScript> ().isAvailable == true) {
				//	mySpace = hit.transform.gameObject;
				//}
				if (Physics.Raycast (ray, out hit, 100.0f)) {
					if (mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == true && hit.transform.gameObject.GetComponent<ChessSpaceScript> () == true && hit.transform.gameObject.GetComponent<ChessSpaceScript> ().isAvailable == true) {
						StartCoroutine (InputDelay ());
						//mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock = false;

						chessBoardRef.GetComponent<ChessBoardRefScript> ().DeselectSpace ();
						chessBoardRef.GetComponent<ChessBoardRefScript> ().WhiteTurn ();
						firstMove = false;

						mySpace.GetComponent<ChessSpaceScript> ().currentPiece = null;
						mySpace = hit.transform.gameObject;
					}
					if (mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == true && hit.transform.gameObject.GetComponent<ChessSpaceScript> () == true && hit.transform.gameObject.GetComponent<ChessSpaceScript> ().isContested == true 
						|| mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == true && hit.transform.gameObject.GetComponent<ChessPieceScript> () == true && hit.transform.gameObject.GetComponent<ChessPieceScript> ().mySpace.GetComponent<ChessSpaceScript>().isContested) {

						StartCoroutine (InputDelay ());
						//mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock = false;

						chessBoardRef.GetComponent<ChessBoardRefScript> ().DeselectSpace ();
						chessBoardRef.GetComponent<ChessBoardRefScript> ().WhiteTurn ();
						firstMove = false;


						mySpace.GetComponent<ChessSpaceScript> ().currentPiece = null;
						if (hit.transform.gameObject.GetComponent<ChessSpaceScript> () == true) {
							mySpace = hit.transform.gameObject;
							Destroy (hit.transform.gameObject.GetComponent<ChessSpaceScript> ().currentPiece.gameObject);
						}
						if (hit.transform.gameObject.GetComponent<ChessPieceScript> () == true) {
							mySpace = hit.transform.gameObject.GetComponent<ChessPieceScript> ().mySpace;
							Destroy (hit.transform.gameObject);
						}
					}

					if (hit.transform.gameObject == mySpace && mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == true 
						|| hit.transform.gameObject == gameObject && mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == true
						|| hit.transform.gameObject.GetComponent<ChessSpaceScript>() == true && hit.transform.gameObject.GetComponent<ChessSpaceScript>().isAvailable != true
						|| hit.transform.gameObject.GetComponent<ChessPieceScript>() == true && hit.transform.gameObject.GetComponent<ChessPieceScript>().mySpace.GetComponent<ChessSpaceScript>().isAvailable != true
						|| hit.transform.gameObject.GetComponent<ChessSpaceScript>() == true && hit.transform.gameObject.GetComponent<ChessSpaceScript>().occupiedByBlack == true
						|| hit.transform.gameObject.GetComponent<ChessPieceScript>() == true && hit.transform.gameObject.GetComponent<ChessPieceScript>().mySpace.GetComponent<ChessSpaceScript>().occupiedByBlack == true) {
						StartCoroutine (InputDelay ());

						//mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock = false;
						chessBoardRef.GetComponent<ChessBoardRefScript> ().DeselectSpace ();
						//						if (hit.transform.gameObject.GetComponent<ChessSpaceScript>() == true && hit.transform.gameObject.GetComponent<ChessSpaceScript> ().occupiedByWhite == true && hit.transform.gameObject.GetComponent<ChessSpaceScript> ().isSelectedBlock == false ||
						//							hit.transform.gameObject.GetComponent<ChessPieceScript>() == true &&  hit.transform.gameObject.GetComponent<ChessPieceScript> ().isWhite == true && hit.transform.gameObject.GetComponent<ChessPieceScript> ().mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == false) {
						//							Debug.Log ("New selection");
						//							//chessBoardRef.GetComponent<ChessBoardRefScript> ().SelectSpace ();
						//						}
					}
					//					if (hit.transform.gameObject.GetComponent<ChessSpaceScript>() == true && hit.transform.gameObject.GetComponent<ChessSpaceScript>().isAvailable == false
					//						|| hit.transform.gameObject.GetComponent<ChessPieceScript>() == true && hit.transform.gameObject.GetComponent<ChessPieceScript>().mySpace.GetComponent<ChessSpaceScript>().isAvailable == false) {
					//						chessBoardRef.GetComponent<ChessBoardRefScript> ().DeselectSpace ();
					//
					//						StartCoroutine (InputDelay ());
					//
					//						mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock = false;
					//					}


				}
			}

			//if (Input.GetMouseButtonDown(0) && mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == true) 
			if (Input.GetMouseButtonDown (0) && mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == false && inputAvailable == true && chessBoardRef.GetComponent<ChessBoardRefScript>().selectedSpace == null) {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				//if (hit.transform.gameObject.GetComponent<ChessSpaceScript> ().isAvailable == true) {
				//	mySpace = hit.transform.gameObject;
				//}
				if (Physics.Raycast (ray, out hit, 100.0f)) {

					if (hit.transform.gameObject == mySpace && mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == false && isBlack == true
						|| hit.transform.gameObject == gameObject && mySpace.GetComponent<ChessSpaceScript> ().isSelectedBlock == false && isBlack == true) {
						StartCoroutine (InputDelay ());

						chessBoardRef.GetComponent<ChessBoardRefScript> ().DeselectSpace ();

						chessBoardRef.GetComponent<ChessBoardRefScript> ().SelectSpace ();

						chessBoardRef.GetComponent<ChessBoardRefScript> ().selectedSpace = mySpace;

					}



				}
			}

		}
	}

	IEnumerator InputDelay(){
		inputAvailable = false;
		yield return new WaitForSeconds (0.1f);
		inputAvailable = true;
	}
}
