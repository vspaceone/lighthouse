using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgBoxCtrl : MonoBehaviour {


	public GameObject guiGameObj;
	private UnityEngine.UI.Text uiText;
	private string txt;

	// Use this for initialization
	IEnumerator Start () {

		uiText = guiGameObj.GetComponent<UnityEngine.UI.Text>();
		uiText.text = "";

		yield return new WaitForSecondsRealtime(3);

     	Destroy(this.gameObject);
	}


	public void Initialize( string message ){
		txt = message;
	}
	
	// Update is called once per frame
	void Update () {
		uiText = guiGameObj.GetComponent<UnityEngine.UI.Text>();
		uiText.text = txt;
	
	}
}
