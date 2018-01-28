using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCtrl : MonoBehaviour {

	private string lastLightState = "nostate";
	public Sprite OnSprite;
	public Sprite OffSprite;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		string ls = Global.Gamestate.lightstate;
		if( ls != lastLightState){

			if( ls == "on" ){
				SpriteRenderer _spriteRenderer = GetComponent<SpriteRenderer>();
				_spriteRenderer.sprite = OnSprite;
			}else if( ls == "off"){
				SpriteRenderer _spriteRenderer = GetComponent<SpriteRenderer>();
				_spriteRenderer.sprite = OffSprite;
			}

			lastLightState = ls;

		}
	}
}
