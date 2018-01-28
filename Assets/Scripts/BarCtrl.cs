using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarCtrl : MonoBehaviour {

	public GameObject gObjAction;
	public GameObject gObjDay;
	private UnityEngine.UI.Text txtAction;
	private UnityEngine.UI.Text txtDay;

	private string[] days = { "23.Mai 1940", "24.Mai 1940", "25.Mai 1940", "26.Mai 1940",
	"27.Mai 1940", "28.Mai 1940", "29.Mai 1940", "30.Mai 1940", "31.Mai 1940",
"1.Juni 1940", "2.Juni 1940", "3.Juni 1940", "4.Juni 1940", "5.Juni 1940" };

	Dictionary<string, string> actions= new Dictionary<string,string>();

	// Use this for initialization
	void Start () {

		txtAction = gObjAction.GetComponent<UnityEngine.UI.Text>();
		txtAction.text = "";
		txtDay = gObjDay.GetComponent<UnityEngine.UI.Text>();
		txtDay.text = "";



		actions.Add("schlafen","Gehe schlafen");
		actions.Add("licht_anschalten","Schalte das Licht an");
		actions.Add("licht_ausschalten","Schalte das Licht aus");
		actions.Add("dose_holen","Nehme eine Dose");
		actions.Add("kochen","Koche etwas");
		actions.Add("essen","Esse etwas");
		actions.Add("blumen_giessen","Giesse die Blumen");
		actions.Add("karte_anschauen","Untersuche die Karte");
		actions.Add("zaehne_putzen","Putze die Zaehne");
		actions.Add("generator_nachfuellen","Fülle den Generator nach");
		actions.Add("tomaten_streicheln","Streichle die Tomaten");
		actions.Add("in_briefkasten_schauen","Schaue in den Briefkasten");
		actions.Add("fernschreiber_anschauen","Untersuche den Fernschreib");
		actions.Add("funkgeraet_anschauen","Untersuch das Funkgeraet");
		actions.Add("erkunde_wohnzimmer","");
		actions.Add("erkunde_keller","");
		actions.Add("erkunde_werkstatt","");
		actions.Add("erkunde_funkraum","");
		actions.Add("erkunde_birnenraum","");
		actions.Add("erkunde_garten","");

	}

	// Update is called once per frame
	void Update () {

		txtDay = gObjDay.GetComponent<UnityEngine.UI.Text>();
		txtDay.text = days[Global.Gamestate.dayNumber];

		if( Global.Gamestate.hoveringAction != ""){
			try{
				txtAction = gObjAction.GetComponent<UnityEngine.UI.Text>();
				txtAction.text = actions[Global.Gamestate.hoveringAction];
			}catch{
				txtAction = gObjAction.GetComponent<UnityEngine.UI.Text>();
				txtAction.text = Global.Gamestate.hoveringAction + " (err)";
			}
		}else{
			txtAction = gObjAction.GetComponent<UnityEngine.UI.Text>();
			txtAction.text = "";
		}
	}
}
