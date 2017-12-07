using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform Player;
    public float smoothness = 1f;

    void Start () {
		
	}
	
	
	void Update () {
        if (Player != null) {
            Vector3 nextPosition = new Vector3(Player.position.x, transform.position.y,transform.position.z);
            transform.position = Vector3.Slerp(transform.position, nextPosition, Time.deltaTime * smoothness);
        }
	}
}
