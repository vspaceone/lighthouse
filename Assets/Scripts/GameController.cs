using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public void Action(string Action, GameObject GO)
    {
        //biggest f-ing switch monster ever

        switch (Action)
        {
            default:
                Debug.Log(GO.name + " sent action " + Action);
                break;
        }
    }

}
