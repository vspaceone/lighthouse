using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

    public float DistanceFromGround = 0.5f;
    public float DropRate = 0.3f;
    public float MovementSpeedMultiplyer = 0.3f;

    private Vector2 _positionVector;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

	// Use this for initialization
	void Start ()
	{
	    _positionVector = this.transform.position;
        _animator = this.GetComponent<Animator>();
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
	}
	
	void FixedUpdate()
    {
        _positionVector.y -= DropRate;
        this.transform.position = _positionVector;

        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up, -Vector2.up);
        if (hit.collider != null) {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            float heightError = DistanceFromGround - distance;
            _positionVector.y += heightError;
        }

        Debug.DrawRay(transform.position + Vector3.up, -Vector2.up * DistanceFromGround, Color.green);

        float inputX = Input.GetAxis("Horizontal");

        _positionVector.x += inputX * MovementSpeedMultiplyer;

        bool ismoving = (inputX != 0);
        bool wasmoving = _animator.GetBool("Walking");

        if (inputX > 0 && _spriteRenderer.flipX)
        {
            _spriteRenderer.flipX = false;
        }
        else if (inputX < 0 && !_spriteRenderer.flipX)
        {
            _spriteRenderer.flipX = true;
        }


        if (ismoving && !wasmoving)
        {
            _animator.SetBool("Walking", true);
        }
        else if (!ismoving && wasmoving)
        {
            _animator.SetBool("Walking", false);
        }



        this.transform.position = _positionVector;
    }
}
