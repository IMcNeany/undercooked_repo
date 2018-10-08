using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupText : MonoBehaviour {

    public Pickup_Action pickup_action;
    public int player_num;
    public Text text;

    private void Start()
    {
        Invoke("DelayedStart", 0.5f);
    }

    void Update () {

        if (pickup_action)
        {
            if (pickup_action.pickup_object)
            {
                text.text = "Player " + player_num + " : " + pickup_action.pickup_object.name;
            }
            else
            {
                text.text = "Player " + player_num + " : Empty hands";
            }
        }
	}

    public void DelayedStart()
    {
        if (GameObject.Find("Player" + player_num))
        {
            pickup_action = GameObject.Find("Player" + player_num).GetComponentInChildren<Pickup_Action>();
        }
    }
}
