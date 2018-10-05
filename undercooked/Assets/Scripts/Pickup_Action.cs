﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Action : MonoBehaviour {

    private Player player;
    private AudioSource audio;
    public GameObject pickup_object;

    public void Start()
    {
        player = GetComponentInParent<Player>();
        audio = GetComponentInParent<AudioSource>();
    }
    public void Update()
    {
        if(pickup_object)
        {
            pickup_object.transform.position = transform.position;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (player.action)
        {
            if (collision.gameObject.GetComponent<ItemSurface>())
            {
                ItemSurface surface = collision.gameObject.GetComponent<ItemSurface>();
       
                if (surface.current_item == null && pickup_object != null)
                {
                    //if you want to place down an item
                    surface.AddItem(pickup_object);
                    pickup_object = null;
                    audio.clip = player.drop;
                    audio.Play();
                }
                else
                {
                    if (surface.Interact())
                    {
                        //if interact returns true you can take the item instead of interacting with it
                        pickup_object = surface.current_item;
                        surface.current_item = null;
                        audio.clip = player.pickup;
                        audio.Play();
                    }
                }
            }
        }
    }
}
