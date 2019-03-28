using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChessSpaceScript : MonoBehaviour {

	public GameObject chessBoardRef;

	public List<GameObject> VulnerableTo = new List<GameObject> ();
	public bool isVulnerable;

    public List<GameObject> NorthRow = new List<GameObject>();
    public List<GameObject> NorthEastRow = new List<GameObject>();
    public List<GameObject> EastRow = new List<GameObject>();
    public List<GameObject> SouthEastRow = new List<GameObject>();
    public List<GameObject> SouthRow = new List<GameObject>();
    public List<GameObject> SouthWestRow = new List<GameObject>();
    public List<GameObject> WestRow = new List<GameObject>();
    public List<GameObject> NorthWestRow = new List<GameObject>();

    public GameObject pawnNorth1;
    public GameObject pawnNorth2;
    public GameObject pawnNE;
    public GameObject pawnNW;
    public GameObject pawnSouth1;
    public GameObject pawnSouth2;
    public GameObject pawnSE;
    public GameObject pawnSW;

    public GameObject knightSpaceNE;
    public GameObject knightSpaceNW;
    public GameObject knightSpaceEN;
    public GameObject knightSpaceES;
    public GameObject knightSpaceSE;
    public GameObject knightSpaceSW;
    public GameObject knightSpaceWN;
    public GameObject knightSpaceWS;

    public GameObject kingRookSwitchEast;
    public GameObject kingRookSwitchWest;

    public GameObject currentPiece;
    public bool currentPieceIsPawn;
    public bool currentPieceIsBishop;
    public bool currentPieceIsKnight;
    public bool currentPieceIsRook;
    public bool currentPieceIsQueen;
    public bool currentPieceIsKing;

	public Material defaultMat;

    public bool isSelectedBlock;
	public Material isSelectedMat;
    public GameObject nextBlock;

    public bool isAvailable;
	public Material isAvailableMat;
    public bool isContested;
	public Material isContestedMat;
    public bool occupiedByWhite;
    public bool occupiedByBlack;

	public bool inCheck;

	public Renderer rend;

    // Use this for initialization
    void Start () {
		rend = gameObject.GetComponent<Renderer> ();

        pawnNorth1 = NorthRow[0];
        pawnNorth2 = NorthRow[1];
        pawnNE = NorthEastRow[0];
        pawnNW = NorthWestRow[0];
        pawnSouth1 = SouthRow[0];
        pawnSouth2 = SouthRow[1];
        pawnSE = SouthEastRow[0];
        pawnSW = SouthWestRow[0];



		if (NorthRow [1] != null && NorthRow [1].GetComponent<ChessSpaceScript> ().EastRow [0] != null) {
			knightSpaceNE = NorthRow [1].GetComponent<ChessSpaceScript> ().EastRow [0];
		}
		if (NorthRow [1] != null && NorthRow [1].GetComponent<ChessSpaceScript> ().WestRow [0] != null) {
			knightSpaceNW = NorthRow [1].GetComponent<ChessSpaceScript> ().WestRow [0];
		}
		if (EastRow [1] != null && EastRow [1].GetComponent<ChessSpaceScript> ().NorthRow [0] != null) {
			knightSpaceEN = EastRow [1].GetComponent<ChessSpaceScript> ().NorthRow [0];
		}
		if (EastRow [1] != null && EastRow [1].GetComponent<ChessSpaceScript> ().SouthRow [0] != null) {
			knightSpaceES = EastRow [1].GetComponent<ChessSpaceScript> ().SouthRow [0];
		}
		if (SouthRow [1] != null && SouthRow [1].GetComponent<ChessSpaceScript> ().EastRow [0] != null) {
			knightSpaceSE = SouthRow [1].GetComponent<ChessSpaceScript> ().EastRow [0];
		}
		if (SouthRow [1] != null && SouthRow [1].GetComponent<ChessSpaceScript> ().WestRow [0] != null) {
			knightSpaceSW = SouthRow [1].GetComponent<ChessSpaceScript> ().WestRow [0];
		}
		if (WestRow [1] != null && WestRow [1].GetComponent<ChessSpaceScript> ().NorthRow [0] != null) {
			knightSpaceWN = WestRow [1].GetComponent<ChessSpaceScript> ().NorthRow [0];
		}
		if (WestRow [1] != null && WestRow [1].GetComponent<ChessSpaceScript> ().SouthRow [0] != null) {
			knightSpaceWS = WestRow [1].GetComponent<ChessSpaceScript> ().SouthRow [0];
		}


    }

    // Update is called once per frame
    void Update () {
		if (currentPieceIsKing == true && isVulnerable == true) {
			inCheck = true;
		}
		if (currentPieceIsKing == true && isVulnerable == false) {
			inCheck = false;
		}

		if (occupiedByWhite == true && inCheck == true) {
			chessBoardRef.GetComponent<ChessBoardRefScript> ().WhiteSpaceInCheck.Add (gameObject);
		}
		if (occupiedByBlack == true && inCheck == true) {
			chessBoardRef.GetComponent<ChessBoardRefScript> ().BlackSpaceInCheck.Add (gameObject);
		}


		if (gameObject == chessBoardRef.GetComponent<ChessBoardRefScript> ().selectedSpace) {
			isSelectedBlock = true;
		}
		if (gameObject != chessBoardRef.GetComponent<ChessBoardRefScript> ().selectedSpace) {
//			if (NorthRow [0] != null) {
//				NorthRow [0].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (NorthRow [1] != null) {
//				NorthRow [1].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (NorthRow [2] != null) {
//				NorthRow [2].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (NorthRow [3] != null) {
//				NorthRow [3].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (NorthRow [4] != null) {
//				NorthRow [4].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (NorthRow [5] != null) {
//				NorthRow [5].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (NorthRow [6] != null) {
//				NorthRow [6].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (NorthRow [7] != null) {
//				NorthRow [7].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//
//			if (NorthEastRow [0] != null) {
//				NorthEastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (NorthEastRow [1] != null) {
//				NorthEastRow [1].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (NorthEastRow [2] != null) {
//				NorthEastRow [2].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (NorthEastRow [3] != null) {
//				NorthEastRow [3].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (NorthEastRow [4] != null) {
//				NorthEastRow [4].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (NorthEastRow [5] != null) {
//				NorthEastRow [5].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (NorthEastRow [6] != null) {
//				NorthEastRow [6].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (NorthEastRow [7] != null) {
//				NorthEastRow [7].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//
//			if (EastRow [0] != null) {
//				EastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (EastRow [1] != null) {
//				EastRow [1].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (EastRow [2] != null) {
//				EastRow [2].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (EastRow [3] != null) {
//				EastRow [3].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (EastRow [4] != null) {
//				EastRow [4].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (EastRow [5] != null) {
//				EastRow [5].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (EastRow [6] != null) {
//				EastRow [6].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (EastRow [7] != null) {
//				EastRow [7].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//
//			if (SouthEastRow [0] != null) {
//				SouthEastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (SouthEastRow [1] != null) {
//				SouthEastRow [1].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (SouthEastRow [2] != null) {
//				SouthEastRow [2].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (SouthEastRow [3] != null) {
//				SouthEastRow [3].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (SouthEastRow [4] != null) {
//				SouthEastRow [4].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (SouthEastRow [5] != null) {
//				SouthEastRow [5].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (SouthEastRow [6] != null) {
//				SouthEastRow [6].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (SouthEastRow [7] != null) {
//				SouthEastRow [7].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//
//			if (SouthRow [0] != null) {
//				SouthRow [0].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (SouthRow [1] != null) {
//				SouthRow [1].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (SouthRow [2] != null) {
//				SouthRow [2].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (SouthRow [3] != null) {
//				SouthRow [3].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (SouthRow [4] != null) {
//				SouthRow [4].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (SouthRow [5] != null) {
//				SouthRow [5].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (SouthRow [6] != null) {
//				SouthRow [6].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (SouthRow [7] != null) {
//				SouthRow [7].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//
//			if (SouthWestRow [0] != null) {
//				SouthWestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (SouthWestRow [1] != null) {
//				SouthWestRow [1].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (SouthWestRow [2] != null) {
//				SouthWestRow [2].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (SouthWestRow [3] != null) {
//				SouthWestRow [3].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (SouthWestRow [4] != null) {
//				SouthWestRow [4].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (SouthWestRow [5] != null) {
//				SouthWestRow [5].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (SouthWestRow [6] != null) {
//				SouthWestRow [6].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (SouthWestRow [7] != null) {
//				SouthWestRow [7].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//
//			if (WestRow [0] != null) {
//				WestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (WestRow [1] != null) {
//				WestRow [1].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (WestRow [2] != null) {
//				WestRow [2].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (WestRow [3] != null) {
//				WestRow [3].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (WestRow [4] != null) {
//				WestRow [4].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (WestRow [5] != null) {
//				WestRow [5].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (WestRow [6] != null) {
//				WestRow [6].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (WestRow [7] != null) {
//				WestRow [7].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//
//			if (NorthWestRow [0] != null) {
//				NorthWestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (NorthWestRow [1] != null) {
//				NorthWestRow [1].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (NorthWestRow [2] != null) {
//				NorthWestRow [2].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (NorthWestRow [3] != null) {
//				NorthWestRow [3].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (NorthWestRow [4] != null) {
//				NorthWestRow [4].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (NorthWestRow [5] != null) {
//				NorthWestRow [5].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (NorthWestRow [6] != null) {
//				NorthWestRow [6].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}
//			if (NorthWestRow [7] != null) {
//				NorthWestRow [7].GetComponent<ChessSpaceScript> ().isAvailable = false;
//			}


			isSelectedBlock = false;
		}

		if (currentPiece == null) {
			occupiedByWhite = false;
			occupiedByBlack = false;
			currentPieceIsPawn = false;
			currentPieceIsBishop = false;
			currentPieceIsKnight = false;
			currentPieceIsRook = false;
			currentPieceIsQueen = false;
			currentPieceIsKing = false;
		}

		if (VulnerableTo.Count > 0) {
			isVulnerable = true;
		}
		if (VulnerableTo.Count == 0) {
			isVulnerable = false;
		}

		if (isSelectedBlock == true) {
			rend.sharedMaterial = isSelectedMat;
		}

		if (isAvailable != true && isSelectedBlock != true && isContested != true) {
			rend.sharedMaterial = defaultMat;
		}
		if (isAvailable == true) {
			rend.sharedMaterial = isAvailableMat;
		}
		if (isContested == true) {
			rend.sharedMaterial = isContestedMat;
		}

		if (isSelectedBlock == true) {
			if (currentPieceIsPawn == true && occupiedByWhite == true) {

				if (pawnNorth1 != null && pawnNorth1.GetComponent<ChessSpaceScript> ().currentPiece == null) {
					pawnNorth1.GetComponent<ChessSpaceScript> ().isAvailable = true;
					//pawnNorth1.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

					if (pawnNorth2 != null && pawnNorth2.GetComponent<ChessSpaceScript> ().currentPiece == null && currentPiece.GetComponent<ChessPieceScript>().firstMove == true) {
						pawnNorth2.GetComponent<ChessSpaceScript> ().isAvailable = true;
						//pawnNorth2.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

					}
				}
				if (pawnNE != null && pawnNE.GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					pawnNE.GetComponent<ChessSpaceScript> ().isContested = true;
                    
				}
				if (pawnNW != null && pawnNW.GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					pawnNW.GetComponent<ChessSpaceScript> ().isContested = true;

				}

			}
			if (currentPieceIsPawn == true && occupiedByBlack == true) {

				if (pawnSouth1 != null && pawnSouth1.GetComponent<ChessSpaceScript> ().currentPiece == null) {
					pawnSouth1.GetComponent<ChessSpaceScript> ().isAvailable = true;
					//pawnSouth1.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					if (pawnSouth2 != null && pawnSouth2.GetComponent<ChessSpaceScript> ().currentPiece == null && currentPiece.GetComponent<ChessPieceScript>().firstMove == true) {
						pawnSouth2.GetComponent<ChessSpaceScript> ().isAvailable = true;
						//pawnSouth2.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

					}
				}
				if (pawnSE != null && pawnSE.GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					pawnSE.GetComponent<ChessSpaceScript> ().isContested = true;


				}
				if (pawnSW != null && pawnSW.GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					pawnSW.GetComponent<ChessSpaceScript> ().isContested = true;

				}

			}

			if (currentPieceIsKnight == true && occupiedByWhite == true) {
				if (knightSpaceNE != null && knightSpaceNE.GetComponent<ChessSpaceScript> ().currentPiece == null) {
					knightSpaceNE.GetComponent<ChessSpaceScript> ().isAvailable = true;
				}
				if (knightSpaceNW != null && knightSpaceNW.GetComponent<ChessSpaceScript> ().currentPiece == null) {
					knightSpaceNW.GetComponent<ChessSpaceScript> ().isAvailable = true;
				}
				if (knightSpaceSW != null && knightSpaceSW.GetComponent<ChessSpaceScript> ().currentPiece == null) {
					knightSpaceSW.GetComponent<ChessSpaceScript> ().isAvailable = true;
				}
				if (knightSpaceSE != null && knightSpaceSE.GetComponent<ChessSpaceScript> ().currentPiece == null) {
					knightSpaceSE.GetComponent<ChessSpaceScript> ().isAvailable = true;
				}
				if (knightSpaceEN != null && knightSpaceEN.GetComponent<ChessSpaceScript> ().currentPiece == null) {
					knightSpaceEN.GetComponent<ChessSpaceScript> ().isAvailable = true;
				}
				if (knightSpaceES != null && knightSpaceES.GetComponent<ChessSpaceScript> ().currentPiece == null) {
					knightSpaceES.GetComponent<ChessSpaceScript> ().isAvailable = true;
				}
				if (knightSpaceWN != null && knightSpaceWN.GetComponent<ChessSpaceScript> ().currentPiece == null) {
					knightSpaceWN.GetComponent<ChessSpaceScript> ().isAvailable = true;
				}
				if (knightSpaceWS != null && knightSpaceWS.GetComponent<ChessSpaceScript> ().currentPiece == null) {
					knightSpaceWS.GetComponent<ChessSpaceScript> ().isAvailable = true;
				}



				if (knightSpaceNE != null && knightSpaceNE.GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					knightSpaceNE.GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (knightSpaceNW != null && knightSpaceNW.GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					knightSpaceNW.GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (knightSpaceSW != null && knightSpaceSW.GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					knightSpaceSW.GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (knightSpaceSE != null && knightSpaceSE.GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					knightSpaceSE.GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (knightSpaceEN != null && knightSpaceEN.GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					knightSpaceEN.GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (knightSpaceES != null && knightSpaceES.GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					knightSpaceES.GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (knightSpaceWN != null && knightSpaceWN.GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					knightSpaceWN.GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (knightSpaceWS != null && knightSpaceWS.GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					knightSpaceWS.GetComponent<ChessSpaceScript> ().isContested = true;
				}
			}

			if (currentPieceIsKnight == true && occupiedByBlack == true) {
				if (knightSpaceNE != null && knightSpaceNE.GetComponent<ChessSpaceScript> ().currentPiece == null) {
					knightSpaceNE.GetComponent<ChessSpaceScript> ().isAvailable = true;
				}
				if (knightSpaceNW != null && knightSpaceNW.GetComponent<ChessSpaceScript> ().currentPiece == null) {
					knightSpaceNW.GetComponent<ChessSpaceScript> ().isAvailable = true;
				}
				if (knightSpaceSW != null && knightSpaceSW.GetComponent<ChessSpaceScript> ().currentPiece == null) {
					knightSpaceSW.GetComponent<ChessSpaceScript> ().isAvailable = true;
				}
				if (knightSpaceSE != null && knightSpaceSE.GetComponent<ChessSpaceScript> ().currentPiece == null) {
					knightSpaceSE.GetComponent<ChessSpaceScript> ().isAvailable = true;
				}
				if (knightSpaceEN != null && knightSpaceEN.GetComponent<ChessSpaceScript> ().currentPiece == null) {
					knightSpaceEN.GetComponent<ChessSpaceScript> ().isAvailable = true;
				}
				if (knightSpaceES != null && knightSpaceES.GetComponent<ChessSpaceScript> ().currentPiece == null) {
					knightSpaceES.GetComponent<ChessSpaceScript> ().isAvailable = true;
				}
				if (knightSpaceWN != null && knightSpaceWN.GetComponent<ChessSpaceScript> ().currentPiece == null) {
					knightSpaceWN.GetComponent<ChessSpaceScript> ().isAvailable = true;
				}
				if (knightSpaceWS != null && knightSpaceWS.GetComponent<ChessSpaceScript> ().currentPiece == null) {
					knightSpaceWS.GetComponent<ChessSpaceScript> ().isAvailable = true;
				}



				if (knightSpaceNE != null && knightSpaceNE.GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					knightSpaceNE.GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (knightSpaceNW != null && knightSpaceNW.GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					knightSpaceNW.GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (knightSpaceSW != null && knightSpaceSW.GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					knightSpaceSW.GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (knightSpaceSE != null && knightSpaceSE.GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					knightSpaceSE.GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (knightSpaceEN != null && knightSpaceEN.GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					knightSpaceEN.GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (knightSpaceES != null && knightSpaceES.GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					knightSpaceES.GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (knightSpaceWN != null && knightSpaceWN.GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					knightSpaceWN.GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (knightSpaceWS != null && knightSpaceWS.GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					knightSpaceWS.GetComponent<ChessSpaceScript> ().isContested = true;
				}
			}

			if (currentPieceIsBishop == true && occupiedByWhite == true) {
				if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					NorthEastRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					NorthEastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (NorthEastRow [1] != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						NorthEastRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (NorthEastRow [1] != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						NorthEastRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (NorthEastRow [2] != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							NorthEastRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (NorthEastRow [2] != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							NorthEastRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (NorthEastRow [3] != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								NorthEastRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (NorthEastRow [3] != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								NorthEastRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (NorthEastRow [4] != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									NorthEastRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (NorthEastRow [4] != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									NorthEastRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (NorthEastRow [5] != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										NorthEastRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (NorthEastRow [5] != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										NorthEastRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (NorthEastRow [6] != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											NorthEastRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (NorthEastRow [6] != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											NorthEastRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (NorthEastRow [7] != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
												NorthEastRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (NorthEastRow [7] != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												NorthEastRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					NorthWestRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					NorthWestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (NorthWestRow [1] != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						NorthWestRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (NorthWestRow [1] != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						NorthWestRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (NorthWestRow [2] != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							NorthWestRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (NorthWestRow [2] != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							NorthWestRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (NorthWestRow [3] != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								NorthWestRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (NorthWestRow [3] != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								NorthWestRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (NorthWestRow [4] != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									NorthWestRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (NorthWestRow [4] != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									NorthWestRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (NorthWestRow [5] != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										NorthWestRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (NorthWestRow [5] != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										NorthWestRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (NorthWestRow [6] != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											NorthWestRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (NorthWestRow [6] != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											NorthWestRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (NorthWestRow [7] != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
												NorthWestRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (NorthWestRow [7] != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												NorthWestRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					SouthWestRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					SouthWestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (SouthWestRow [1] != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						SouthWestRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (SouthWestRow [1] != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						SouthWestRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (SouthWestRow [2] != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							SouthWestRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (SouthWestRow [2] != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							SouthWestRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (SouthWestRow [3] != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								SouthWestRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (SouthWestRow [3] != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								SouthWestRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (SouthWestRow [4] != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									SouthWestRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (SouthWestRow [4] != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									SouthWestRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (SouthWestRow [5] != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										SouthWestRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (SouthWestRow [5] != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										SouthWestRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (SouthWestRow [6] != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											SouthWestRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (SouthWestRow [6] != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											SouthWestRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (SouthWestRow [7] != null && SouthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
												SouthWestRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (SouthWestRow [7] != null && SouthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												SouthWestRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					SouthEastRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					SouthEastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (SouthEastRow [1] != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						SouthEastRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (SouthEastRow [1] != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						SouthEastRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (SouthEastRow [2] != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							SouthEastRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (SouthEastRow [2] != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							SouthEastRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (SouthEastRow [3] != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								SouthEastRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (SouthEastRow [3] != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								SouthEastRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (SouthEastRow [4] != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									SouthEastRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (SouthEastRow [4] != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									SouthEastRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (SouthEastRow [5] != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										SouthEastRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (SouthEastRow [5] != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										SouthEastRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (SouthEastRow [6] != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											SouthEastRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (SouthEastRow [6] != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											SouthEastRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (SouthEastRow [7] != null && SouthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
												SouthEastRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (SouthEastRow [7] != null && SouthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												SouthEastRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

			}
			if (currentPieceIsBishop == true && occupiedByBlack == true) {
				if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					NorthEastRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					NorthEastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (NorthEastRow [1] != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						NorthEastRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (NorthEastRow [1] != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						NorthEastRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (NorthEastRow [2] != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							NorthEastRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (NorthEastRow [2] != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							NorthEastRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (NorthEastRow [3] != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								NorthEastRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (NorthEastRow [3] != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								NorthEastRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (NorthEastRow [4] != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									NorthEastRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (NorthEastRow [4] != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									NorthEastRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (NorthEastRow [5] != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										NorthEastRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (NorthEastRow [5] != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										NorthEastRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (NorthEastRow [6] != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											NorthEastRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (NorthEastRow [6] != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											NorthEastRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (NorthEastRow [7] != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
												NorthEastRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (NorthEastRow [7] != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												NorthEastRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					NorthWestRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					NorthWestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (NorthWestRow [1] != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						NorthWestRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (NorthWestRow [1] != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						NorthWestRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (NorthWestRow [2] != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							NorthWestRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (NorthWestRow [2] != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							NorthWestRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (NorthWestRow [3] != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								NorthWestRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (NorthWestRow [3] != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								NorthWestRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (NorthWestRow [4] != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									NorthWestRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (NorthWestRow [4] != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									NorthWestRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (NorthWestRow [5] != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										NorthWestRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (NorthWestRow [5] != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										NorthWestRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (NorthWestRow [6] != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											NorthWestRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (NorthWestRow [6] != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											NorthWestRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (NorthWestRow [7] != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
												NorthWestRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (NorthWestRow [7] != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												NorthWestRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					SouthWestRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					SouthWestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (SouthWestRow [1] != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						SouthWestRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (SouthWestRow [1] != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						SouthWestRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (SouthWestRow [2] != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							SouthWestRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (SouthWestRow [2] != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							SouthWestRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (SouthWestRow [3] != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								SouthWestRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (SouthWestRow [3] != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								SouthWestRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (SouthWestRow [4] != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									SouthWestRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (SouthWestRow [4] != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									SouthWestRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (SouthWestRow [5] != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										SouthWestRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (SouthWestRow [5] != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										SouthWestRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (SouthWestRow [6] != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											SouthWestRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (SouthWestRow [6] != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											SouthWestRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (SouthWestRow [7] != null && SouthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
												SouthWestRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (SouthWestRow [7] != null && SouthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												SouthWestRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					SouthEastRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					SouthEastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (SouthEastRow [1] != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						SouthEastRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (SouthEastRow [1] != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						SouthEastRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (SouthEastRow [2] != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							SouthEastRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (SouthEastRow [2] != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							SouthEastRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (SouthEastRow [3] != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								SouthEastRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (SouthEastRow [3] != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								SouthEastRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (SouthEastRow [4] != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									SouthEastRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (SouthEastRow [4] != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									SouthEastRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (SouthEastRow [5] != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										SouthEastRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (SouthEastRow [5] != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										SouthEastRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (SouthEastRow [6] != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											SouthEastRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (SouthEastRow [6] != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											SouthEastRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (SouthEastRow [7] != null && SouthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
												SouthEastRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (SouthEastRow [7] != null && SouthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												SouthEastRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

			}

			if (currentPieceIsRook == true && occupiedByWhite) {
				if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					NorthRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					NorthRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (NorthRow [1] != null && NorthRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						NorthRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (NorthRow [1] != null && NorthRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						NorthRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (NorthRow [2] != null && NorthRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							NorthRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (NorthRow [2] != null && NorthRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							NorthRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (NorthRow [3] != null && NorthRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								NorthRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (NorthRow [3] != null && NorthRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								NorthRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (NorthRow [4] != null && NorthRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									NorthRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (NorthRow [4] != null && NorthRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									NorthRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (NorthRow [5] != null && NorthRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										NorthRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (NorthRow [5] != null && NorthRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										NorthRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (NorthRow [6] != null && NorthRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											NorthRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (NorthRow [6] != null && NorthRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											NorthRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (NorthRow [7] != null && NorthRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
												NorthRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (NorthRow [7] != null && NorthRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												NorthRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					EastRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					EastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (EastRow [1] != null && EastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						EastRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (EastRow [1] != null && EastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						EastRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (EastRow [2] != null && EastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							EastRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (EastRow [2] != null && EastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							EastRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (EastRow [3] != null && EastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								EastRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (EastRow [3] != null && EastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								EastRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (EastRow [4] != null && EastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									EastRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (EastRow [4] != null && EastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									EastRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (EastRow [5] != null && EastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										EastRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (EastRow [5] != null && EastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										EastRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (EastRow [6] != null && EastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											EastRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (EastRow [6] != null && EastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											EastRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (EastRow [7] != null && EastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
												EastRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (EastRow [7] != null && EastRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												EastRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}
                
				if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					SouthRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					SouthRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (SouthRow [1] != null && SouthRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						SouthRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (SouthRow [1] != null && SouthRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						SouthRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (SouthRow [2] != null && SouthRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							SouthRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (SouthRow [2] != null && SouthRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							SouthRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (SouthRow [3] != null && SouthRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								SouthRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (SouthRow [3] != null && SouthRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								SouthRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (SouthRow [4] != null && SouthRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									SouthRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (SouthRow [4] != null && SouthRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									SouthRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (SouthRow [5] != null && SouthRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										SouthRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (SouthRow [5] != null && SouthRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										SouthRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (SouthRow [6] != null && SouthRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											SouthRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (SouthRow [6] != null && SouthRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											SouthRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (SouthRow [7] != null && SouthRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
												SouthRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (SouthRow [7] != null && SouthRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												SouthRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					WestRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					WestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (WestRow [1] != null && WestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						WestRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (WestRow [1] != null && WestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						WestRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (WestRow [2] != null && WestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							WestRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (WestRow [2] != null && WestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							WestRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (WestRow [3] != null && WestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								WestRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (WestRow [3] != null && WestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								WestRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (WestRow [4] != null && WestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									WestRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (WestRow [4] != null && WestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									WestRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (WestRow [5] != null && WestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										WestRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (WestRow [5] != null && WestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										WestRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (WestRow [6] != null && WestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											WestRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (WestRow [6] != null && WestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											WestRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (WestRow [7] != null && WestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
												WestRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (WestRow [7] != null && WestRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												WestRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

			}

			if (currentPieceIsRook == true && occupiedByBlack) {
				if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					NorthRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					NorthRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (NorthRow [1] != null && NorthRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						NorthRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (NorthRow [1] != null && NorthRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						NorthRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (NorthRow [2] != null && NorthRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							NorthRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (NorthRow [2] != null && NorthRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							NorthRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (NorthRow [3] != null && NorthRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								NorthRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (NorthRow [3] != null && NorthRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								NorthRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (NorthRow [4] != null && NorthRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									NorthRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (NorthRow [4] != null && NorthRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									NorthRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (NorthRow [5] != null && NorthRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										NorthRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (NorthRow [5] != null && NorthRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										NorthRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (NorthRow [6] != null && NorthRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											NorthRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (NorthRow [6] != null && NorthRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											NorthRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (NorthRow [7] != null && NorthRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
												NorthRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (NorthRow [7] != null && NorthRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												NorthRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					EastRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					EastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (EastRow [1] != null && EastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						EastRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (EastRow [1] != null && EastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						EastRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (EastRow [2] != null && EastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							EastRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (EastRow [2] != null && EastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							EastRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (EastRow [3] != null && EastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								EastRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (EastRow [3] != null && EastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								EastRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (EastRow [4] != null && EastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									EastRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (EastRow [4] != null && EastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									EastRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (EastRow [5] != null && EastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										EastRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (EastRow [5] != null && EastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										EastRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (EastRow [6] != null && EastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											EastRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (EastRow [6] != null && EastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											EastRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (EastRow [7] != null && EastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
												EastRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (EastRow [7] != null && EastRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												EastRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					SouthRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					SouthRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (SouthRow [1] != null && SouthRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						SouthRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (SouthRow [1] != null && SouthRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						SouthRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (SouthRow [2] != null && SouthRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							SouthRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (SouthRow [2] != null && SouthRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							SouthRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (SouthRow [3] != null && SouthRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								SouthRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (SouthRow [3] != null && SouthRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								SouthRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (SouthRow [4] != null && SouthRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									SouthRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (SouthRow [4] != null && SouthRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									SouthRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (SouthRow [5] != null && SouthRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										SouthRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (SouthRow [5] != null && SouthRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										SouthRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (SouthRow [6] != null && SouthRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											SouthRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (SouthRow [6] != null && SouthRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											SouthRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (SouthRow [7] != null && SouthRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
												SouthRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (SouthRow [7] != null && SouthRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												SouthRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					WestRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					WestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (WestRow [1] != null && WestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						WestRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (WestRow [1] != null && WestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						WestRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (WestRow [2] != null && WestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							WestRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (WestRow [2] != null && WestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							WestRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (WestRow [3] != null && WestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								WestRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (WestRow [3] != null && WestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								WestRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (WestRow [4] != null && WestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									WestRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (WestRow [4] != null && WestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									WestRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (WestRow [5] != null && WestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										WestRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (WestRow [5] != null && WestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										WestRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (WestRow [6] != null && WestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											WestRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (WestRow [6] != null && WestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											WestRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (WestRow [7] != null && WestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
												WestRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (WestRow [7] != null && WestRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												WestRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

			}

			if (currentPieceIsQueen == true && occupiedByWhite) {
				if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					NorthEastRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					NorthEastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (NorthEastRow [1] != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						NorthEastRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (NorthEastRow [1] != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						NorthEastRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (NorthEastRow [2] != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							NorthEastRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (NorthEastRow [2] != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							NorthEastRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (NorthEastRow [3] != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								NorthEastRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (NorthEastRow [3] != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								NorthEastRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (NorthEastRow [4] != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									NorthEastRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (NorthEastRow [4] != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									NorthEastRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (NorthEastRow [5] != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										NorthEastRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (NorthEastRow [5] != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										NorthEastRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (NorthEastRow [6] != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											NorthEastRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (NorthEastRow [6] != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											NorthEastRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (NorthEastRow [7] != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
												NorthEastRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (NorthEastRow [7] != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												NorthEastRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					NorthWestRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					NorthWestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (NorthWestRow [1] != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						NorthWestRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (NorthWestRow [1] != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						NorthWestRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (NorthWestRow [2] != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							NorthWestRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (NorthWestRow [2] != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							NorthWestRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (NorthWestRow [3] != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								NorthWestRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (NorthWestRow [3] != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								NorthWestRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (NorthWestRow [4] != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									NorthWestRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (NorthWestRow [4] != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									NorthWestRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (NorthWestRow [5] != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										NorthWestRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (NorthWestRow [5] != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										NorthWestRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (NorthWestRow [6] != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											NorthWestRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (NorthWestRow [6] != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											NorthWestRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (NorthWestRow [7] != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
												NorthWestRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (NorthWestRow [7] != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												NorthWestRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					SouthWestRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					SouthWestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (SouthWestRow [1] != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						SouthWestRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (SouthWestRow [1] != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						SouthWestRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (SouthWestRow [2] != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							SouthWestRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (SouthWestRow [2] != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							SouthWestRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (SouthWestRow [3] != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								SouthWestRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (SouthWestRow [3] != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								SouthWestRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (SouthWestRow [4] != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									SouthWestRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (SouthWestRow [4] != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									SouthWestRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (SouthWestRow [5] != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										SouthWestRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (SouthWestRow [5] != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										SouthWestRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (SouthWestRow [6] != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											SouthWestRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (SouthWestRow [6] != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											SouthWestRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (SouthWestRow [7] != null && SouthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
												SouthWestRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (SouthWestRow [7] != null && SouthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												SouthWestRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					SouthEastRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					SouthEastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (SouthEastRow [1] != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						SouthEastRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (SouthEastRow [1] != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						SouthEastRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (SouthEastRow [2] != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							SouthEastRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (SouthEastRow [2] != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							SouthEastRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (SouthEastRow [3] != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								SouthEastRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (SouthEastRow [3] != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								SouthEastRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (SouthEastRow [4] != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									SouthEastRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (SouthEastRow [4] != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									SouthEastRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (SouthEastRow [5] != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										SouthEastRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (SouthEastRow [5] != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										SouthEastRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (SouthEastRow [6] != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											SouthEastRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (SouthEastRow [6] != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											SouthEastRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (SouthEastRow [7] != null && SouthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
												SouthEastRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (SouthEastRow [7] != null && SouthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												SouthEastRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					NorthRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					NorthRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (NorthRow [1] != null && NorthRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						NorthRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (NorthRow [1] != null && NorthRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						NorthRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (NorthRow [2] != null && NorthRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							NorthRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (NorthRow [2] != null && NorthRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							NorthRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (NorthRow [3] != null && NorthRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								NorthRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (NorthRow [3] != null && NorthRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								NorthRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (NorthRow [4] != null && NorthRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									NorthRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (NorthRow [4] != null && NorthRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									NorthRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (NorthRow [5] != null && NorthRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										NorthRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (NorthRow [5] != null && NorthRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										NorthRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (NorthRow [6] != null && NorthRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											NorthRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (NorthRow [6] != null && NorthRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											NorthRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (NorthRow [7] != null && NorthRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
												NorthRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (NorthRow [7] != null && NorthRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												NorthRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					EastRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					EastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (EastRow [1] != null && EastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						EastRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (EastRow [1] != null && EastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						EastRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (EastRow [2] != null && EastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							EastRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (EastRow [2] != null && EastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							EastRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (EastRow [3] != null && EastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								EastRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (EastRow [3] != null && EastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								EastRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (EastRow [4] != null && EastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									EastRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (EastRow [4] != null && EastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									EastRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (EastRow [5] != null && EastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										EastRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (EastRow [5] != null && EastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										EastRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (EastRow [6] != null && EastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											EastRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (EastRow [6] != null && EastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											EastRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (EastRow [7] != null && EastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
												EastRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (EastRow [7] != null && EastRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												EastRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					SouthRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					SouthRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (SouthRow [1] != null && SouthRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						SouthRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (SouthRow [1] != null && SouthRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						SouthRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (SouthRow [2] != null && SouthRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							SouthRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (SouthRow [2] != null && SouthRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							SouthRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (SouthRow [3] != null && SouthRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								SouthRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (SouthRow [3] != null && SouthRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								SouthRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (SouthRow [4] != null && SouthRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									SouthRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (SouthRow [4] != null && SouthRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									SouthRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (SouthRow [5] != null && SouthRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										SouthRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (SouthRow [5] != null && SouthRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										SouthRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (SouthRow [6] != null && SouthRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											SouthRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (SouthRow [6] != null && SouthRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											SouthRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (SouthRow [7] != null && SouthRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
												SouthRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (SouthRow [7] != null && SouthRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												SouthRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					WestRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					WestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (WestRow [1] != null && WestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						WestRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (WestRow [1] != null && WestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						WestRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (WestRow [2] != null && WestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							WestRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (WestRow [2] != null && WestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							WestRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (WestRow [3] != null && WestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								WestRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (WestRow [3] != null && WestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								WestRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (WestRow [4] != null && WestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									WestRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (WestRow [4] != null && WestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									WestRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (WestRow [5] != null && WestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										WestRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (WestRow [5] != null && WestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										WestRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (WestRow [6] != null && WestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											WestRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (WestRow [6] != null && WestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											WestRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (WestRow [7] != null && WestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
												WestRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (WestRow [7] != null && WestRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												WestRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}
			}
			if (currentPieceIsQueen == true && occupiedByBlack) {
				if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					NorthEastRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					NorthEastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (NorthEastRow [1] != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						NorthEastRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (NorthEastRow [1] != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						NorthEastRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (NorthEastRow [2] != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							NorthEastRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (NorthEastRow [2] != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							NorthEastRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (NorthEastRow [3] != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								NorthEastRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (NorthEastRow [3] != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								NorthEastRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (NorthEastRow [4] != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									NorthEastRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (NorthEastRow [4] != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									NorthEastRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (NorthEastRow [5] != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										NorthEastRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (NorthEastRow [5] != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										NorthEastRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (NorthEastRow [6] != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											NorthEastRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (NorthEastRow [6] != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											NorthEastRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (NorthEastRow [7] != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
												NorthEastRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (NorthEastRow [7] != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												NorthEastRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					NorthWestRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					NorthWestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (NorthWestRow [1] != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						NorthWestRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (NorthWestRow [1] != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						NorthWestRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (NorthWestRow [2] != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							NorthWestRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (NorthWestRow [2] != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							NorthWestRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (NorthWestRow [3] != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								NorthWestRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (NorthWestRow [3] != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								NorthWestRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (NorthWestRow [4] != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									NorthWestRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (NorthWestRow [4] != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									NorthWestRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (NorthWestRow [5] != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										NorthWestRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (NorthWestRow [5] != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										NorthWestRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (NorthWestRow [6] != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											NorthWestRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (NorthWestRow [6] != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											NorthWestRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (NorthWestRow [7] != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
												NorthWestRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (NorthWestRow [7] != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												NorthWestRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					SouthWestRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					SouthWestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (SouthWestRow [1] != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						SouthWestRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (SouthWestRow [1] != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						SouthWestRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (SouthWestRow [2] != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							SouthWestRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (SouthWestRow [2] != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							SouthWestRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (SouthWestRow [3] != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								SouthWestRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (SouthWestRow [3] != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								SouthWestRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (SouthWestRow [4] != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									SouthWestRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (SouthWestRow [4] != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									SouthWestRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (SouthWestRow [5] != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										SouthWestRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (SouthWestRow [5] != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										SouthWestRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (SouthWestRow [6] != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											SouthWestRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (SouthWestRow [6] != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											SouthWestRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (SouthWestRow [7] != null && SouthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
												SouthWestRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (SouthWestRow [7] != null && SouthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												SouthWestRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					SouthEastRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					SouthEastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (SouthEastRow [1] != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						SouthEastRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (SouthEastRow [1] != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						SouthEastRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (SouthEastRow [2] != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							SouthEastRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (SouthEastRow [2] != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							SouthEastRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (SouthEastRow [3] != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								SouthEastRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (SouthEastRow [3] != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								SouthEastRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (SouthEastRow [4] != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									SouthEastRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (SouthEastRow [4] != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									SouthEastRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (SouthEastRow [5] != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										SouthEastRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (SouthEastRow [5] != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										SouthEastRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (SouthEastRow [6] != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											SouthEastRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (SouthEastRow [6] != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											SouthEastRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (SouthEastRow [7] != null && SouthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
												SouthEastRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (SouthEastRow [7] != null && SouthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												SouthEastRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					NorthRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					NorthRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (NorthRow [1] != null && NorthRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						NorthRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (NorthRow [1] != null && NorthRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						NorthRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (NorthRow [2] != null && NorthRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							NorthRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (NorthRow [2] != null && NorthRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							NorthRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (NorthRow [3] != null && NorthRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								NorthRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (NorthRow [3] != null && NorthRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								NorthRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (NorthRow [4] != null && NorthRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									NorthRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (NorthRow [4] != null && NorthRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									NorthRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (NorthRow [5] != null && NorthRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										NorthRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (NorthRow [5] != null && NorthRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										NorthRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (NorthRow [6] != null && NorthRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											NorthRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (NorthRow [6] != null && NorthRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											NorthRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (NorthRow [7] != null && NorthRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
												NorthRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (NorthRow [7] != null && NorthRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												NorthRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					EastRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					EastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (EastRow [1] != null && EastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						EastRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (EastRow [1] != null && EastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						EastRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (EastRow [2] != null && EastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							EastRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (EastRow [2] != null && EastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							EastRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (EastRow [3] != null && EastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								EastRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (EastRow [3] != null && EastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								EastRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (EastRow [4] != null && EastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									EastRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (EastRow [4] != null && EastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									EastRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (EastRow [5] != null && EastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										EastRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (EastRow [5] != null && EastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										EastRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (EastRow [6] != null && EastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											EastRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (EastRow [6] != null && EastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											EastRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (EastRow [7] != null && EastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
												EastRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (EastRow [7] != null && EastRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												EastRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					SouthRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					SouthRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (SouthRow [1] != null && SouthRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						SouthRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (SouthRow [1] != null && SouthRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						SouthRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (SouthRow [2] != null && SouthRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							SouthRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (SouthRow [2] != null && SouthRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							SouthRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (SouthRow [3] != null && SouthRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								SouthRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (SouthRow [3] != null && SouthRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								SouthRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (SouthRow [4] != null && SouthRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									SouthRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (SouthRow [4] != null && SouthRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									SouthRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (SouthRow [5] != null && SouthRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										SouthRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (SouthRow [5] != null && SouthRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										SouthRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (SouthRow [6] != null && SouthRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											SouthRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (SouthRow [6] != null && SouthRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											SouthRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (SouthRow [7] != null && SouthRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
												SouthRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (SouthRow [7] != null && SouthRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												SouthRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}

				if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					WestRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
				}
				if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					WestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;
					if (WestRow [1] != null && WestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						WestRow [1].GetComponent<ChessSpaceScript> ().isContested = true;
					}
					if (WestRow [1] != null && WestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						WestRow [1].GetComponent<ChessSpaceScript> ().isAvailable = true;
						if (WestRow [2] != null && WestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							WestRow [2].GetComponent<ChessSpaceScript> ().isContested = true;
						}
						if (WestRow [2] != null && WestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							WestRow [2].GetComponent<ChessSpaceScript> ().isAvailable = true;
							if (WestRow [3] != null && WestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								WestRow [3].GetComponent<ChessSpaceScript> ().isContested = true;
							}
							if (WestRow [3] != null && WestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								WestRow [3].GetComponent<ChessSpaceScript> ().isAvailable = true;
								if (WestRow [4] != null && WestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									WestRow [4].GetComponent<ChessSpaceScript> ().isContested = true;
								}
								if (WestRow [4] != null && WestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									WestRow [4].GetComponent<ChessSpaceScript> ().isAvailable = true;
									if (WestRow [5] != null && WestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										WestRow [5].GetComponent<ChessSpaceScript> ().isContested = true;
									}
									if (WestRow [5] != null && WestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										WestRow [5].GetComponent<ChessSpaceScript> ().isAvailable = true;
										if (WestRow [6] != null && WestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											WestRow [6].GetComponent<ChessSpaceScript> ().isContested = true;
										}
										if (WestRow [6] != null && WestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
											WestRow [6].GetComponent<ChessSpaceScript> ().isAvailable = true;
											if (WestRow [7] != null && WestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
												WestRow [7].GetComponent<ChessSpaceScript> ().isContested = true;
											}
											if (WestRow [7] != null && WestRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {
												WestRow [7].GetComponent<ChessSpaceScript> ().isAvailable = true;

											}
										}
									}
								}
							}
						}
					}
				}
			}
			if (currentPieceIsKing == true && occupiedByWhite == true) {

				if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow[0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					NorthRow [0].GetComponent<ChessSpaceScript> ().isContested = true;
                    
				}
				if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					NorthRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;

				}
				if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow[0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					NorthEastRow [0].GetComponent<ChessSpaceScript> ().isContested = true;

				}
				if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					NorthEastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;

				}
				if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow[0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					SouthEastRow [0].GetComponent<ChessSpaceScript> ().isContested = true;

				}
				if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					SouthEastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;

				}
				if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow[0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					SouthRow [0].GetComponent<ChessSpaceScript> ().isContested = true;

				}
				if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					SouthRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;

				}
				if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow[0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					SouthWestRow [0].GetComponent<ChessSpaceScript> ().isContested = true;

				}
				if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					SouthWestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;

				}
				if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow[0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					EastRow [0].GetComponent<ChessSpaceScript> ().isContested = true;

				}
				if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					EastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;

				}
				if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow[0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					WestRow [0].GetComponent<ChessSpaceScript> ().isContested = true;

				}
				if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					WestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;

				}
				if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow[0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					NorthWestRow [0].GetComponent<ChessSpaceScript> ().isContested = true;

				}
				if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					NorthWestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;

				}
//				if (currentPiece.GetComponent<ChessPieceScript> ().firstMove == true && kingRookSwitchEast.GetComponent<ChessSpaceScript> ().currentPieceIsRook == true) {
//					kingRookSwitchEast.GetComponent<ChessSpaceScript> ().isAvailable = true;
//				}
//				if (currentPiece.GetComponent<ChessPieceScript> ().firstMove == true && kingRookSwitchWest.GetComponent<ChessSpaceScript> ().currentPieceIsRook == true) {
//					kingRookSwitchWest.GetComponent<ChessSpaceScript> ().isAvailable = true;
//				}

			}
			if (currentPieceIsKing == true && occupiedByBlack == true) {

				if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow[0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					NorthRow [0].GetComponent<ChessSpaceScript> ().isContested = true;

				}
				if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					NorthRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;

				}
				if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow[0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					NorthEastRow [0].GetComponent<ChessSpaceScript> ().isContested = true;

				}
				if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					NorthEastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;

				}
				if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow[0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					SouthEastRow [0].GetComponent<ChessSpaceScript> ().isContested = true;

				}
				if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					SouthEastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;

				}
				if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow[0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					SouthRow [0].GetComponent<ChessSpaceScript> ().isContested = true;

				}
				if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					SouthRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;

				}
				if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow[0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					SouthWestRow [0].GetComponent<ChessSpaceScript> ().isContested = true;

				}
				if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					SouthWestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;

				}
				if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow[0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					EastRow [0].GetComponent<ChessSpaceScript> ().isContested = true;

				}
				if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					EastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;

				}
				if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow[0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					WestRow [0].GetComponent<ChessSpaceScript> ().isContested = true;

				}
				if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					WestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;

				}
				if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow[0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					NorthWestRow [0].GetComponent<ChessSpaceScript> ().isContested = true;

				}
				if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					NorthWestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = true;

				}
//				if (currentPiece.GetComponent<ChessPieceScript> ().firstMove == true && kingRookSwitchEast.GetComponent<ChessSpaceScript> ().currentPieceIsRook == true) {
//					kingRookSwitchEast.GetComponent<ChessSpaceScript> ().isAvailable = true;
//				}
//				if (currentPiece.GetComponent<ChessPieceScript> ().firstMove == true && kingRookSwitchWest.GetComponent<ChessSpaceScript> ().currentPieceIsRook == true) {
//					kingRookSwitchWest.GetComponent<ChessSpaceScript> ().isAvailable = true;
//				}

			}
		}
		if (currentPieceIsPawn == true && occupiedByWhite == true) {


			if (pawnNE != null && pawnNE.GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				pawnNE.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

			}
			if (pawnNW != null && pawnNW.GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				pawnNW.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

			}

		}
		if (currentPieceIsPawn == true && occupiedByBlack == true) {

			
			
			if (pawnSE != null && pawnSE.GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				pawnSE.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

			}
			if (pawnSW != null && pawnSW.GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				pawnSW.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

			}

		}

		if (currentPieceIsKnight == true && occupiedByWhite == true) {
			



			if (knightSpaceNE != null && knightSpaceNE.GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				knightSpaceNE.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (knightSpaceNW != null && knightSpaceNW.GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				knightSpaceNW.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (knightSpaceSW != null && knightSpaceSW.GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				knightSpaceSW.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (knightSpaceSE != null && knightSpaceSE.GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				knightSpaceSE.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (knightSpaceEN != null && knightSpaceEN.GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				knightSpaceEN.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (knightSpaceES != null && knightSpaceES.GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				knightSpaceES.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (knightSpaceWN != null && knightSpaceWN.GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				knightSpaceWN.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (knightSpaceWS != null && knightSpaceWS.GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				knightSpaceWS.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
		}


		if (currentPieceIsKnight == true && occupiedByBlack == true) {


			if (knightSpaceNE != null && knightSpaceNE.GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
			knightSpaceNE.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (knightSpaceNW != null && knightSpaceNW.GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
			knightSpaceNW.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (knightSpaceSW != null && knightSpaceSW.GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
			knightSpaceSW.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (knightSpaceSE != null && knightSpaceSE.GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
			knightSpaceSE.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (knightSpaceEN != null && knightSpaceEN.GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
			knightSpaceEN.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (knightSpaceES != null && knightSpaceES.GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
			knightSpaceES.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (knightSpaceWN != null && knightSpaceWN.GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
			knightSpaceWN.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (knightSpaceWS != null && knightSpaceWS.GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
			knightSpaceWS.GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
		}

		if (currentPieceIsBishop == true && occupiedByWhite == true) {
			if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
			NorthEastRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (NorthEastRow [1] != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				NorthEastRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}

				if (NorthEastRow [1] != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (NorthEastRow [2] != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					NorthEastRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (NorthEastRow [2] != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (NorthEastRow [3] != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						NorthEastRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (NorthEastRow [3] != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (NorthEastRow [4] != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							NorthEastRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (NorthEastRow [4] != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (NorthEastRow [5] != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								NorthEastRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (NorthEastRow [5] != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (NorthEastRow [6] != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									NorthEastRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (NorthEastRow [6] != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (NorthEastRow [7] != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										NorthEastRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}

			if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
			NorthWestRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (NorthWestRow [1] != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				NorthWestRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (NorthWestRow [1] != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (NorthWestRow [2] != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					NorthWestRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (NorthWestRow [2] != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (NorthWestRow [3] != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						NorthWestRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (NorthWestRow [3] != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (NorthWestRow [4] != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							NorthWestRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (NorthWestRow [4] != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (NorthWestRow [5] != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								NorthWestRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (NorthWestRow [5] != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (NorthWestRow [6] != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									NorthWestRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (NorthWestRow [6] != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (NorthWestRow [7] != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										NorthWestRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}

			if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
			SouthWestRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (SouthWestRow [1] != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				SouthWestRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (SouthWestRow [1] != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (SouthWestRow [2] != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					SouthWestRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (SouthWestRow [2] != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (SouthWestRow [3] != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						SouthWestRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (SouthWestRow [3] != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (SouthWestRow [4] != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							SouthWestRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (SouthWestRow [4] != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (SouthWestRow [5] != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								SouthWestRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (SouthWestRow [5] != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (SouthWestRow [6] != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									SouthWestRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (SouthWestRow [6] != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (SouthWestRow [7] != null && SouthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										SouthWestRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}

			if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
			SouthEastRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (SouthEastRow [1] != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				SouthEastRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (SouthEastRow [1] != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (SouthEastRow [2] != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					SouthEastRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (SouthEastRow [2] != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (SouthEastRow [3] != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						SouthEastRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (SouthEastRow [3] != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (SouthEastRow [4] != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							SouthEastRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (SouthEastRow [4] != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (SouthEastRow [5] != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								SouthEastRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (SouthEastRow [5] != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (SouthEastRow [6] != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									SouthEastRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (SouthEastRow [6] != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (SouthEastRow [7] != null && SouthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										SouthEastRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}

		}
		if (currentPieceIsBishop == true && occupiedByBlack == true) {
			if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
			NorthEastRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (NorthEastRow [1] != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				NorthEastRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (NorthEastRow [1] != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (NorthEastRow [2] != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					NorthEastRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (NorthEastRow [2] != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (NorthEastRow [3] != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						NorthEastRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (NorthEastRow [3] != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (NorthEastRow [4] != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							NorthEastRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (NorthEastRow [4] != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (NorthEastRow [5] != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								NorthEastRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (NorthEastRow [5] != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (NorthEastRow [6] != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									NorthEastRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (NorthEastRow [6] != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (NorthEastRow [7] != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										NorthEastRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}

			if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
			NorthWestRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (NorthWestRow [1] != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				NorthWestRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (NorthWestRow [1] != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (NorthWestRow [2] != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					NorthWestRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (NorthWestRow [2] != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (NorthWestRow [3] != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						NorthWestRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (NorthWestRow [3] != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (NorthWestRow [4] != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							NorthWestRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (NorthWestRow [4] != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (NorthWestRow [5] != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								NorthWestRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (NorthWestRow [5] != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (NorthWestRow [6] != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									NorthWestRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (NorthWestRow [6] != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (NorthWestRow [7] != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										NorthWestRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}

			if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
			SouthWestRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (SouthWestRow [1] != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				SouthWestRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (SouthWestRow [1] != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (SouthWestRow [2] != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					SouthWestRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (SouthWestRow [2] != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (SouthWestRow [3] != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						SouthWestRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (SouthWestRow [3] != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (SouthWestRow [4] != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							SouthWestRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (SouthWestRow [4] != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (SouthWestRow [5] != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								SouthWestRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (SouthWestRow [5] != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (SouthWestRow [6] != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									SouthWestRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (SouthWestRow [6] != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (SouthWestRow [7] != null && SouthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										SouthWestRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}

			if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
			SouthEastRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (SouthEastRow [1] != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				SouthEastRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (SouthEastRow [1] != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (SouthEastRow [2] != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					SouthEastRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (SouthEastRow [2] != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (SouthEastRow [3] != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						SouthEastRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (SouthEastRow [3] != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (SouthEastRow [4] != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							SouthEastRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (SouthEastRow [4] != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (SouthEastRow [5] != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								SouthEastRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (SouthEastRow [5] != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (SouthEastRow [6] != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									SouthEastRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (SouthEastRow [6] != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (SouthEastRow [7] != null && SouthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										SouthEastRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}

		}

		if (currentPieceIsRook == true && occupiedByWhite) {
			if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
			NorthRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (NorthRow [1] != null && NorthRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				NorthRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (NorthRow [1] != null && NorthRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (NorthRow [2] != null && NorthRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					NorthRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (NorthRow [2] != null && NorthRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (NorthRow [3] != null && NorthRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						NorthRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (NorthRow [3] != null && NorthRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (NorthRow [4] != null && NorthRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							NorthRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (NorthRow [4] != null && NorthRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (NorthRow [5] != null && NorthRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								NorthRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (NorthRow [5] != null && NorthRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (NorthRow [6] != null && NorthRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									NorthRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (NorthRow [6] != null && NorthRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (NorthRow [7] != null && NorthRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										NorthRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}

			if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
			EastRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (EastRow [1] != null && EastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				EastRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (EastRow [1] != null && EastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (EastRow [2] != null && EastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					EastRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (EastRow [2] != null && EastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (EastRow [3] != null && EastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						EastRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (EastRow [3] != null && EastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (EastRow [4] != null && EastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							EastRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (EastRow [4] != null && EastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (EastRow [5] != null && EastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								EastRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (EastRow [5] != null && EastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (EastRow [6] != null && EastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									EastRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (EastRow [6] != null && EastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (EastRow [7] != null && EastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										EastRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}

			if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
			SouthRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (SouthRow [1] != null && SouthRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				SouthRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (SouthRow [1] != null && SouthRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (SouthRow [2] != null && SouthRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					SouthRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (SouthRow [2] != null && SouthRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (SouthRow [3] != null && SouthRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						SouthRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (SouthRow [3] != null && SouthRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (SouthRow [4] != null && SouthRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							SouthRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (SouthRow [4] != null && SouthRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (SouthRow [5] != null && SouthRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								SouthRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (SouthRow [5] != null && SouthRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (SouthRow [6] != null && SouthRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									SouthRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (SouthRow [6] != null && SouthRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (SouthRow [7] != null && SouthRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										SouthRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}

			if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
			WestRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (WestRow [1] != null && WestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				WestRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (WestRow [1] != null && WestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (WestRow [2] != null && WestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					WestRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (WestRow [2] != null && WestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (WestRow [3] != null && WestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						WestRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (WestRow [3] != null && WestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (WestRow [4] != null && WestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							WestRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (WestRow [4] != null && WestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (WestRow [5] != null && WestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								WestRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (WestRow [5] != null && WestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (WestRow [6] != null && WestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									WestRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (WestRow [6] != null && WestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (WestRow [7] != null && WestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										WestRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}

		}

		if (currentPieceIsRook == true && occupiedByBlack) {
			if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
			NorthRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (NorthRow [1] != null && NorthRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				NorthRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (NorthRow [1] != null && NorthRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (NorthRow [2] != null && NorthRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					NorthRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (NorthRow [2] != null && NorthRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (NorthRow [3] != null && NorthRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						NorthRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (NorthRow [3] != null && NorthRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (NorthRow [4] != null && NorthRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							NorthRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (NorthRow [4] != null && NorthRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (NorthRow [5] != null && NorthRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								NorthRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (NorthRow [5] != null && NorthRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (NorthRow [6] != null && NorthRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									NorthRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (NorthRow [6] != null && NorthRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (NorthRow [7] != null && NorthRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										NorthRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}

			if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
			EastRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (EastRow [1] != null && EastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				EastRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (EastRow [1] != null && EastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (EastRow [2] != null && EastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					EastRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (EastRow [2] != null && EastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (EastRow [3] != null && EastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						EastRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (EastRow [3] != null && EastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (EastRow [4] != null && EastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							EastRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (EastRow [4] != null && EastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (EastRow [5] != null && EastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								EastRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (EastRow [5] != null && EastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (EastRow [6] != null && EastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									EastRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (EastRow [6] != null && EastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (EastRow [7] != null && EastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										EastRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}

			if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
			SouthRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (SouthRow [1] != null && SouthRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				SouthRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (SouthRow [1] != null && SouthRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (SouthRow [2] != null && SouthRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					SouthRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (SouthRow [2] != null && SouthRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (SouthRow [3] != null && SouthRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						SouthRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (SouthRow [3] != null && SouthRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (SouthRow [4] != null && SouthRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							SouthRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (SouthRow [4] != null && SouthRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (SouthRow [5] != null && SouthRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								SouthRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (SouthRow [5] != null && SouthRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (SouthRow [6] != null && SouthRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									SouthRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (SouthRow [6] != null && SouthRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (SouthRow [7] != null && SouthRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										SouthRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}

			if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
			WestRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (WestRow [1] != null && WestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				WestRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (WestRow [1] != null && WestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (WestRow [2] != null && WestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					WestRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (WestRow [2] != null && WestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (WestRow [3] != null && WestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						WestRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (WestRow [3] != null && WestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (WestRow [4] != null && WestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							WestRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (WestRow [4] != null && WestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (WestRow [5] != null && WestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								WestRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (WestRow [5] != null && WestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (WestRow [6] != null && WestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									WestRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (WestRow [6] != null && WestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (WestRow [7] != null && WestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										WestRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}

		}

		if (currentPieceIsQueen == true && occupiedByWhite) {
			if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				NorthEastRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (NorthEastRow [1] != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					NorthEastRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (NorthEastRow [1] != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (NorthEastRow [2] != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						NorthEastRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (NorthEastRow [2] != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (NorthEastRow [3] != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							NorthEastRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (NorthEastRow [3] != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (NorthEastRow [4] != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								NorthEastRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (NorthEastRow [4] != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (NorthEastRow [5] != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									NorthEastRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (NorthEastRow [5] != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (NorthEastRow [6] != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										NorthEastRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (NorthEastRow [6] != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (NorthEastRow [7] != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											NorthEastRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										if (NorthEastRow [7] != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {

										}
									}
								}
							}
						}
					}
				}
			}

			if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				NorthWestRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (NorthWestRow [1] != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					NorthWestRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (NorthWestRow [1] != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (NorthWestRow [2] != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						NorthWestRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (NorthWestRow [2] != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (NorthWestRow [3] != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							NorthWestRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (NorthWestRow [3] != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (NorthWestRow [4] != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								NorthWestRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (NorthWestRow [4] != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (NorthWestRow [5] != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									NorthWestRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (NorthWestRow [5] != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (NorthWestRow [6] != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										NorthWestRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (NorthWestRow [6] != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (NorthWestRow [7] != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											NorthWestRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										if (NorthWestRow [7] != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {

										}
									}
								}
							}
						}
					}
				}
			}

			if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				SouthWestRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (SouthWestRow [1] != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					SouthWestRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (SouthWestRow [1] != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (SouthWestRow [2] != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						SouthWestRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (SouthWestRow [2] != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (SouthWestRow [3] != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							SouthWestRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (SouthWestRow [3] != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (SouthWestRow [4] != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								SouthWestRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (SouthWestRow [4] != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (SouthWestRow [5] != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									SouthWestRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (SouthWestRow [5] != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (SouthWestRow [6] != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										SouthWestRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (SouthWestRow [6] != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (SouthWestRow [7] != null && SouthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											SouthWestRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										if (SouthWestRow [7] != null && SouthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {

										}
									}
								}
							}
						}
					}
				}
			}

			if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				SouthEastRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (SouthEastRow [1] != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					SouthEastRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (SouthEastRow [1] != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (SouthEastRow [2] != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						SouthEastRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (SouthEastRow [2] != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (SouthEastRow [3] != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							SouthEastRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (SouthEastRow [3] != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (SouthEastRow [4] != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								SouthEastRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (SouthEastRow [4] != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (SouthEastRow [5] != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									SouthEastRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (SouthEastRow [5] != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (SouthEastRow [6] != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										SouthEastRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (SouthEastRow [6] != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (SouthEastRow [7] != null && SouthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											SouthEastRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										if (SouthEastRow [7] != null && SouthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {

										}
									}
								}
							}
						}
					}
				}
			}

			if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				NorthRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (NorthRow [1] != null && NorthRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					NorthRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (NorthRow [1] != null && NorthRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (NorthRow [2] != null && NorthRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						NorthRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (NorthRow [2] != null && NorthRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (NorthRow [3] != null && NorthRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							NorthRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (NorthRow [3] != null && NorthRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (NorthRow [4] != null && NorthRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								NorthRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (NorthRow [4] != null && NorthRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (NorthRow [5] != null && NorthRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									NorthRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (NorthRow [5] != null && NorthRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (NorthRow [6] != null && NorthRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										NorthRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (NorthRow [6] != null && NorthRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (NorthRow [7] != null && NorthRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											NorthRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										if (NorthRow [7] != null && NorthRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {

										}
									}
								}
							}
						}
					}
				}
			}

			if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				EastRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (EastRow [1] != null && EastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					EastRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (EastRow [1] != null && EastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (EastRow [2] != null && EastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						EastRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (EastRow [2] != null && EastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (EastRow [3] != null && EastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							EastRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (EastRow [3] != null && EastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (EastRow [4] != null && EastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								EastRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (EastRow [4] != null && EastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (EastRow [5] != null && EastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									EastRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (EastRow [5] != null && EastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (EastRow [6] != null && EastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										EastRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (EastRow [6] != null && EastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (EastRow [7] != null && EastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											EastRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										if (EastRow [7] != null && EastRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {

										}
									}
								}
							}
						}
					}
				}
			}

			if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				SouthRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (SouthRow [1] != null && SouthRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					SouthRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (SouthRow [1] != null && SouthRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (SouthRow [2] != null && SouthRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						SouthRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (SouthRow [2] != null && SouthRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (SouthRow [3] != null && SouthRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							SouthRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (SouthRow [3] != null && SouthRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (SouthRow [4] != null && SouthRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								SouthRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (SouthRow [4] != null && SouthRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (SouthRow [5] != null && SouthRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									SouthRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (SouthRow [5] != null && SouthRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (SouthRow [6] != null && SouthRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										SouthRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (SouthRow [6] != null && SouthRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (SouthRow [7] != null && SouthRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											SouthRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										if (SouthRow [7] != null && SouthRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {

										}
									}
								}
							}
						}
					}
				}
			}

			if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				WestRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (WestRow [1] != null && WestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [1].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
					WestRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (WestRow [1] != null && WestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (WestRow [2] != null && WestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [2].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
						WestRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (WestRow [2] != null && WestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (WestRow [3] != null && WestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [3].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
							WestRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (WestRow [3] != null && WestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (WestRow [4] != null && WestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [4].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
								WestRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (WestRow [4] != null && WestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (WestRow [5] != null && WestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [5].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
									WestRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (WestRow [5] != null && WestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (WestRow [6] != null && WestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [6].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
										WestRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (WestRow [6] != null && WestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (WestRow [7] != null && WestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [7].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
											WestRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										if (WestRow [7] != null && WestRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {

										}
									}
								}
							}
						}
					}
				}
			}
		}
		if (currentPieceIsQueen == true && occupiedByBlack) {
			if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				NorthEastRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (NorthEastRow [1] != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					NorthEastRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (NorthEastRow [1] != null && NorthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (NorthEastRow [2] != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						NorthEastRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (NorthEastRow [2] != null && NorthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (NorthEastRow [3] != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							NorthEastRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (NorthEastRow [3] != null && NorthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (NorthEastRow [4] != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								NorthEastRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (NorthEastRow [4] != null && NorthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (NorthEastRow [5] != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									NorthEastRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (NorthEastRow [5] != null && NorthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (NorthEastRow [6] != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										NorthEastRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (NorthEastRow [6] != null && NorthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (NorthEastRow [7] != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											NorthEastRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										if (NorthEastRow [7] != null && NorthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {

										}
									}
								}
							}
						}
					}
				}
			}

			if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				NorthWestRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (NorthWestRow [1] != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					NorthWestRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (NorthWestRow [1] != null && NorthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (NorthWestRow [2] != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						NorthWestRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (NorthWestRow [2] != null && NorthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (NorthWestRow [3] != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							NorthWestRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (NorthWestRow [3] != null && NorthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (NorthWestRow [4] != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								NorthWestRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (NorthWestRow [4] != null && NorthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (NorthWestRow [5] != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									NorthWestRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (NorthWestRow [5] != null && NorthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (NorthWestRow [6] != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										NorthWestRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (NorthWestRow [6] != null && NorthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (NorthWestRow [7] != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											NorthWestRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										if (NorthWestRow [7] != null && NorthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece == null) {

										}
									}
								}
							}
						}
					}
				}
			}

			if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				SouthWestRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (SouthWestRow [1] != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					SouthWestRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (SouthWestRow [1] != null && SouthWestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (SouthWestRow [2] != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						SouthWestRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (SouthWestRow [2] != null && SouthWestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (SouthWestRow [3] != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							SouthWestRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (SouthWestRow [3] != null && SouthWestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (SouthWestRow [4] != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								SouthWestRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (SouthWestRow [4] != null && SouthWestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (SouthWestRow [5] != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									SouthWestRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (SouthWestRow [5] != null && SouthWestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (SouthWestRow [6] != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										SouthWestRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (SouthWestRow [6] != null && SouthWestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (SouthWestRow [7] != null && SouthWestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											SouthWestRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}

			if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				SouthEastRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (SouthEastRow [1] != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					SouthEastRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (SouthEastRow [1] != null && SouthEastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (SouthEastRow [2] != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						SouthEastRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (SouthEastRow [2] != null && SouthEastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (SouthEastRow [3] != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							SouthEastRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (SouthEastRow [3] != null && SouthEastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (SouthEastRow [4] != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								SouthEastRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (SouthEastRow [4] != null && SouthEastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (SouthEastRow [5] != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									SouthEastRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (SouthEastRow [5] != null && SouthEastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (SouthEastRow [6] != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										SouthEastRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (SouthEastRow [6] != null && SouthEastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (SouthEastRow [7] != null && SouthEastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											SouthEastRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}

			if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				NorthRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (NorthRow [1] != null && NorthRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					NorthRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (NorthRow [1] != null && NorthRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (NorthRow [2] != null && NorthRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						NorthRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (NorthRow [2] != null && NorthRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (NorthRow [3] != null && NorthRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							NorthRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (NorthRow [3] != null && NorthRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (NorthRow [4] != null && NorthRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								NorthRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (NorthRow [4] != null && NorthRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (NorthRow [5] != null && NorthRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									NorthRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (NorthRow [5] != null && NorthRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (NorthRow [6] != null && NorthRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										NorthRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (NorthRow [6] != null && NorthRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (NorthRow [7] != null && NorthRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											NorthRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}

			if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				EastRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (EastRow [1] != null && EastRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					EastRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (EastRow [1] != null && EastRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (EastRow [2] != null && EastRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						EastRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (EastRow [2] != null && EastRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (EastRow [3] != null && EastRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							EastRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (EastRow [3] != null && EastRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (EastRow [4] != null && EastRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								EastRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (EastRow [4] != null && EastRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (EastRow [5] != null && EastRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									EastRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (EastRow [5] != null && EastRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (EastRow [6] != null && EastRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										EastRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (EastRow [6] != null && EastRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (EastRow [7] != null && EastRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											EastRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}

			if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				SouthRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (SouthRow [1] != null && SouthRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					SouthRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (SouthRow [1] != null && SouthRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (SouthRow [2] != null && SouthRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						SouthRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (SouthRow [2] != null && SouthRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (SouthRow [3] != null && SouthRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							SouthRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (SouthRow [3] != null && SouthRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (SouthRow [4] != null && SouthRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								SouthRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (SouthRow [4] != null && SouthRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (SouthRow [5] != null && SouthRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									SouthRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (SouthRow [5] != null && SouthRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (SouthRow [6] != null && SouthRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										SouthRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (SouthRow [6] != null && SouthRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (SouthRow [7] != null && SouthRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											SouthRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}

			if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				WestRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
			}
			if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece == null) {
				if (WestRow [1] != null && WestRow [1].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [1].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
					WestRow [1].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
				}
				if (WestRow [1] != null && WestRow [1].GetComponent<ChessSpaceScript> ().currentPiece == null) {
					if (WestRow [2] != null && WestRow [2].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [2].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
						WestRow [2].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
					}
					if (WestRow [2] != null && WestRow [2].GetComponent<ChessSpaceScript> ().currentPiece == null) {
						if (WestRow [3] != null && WestRow [3].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [3].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
							WestRow [3].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
						}
						if (WestRow [3] != null && WestRow [3].GetComponent<ChessSpaceScript> ().currentPiece == null) {
							if (WestRow [4] != null && WestRow [4].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [4].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
								WestRow [4].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
							}
							if (WestRow [4] != null && WestRow [4].GetComponent<ChessSpaceScript> ().currentPiece == null) {
								if (WestRow [5] != null && WestRow [5].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [5].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
									WestRow [5].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
								}
								if (WestRow [5] != null && WestRow [5].GetComponent<ChessSpaceScript> ().currentPiece == null) {
									if (WestRow [6] != null && WestRow [6].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [6].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
										WestRow [6].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
									}
									if (WestRow [6] != null && WestRow [6].GetComponent<ChessSpaceScript> ().currentPiece == null) {
										if (WestRow [7] != null && WestRow [7].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow [7].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
											WestRow [7].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);
										}
										
									}
								}
							}
						}
					}
				}
			}
		}
		if (currentPieceIsKing == true && occupiedByWhite == true) {

			if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow[0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				NorthRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

			}

			if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow[0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				NorthEastRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

			}

			if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow[0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				SouthEastRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

			}

			if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow[0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				SouthRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

			}

			if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow[0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				SouthWestRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

			}

			if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow[0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				EastRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

			}

			if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow[0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				WestRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

			}

			if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow[0].GetComponent<ChessSpaceScript> ().occupiedByBlack == true) {
				NorthWestRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

			}

//			if (currentPiece.GetComponent<ChessPieceScript> ().firstMove == true && kingRookSwitchEast.GetComponent<ChessSpaceScript> ().currentPieceIsRook == true) {
//				kingRookSwitchEast.GetComponent<ChessSpaceScript> ().isAvailable = true;
//			}
//			if (currentPiece.GetComponent<ChessPieceScript> ().firstMove == true && kingRookSwitchWest.GetComponent<ChessSpaceScript> ().currentPieceIsRook == true) {
//				kingRookSwitchWest.GetComponent<ChessSpaceScript> ().isAvailable = true;
//			}

		}
		if (currentPieceIsKing == true && occupiedByBlack == true) {

			if (NorthRow [0] != null && NorthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthRow[0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				NorthRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

			}

			if (NorthEastRow [0] != null && NorthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthEastRow[0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				NorthEastRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

			}

			if (SouthEastRow [0] != null && SouthEastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthEastRow[0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				SouthEastRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

			}

			if (SouthRow [0] != null && SouthRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthRow[0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				SouthRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

			}

			if (SouthWestRow [0] != null && SouthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && SouthWestRow[0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				SouthWestRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

			}

			if (EastRow [0] != null && EastRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && EastRow[0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				EastRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

			}

			if (WestRow [0] != null && WestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && WestRow[0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				WestRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

			}

			if (NorthWestRow [0] != null && NorthWestRow [0].GetComponent<ChessSpaceScript> ().currentPiece != null && NorthWestRow[0].GetComponent<ChessSpaceScript> ().occupiedByWhite == true) {
				NorthWestRow [0].GetComponent<ChessSpaceScript> ().VulnerableTo.Add (gameObject);

			}

//			if (currentPiece.GetComponent<ChessPieceScript> ().firstMove == true && kingRookSwitchEast.GetComponent<ChessSpaceScript> ().currentPieceIsRook == true) {
//				kingRookSwitchEast.GetComponent<ChessSpaceScript> ().isAvailable = true;
//			}
//			if (currentPiece.GetComponent<ChessPieceScript> ().firstMove == true && kingRookSwitchWest.GetComponent<ChessSpaceScript> ().currentPieceIsRook == true) {
//				kingRookSwitchWest.GetComponent<ChessSpaceScript> ().isAvailable = true;
//			}

		}
		VulnerableTo.Clear ();
		if (chessBoardRef.GetComponent<ChessBoardRefScript> ().nothingSelected == true) {
			isSelectedBlock = false;
			isAvailable = false;
			isContested = false;

			rend.sharedMaterial = defaultMat;
		}

		}

//		if (Input.GetKeyDown ("a")) {
//			currentPieceIsPawn = false;
//			currentPieceIsBishop = false;
//			currentPieceIsKnight = false;
//			currentPieceIsRook = false;
//			currentPieceIsQueen = false;
//			currentPieceIsKing = false;
//			isSelectedBlock = false;
//			isAvailable = false;
//			isContested = false;
//			occupiedByBlack = false;
//			occupiedByWhite = false;
//			rend.sharedMaterial = defaultMat;
//		}


	public void Unavailable(){
			if (NorthRow [0] != null) {
				NorthRow [0].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (NorthRow [1] != null) {
				NorthRow [1].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (NorthRow [2] != null) {
				NorthRow [2].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (NorthRow [3] != null) {
				NorthRow [3].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (NorthRow [4] != null) {
				NorthRow [4].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (NorthRow [5] != null) {
				NorthRow [5].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (NorthRow [6] != null) {
				NorthRow [6].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (NorthRow [7] != null) {
				NorthRow [7].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}

			if (NorthEastRow [0] != null) {
				NorthEastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (NorthEastRow [1] != null) {
				NorthEastRow [1].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (NorthEastRow [2] != null) {
				NorthEastRow [2].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (NorthEastRow [3] != null) {
				NorthEastRow [3].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (NorthEastRow [4] != null) {
				NorthEastRow [4].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (NorthEastRow [5] != null) {
				NorthEastRow [5].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (NorthEastRow [6] != null) {
				NorthEastRow [6].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (NorthEastRow [7] != null) {
				NorthEastRow [7].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}

			if (EastRow [0] != null) {
				EastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (EastRow [1] != null) {
				EastRow [1].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (EastRow [2] != null) {
				EastRow [2].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (EastRow [3] != null) {
				EastRow [3].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (EastRow [4] != null) {
				EastRow [4].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (EastRow [5] != null) {
				EastRow [5].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (EastRow [6] != null) {
				EastRow [6].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (EastRow [7] != null) {
				EastRow [7].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}

			if (SouthEastRow [0] != null) {
				SouthEastRow [0].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (SouthEastRow [1] != null) {
				SouthEastRow [1].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (SouthEastRow [2] != null) {
				SouthEastRow [2].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (SouthEastRow [3] != null) {
				SouthEastRow [3].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (SouthEastRow [4] != null) {
				SouthEastRow [4].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (SouthEastRow [5] != null) {
				SouthEastRow [5].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (SouthEastRow [6] != null) {
				SouthEastRow [6].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (SouthEastRow [7] != null) {
				SouthEastRow [7].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}

			if (SouthRow [0] != null) {
				SouthRow [0].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (SouthRow [1] != null) {
				SouthRow [1].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (SouthRow [2] != null) {
				SouthRow [2].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (SouthRow [3] != null) {
				SouthRow [3].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (SouthRow [4] != null) {
				SouthRow [4].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (SouthRow [5] != null) {
				SouthRow [5].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (SouthRow [6] != null) {
				SouthRow [6].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (SouthRow [7] != null) {
				SouthRow [7].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}

			if (SouthWestRow [0] != null) {
				SouthWestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (SouthWestRow [1] != null) {
				SouthWestRow [1].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (SouthWestRow [2] != null) {
				SouthWestRow [2].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (SouthWestRow [3] != null) {
				SouthWestRow [3].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (SouthWestRow [4] != null) {
				SouthWestRow [4].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (SouthWestRow [5] != null) {
				SouthWestRow [5].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (SouthWestRow [6] != null) {
				SouthWestRow [6].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (SouthWestRow [7] != null) {
				SouthWestRow [7].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}

			if (WestRow [0] != null) {
				WestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (WestRow [1] != null) {
				WestRow [1].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (WestRow [2] != null) {
				WestRow [2].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (WestRow [3] != null) {
				WestRow [3].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (WestRow [4] != null) {
				WestRow [4].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (WestRow [5] != null) {
				WestRow [5].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (WestRow [6] != null) {
				WestRow [6].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (WestRow [7] != null) {
				WestRow [7].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}

			if (NorthWestRow [0] != null) {
				NorthWestRow [0].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (NorthWestRow [1] != null) {
				NorthWestRow [1].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (NorthWestRow [2] != null) {
				NorthWestRow [2].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (NorthWestRow [3] != null) {
				NorthWestRow [3].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (NorthWestRow [4] != null) {
				NorthWestRow [4].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (NorthWestRow [5] != null) {
				NorthWestRow [5].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (NorthWestRow [6] != null) {
				NorthWestRow [6].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
			if (NorthWestRow [7] != null) {
				NorthWestRow [7].GetComponent<ChessSpaceScript> ().isAvailable = false;
			}
		if (knightSpaceNW != null) {
			knightSpaceNW.GetComponent<ChessSpaceScript> ().isAvailable = false;
		}
		if (knightSpaceNE != null) {
			knightSpaceNE.GetComponent<ChessSpaceScript> ().isAvailable = false;
		}
		if (knightSpaceEN != null) {
			knightSpaceEN.GetComponent<ChessSpaceScript> ().isAvailable = false;
		}
		if (knightSpaceES != null) {
			knightSpaceES.GetComponent<ChessSpaceScript> ().isAvailable = false;
		}
		if (knightSpaceSE != null) {
			knightSpaceSE.GetComponent<ChessSpaceScript> ().isAvailable = false;
		}
		if (knightSpaceSW != null) {
			knightSpaceSW.GetComponent<ChessSpaceScript> ().isAvailable = false;
		}
		if (knightSpaceWN != null) {
			knightSpaceWN.GetComponent<ChessSpaceScript> ().isAvailable = false;
		}
		if (knightSpaceWS != null) {
			knightSpaceWS.GetComponent<ChessSpaceScript> ().isAvailable = false;
		}
		if (pawnNE != null) {
			pawnNE.GetComponent<ChessSpaceScript> ().isAvailable = false;
		}
		if (pawnNW != null) {
			pawnNW.GetComponent<ChessSpaceScript> ().isAvailable = false;
		}
		if (pawnSE != null) {
			pawnSE.GetComponent<ChessSpaceScript> ().isAvailable = false;
		}
		if (pawnSW != null) {
			pawnSW.GetComponent<ChessSpaceScript> ().isAvailable = false;
		}
		if (pawnNorth1 != null) {
			pawnNorth1.GetComponent<ChessSpaceScript> ().isAvailable = false;
		}
		if (pawnNorth2 != null) {
			pawnNorth2.GetComponent<ChessSpaceScript> ().isAvailable = false;
		}
		if (pawnSouth1 != null) {
			pawnSouth1.GetComponent<ChessSpaceScript> ().isAvailable = false;
		}
		if (pawnSouth2 != null) {
			pawnSouth2.GetComponent<ChessSpaceScript> ().isAvailable = false;
		}

	}


}
