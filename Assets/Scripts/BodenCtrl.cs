using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodenCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if( Global.Gamestate.onLadder){
			GetComponent<SpriteRenderer>().enabled = true;
		}else{
			GetComponent<SpriteRenderer>().enabled = false;
		}

	}
}
