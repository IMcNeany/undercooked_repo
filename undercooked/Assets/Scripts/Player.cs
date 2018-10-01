using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
   
    public bool itemHeld;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
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
