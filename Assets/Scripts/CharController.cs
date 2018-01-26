using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

    public float DistanceFromGround = 0.5f;
    public float DropRate = 0.3f;
    public float MovementSpeedMultiplyer = 0.3f;
    private Vector2 _positionVector;

	// Use this for initialization
	void Start ()
	{
	    _positionVector = this.transform.position;
	}
	
	void FixedUpdate()
    {
        _positionVector.y -= DropRate;
        this.transform.position = _positionVector;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if (hit.collider != null) {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            float heightError = DistanceFromGround - distance;
            _positionVector.y += heightError;
        }

        _positionVector.x += Input.GetAxis("Horizontal") * MovementSpeedMultiplyer;

        this.transform.position = _positionVector;
    }
}
