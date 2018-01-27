using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private GameObject _gameControllerGo;
    private GameController _gameController;

    public InteractionTypeEnum InteractionType;
    public bool HideColliderOnGoingInactive = true;
    public bool HideGameobjectOnGoingInactive = true;
    public bool AutoActivate = false;
    public bool ToggleStartValue;
    public string ActivateAction = "DebugActivateInteractable";
    public string DeactivateAction = "DebugDeactivateInteractable";

    private bool _Status;

    // Use this for initialization
    void Start()
    {
        _gameControllerGo = GameObject.FindGameObjectWithTag("GameController");
        _gameController = _gameControllerGo.GetComponent<GameController>();
        if (InteractionType == InteractionTypeEnum.Toggleable)
        {
            _Status = ToggleStartValue;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate()
    {
        switch (InteractionType)
        {
            case InteractionTypeEnum.Basic:
                if (HideGameobjectOnGoingInactive)
                {
                    this.gameObject.SetActive(false);
                }
                else if (HideColliderOnGoingInactive)
                {
                    this.gameObject.GetComponent<Collider2D>().enabled = false;
                }
                _gameController.Action(ActivateAction, this.gameObject);
                break;
            case InteractionTypeEnum.Toggleable:
                _Status = !_Status;
                _gameController.Action((_Status ? ActivateAction : DeactivateAction), this.gameObject);
                break;
        }

    }

    public enum InteractionTypeEnum
    {
        Basic,
        Toggleable
    }
}
