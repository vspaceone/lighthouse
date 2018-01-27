using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxCtrl : MonoBehaviour {


	public GameObject player;       //Public variable to store a reference to the player game object


	public float offsetY;         //Private variable to store the offset distance between the player and camera

	private static Vector3 ChangeX(Vector3 v, float x)
     {
         return new Vector3(x, v.y, v.z);
     }

     private static Vector3 ChangeY(Vector3 v, float y)
     {
         return new Vector3(v.x, y, v.z);
     }

     private static Vector3 ChangeZ(Vector3 v, float z)
     {
         return new Vector3(v.x, v.y, z);
     }

	// Use this for initialization
	void Start ()
	{
			//Calculate and store the offset value by getting the distance between the player's position and camera's position.
			transform.position = ChangeY(transform.position,player.transform.position.y);

	}

	// LateUpdate is called after Update each frame
	void LateUpdate ()
	{
			// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
			transform.position = ChangeY(transform.position,(player.transform.position.y+offsetY)/2);
	}
}
