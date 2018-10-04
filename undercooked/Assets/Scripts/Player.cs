using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public AudioClip pickup;
    public AudioClip drop;

    public Pickup_Action pickup_action;
    public bool itemHeld;
    public bool action;

    private InputManager input;
    private Pickup player_pickup;
	// Use this for initialization
	void Start ()
    {
        input = GetComponent<InputManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        InputManager input = GetComponent<InputManager>();
        if (input.actionKey)
        {
            action = true;
        }
        else
        {
            action = false;
        }
    }

    public void SetItemHeld(bool item)
    {
        itemHeld = item;
    }

    public bool GetItemHeld()
    {
        return itemHeld;
    }
}
