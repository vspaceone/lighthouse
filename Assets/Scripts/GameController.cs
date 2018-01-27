using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject msgBoxPrefab;

    public void Action(string Action, GameObject GO)
    {
        //biggest f-ing switch monster ever


        switch (Action)
        {
            case "schlafen":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();
                mBoxCtrl.Initialize("Tzzzzzz....");
                break;
            }
            case "dose_holen":
            {
                GameObject gObj = Instantiate(msgBoxPrefab);
                MsgBoxCtrl mBoxCtrl = gObj.GetComponent<MsgBoxCtrl>();
                mBoxCtrl.Initialize("Mhmmm Ravioli. Lecker.");
                break;
            }
            default:
                Debug.Log(GO.name + " sent action " + Action);
                break;

        }
    }

}
