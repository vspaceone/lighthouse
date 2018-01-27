using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{

    public float DistanceFromGround = 0.5f;
    public float DropRate = 0.3f;
    public float MovementSpeedMultiplyer = 0.1f;

    private Vector2 _positionVector;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private LayerMask _terrainLayerMask;
    private LayerMask _ladderLayerMask;
    private LayerMask _interactableLayerMask;

    private bool _canClimb = false;

    // Use this for initialization
    void Start()
    {
        _positionVector = this.transform.position;
        _animator = this.GetComponent<Animator>();
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        _terrainLayerMask = LayerMask.GetMask("Terrain");
        _ladderLayerMask = LayerMask.GetMask("Ladder");
        _interactableLayerMask = LayerMask.GetMask("Interactable");
    }

    void FixedUpdate()
    {
        if (!_canClimb)
        {
            _positionVector.y -= DropRate;
            this.transform.position = _positionVector;

            RaycastHit2D terrainHit = Physics2D.Raycast(transform.position + Vector3.up, -Vector2.up, 10, _terrainLayerMask.value);
            if (terrainHit.collider != null)
            {

                float distance = Mathf.Abs(terrainHit.point.y - transform.position.y);
                float heightError = DistanceFromGround - distance;
                _positionVector.y += heightError;
            }
        }

        RaycastHit2D ladderHit = Physics2D.Raycast(transform.position, Vector2.up, 0.1f, _ladderLayerMask);
        if (ladderHit.collider != null)
        {
            _canClimb = true;
        }
        else
        {
            _canClimb = false;
        }

        if (_canClimb)
        {
            _positionVector.y += Input.GetAxis("Vertical");
        }

        RaycastHit2D interactableHit = Physics2D.Raycast(transform.position, Vector2.down, 3, _interactableLayerMask);
        if (interactableHit.collider != null)
        {


            if (Input.GetKeyDown(KeyCode.Space) || interactableHit.collider.gameObject.GetComponent<Interactable>().AutoActivate == true)
            {
                interactableHit.collider.gameObject.GetComponent<Interactable>().Activate();
                _animator.Play("Hurt");
            }
        }

        float inputX = Input.GetAxis("Horizontal");

        _positionVector.x += inputX * MovementSpeedMultiplyer;

        bool ismoving = (inputX != 0);
        bool wasmoving = _animator.GetBool("Walking");

        if (inputX > 0 && !_spriteRenderer.flipX)
        {
            _spriteRenderer.flipX = true;
        }
        else if (inputX < 0 && _spriteRenderer.flipX)
        {
            _spriteRenderer.flipX = false;
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
