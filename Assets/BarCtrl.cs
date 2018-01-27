using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarCtrl : MonoBehaviour {

	public GameObject gObjAction;
	public GameObject gObjDay;
	private UnityEngine.UI.Text txtAction;
	private UnityEngine.UI.Text txtDay;
	private string action;
	private int dayNumber;

	// Use this for initialization
	void Start () {

		txtAction = gObjAction.GetComponent<UnityEngine.UI.Text>();
		txtAction.text = "";
		txtDay = gObjDay.GetComponent<UnityEngine.UI.Text>();
		txtDay.text = "Day1";

	}


	public void SetAction( string message ){
		action = message;
	}

	public void SetDay( int day ){
		dayNumber = 1;
	}

	// Update is called once per frame
	void Update () {
		txtAction = gObjAction.GetComponent<UnityEngine.UI.Text>();
		txtAction.text = action;

		txtDay = gObjDay.GetComponent<UnityEngine.UI.Text>();
		txtDay.text = "Day" + dayNumber;

	}
}
