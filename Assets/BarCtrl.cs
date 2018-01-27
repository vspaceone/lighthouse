using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarCtrl : MonoBehaviour {

	public GameObject gObjAction;
	public GameObject gObjDay;
	private UnityEngine.UI.Text txtAction;
	private UnityEngine.UI.Text txtDay;
	private string action;

	private string[] days = { "23.Mai 1940", "24.Mai 1940", "25.Mai 1940", "26.Mai 1940",
	"27.Mai 1940", "28.Mai 1940", "29.Mai 1940", "30.Mai 1940", "31.Mai 1940",
"1.Juni 1940", "2.Juni 1940", "3.Juni 1940", "4.Juni 1940", "5.Juni 1940" };

	// Use this for initialization
	void Start () {

		txtAction = gObjAction.GetComponent<UnityEngine.UI.Text>();
		txtAction.text = "";
		txtDay = gObjDay.GetComponent<UnityEngine.UI.Text>();
		txtDay.text = "";

	}

	public void SetAction( string message ){
		action = message;
	}

	// Update is called once per frame
	void Update () {
		txtAction = gObjAction.GetComponent<UnityEngine.UI.Text>();
		txtAction.text = action;

		txtDay = gObjDay.GetComponent<UnityEngine.UI.Text>();
		txtDay.text = days[Global.Gamestate.dayNumber];

	}
}
