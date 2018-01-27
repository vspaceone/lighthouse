using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject msgBoxPrefab;

    private Dictionary<string, bool> occuredActions = new Dictionary<string, bool>();


    public void Action(string Action, GameObject GO)
    {
        //biggest f-ing switch monster ever

        // Add Action to occuredActions
        occuredActions.add(Action, true);

        switch (Action)
        {
            case "schlafen":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();
                mBoxCtrl.Initialize("Tzzzzzz....");
                break;
            }
            case "zaehne_putzen":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();
                mBoxCtrl.Initialize("Immer 3 Minuten Zähne putzen. Wichtig!");
                break;
            }
            case "dose_holen":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();
                mBoxCtrl.Initialize("Mhmmm Ravioli. Lecker. Jetzt wird gekocht...");
                break;
            }
            default:
                Debug.Log(GO.name + " sent action " + Action);
                break;

        }
    }

}
