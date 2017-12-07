using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour {


    public GameObject RoadPiecePrefab;

    public float RoadPieceWidth;


    List<GameObject> roadPieces;


	void Start () {

        roadPieces = new List<GameObject>();
        // first three roadpieces
        GameObject roadPiece = GameObject.Instantiate<GameObject>(RoadPiecePrefab, transform);
        roadPiece.transform.position = Vector3.zero;
        Vector3 right = roadPiece.transform.right;
        roadPieces.Add(roadPiece);

        GameObject roadPieceFront = GameObject.Instantiate<GameObject>(RoadPiecePrefab, transform);
        roadPiece.transform.position = right * RoadPieceWidth;

    }
	
	
	void Update () {
		
	}
}
