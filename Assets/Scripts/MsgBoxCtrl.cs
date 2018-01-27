using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgBoxCtrl : MonoBehaviour {


	public GameObject guiGameObj;
	private UnityEngine.UI.Text guiText;
	private string msg;

	// Use this for initialization
	IEnumerator Start () {
		//guiText.text = "Hallo WElt";
		guiText = guiGameObj.GetComponent<UnityEngine.UI.Text>();
		guiText.text = "";
		print(Time.time);
		yield return new WaitForSecondsRealtime(2);

		print(Time.time);
     	Destroy(this.gameObject);
	}


	void initialize( string message ){
		msg = message;
		guiText.text = msg;
	}
	
	// Update is called once per frame
	void Update () {
		//guiText.text = "Hallo Welt";	
	}
}
