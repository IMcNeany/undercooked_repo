using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Action : MonoBehaviour {

    private Player player;
    private AudioSource audio;
    public GameObject pickup_object;
    private float pickup_cooldown = 0.25f;
    public float current_cooldown = 0.25f;
    public bool colliding = false;
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
            pickup_object.transform.rotation = player.gameObject.transform.rotation;
            if (pickup_object.GetComponent<FireExstinguisher>() && !colliding)
            {
                FireExstinguisher fire_exst = pickup_object.GetComponent<FireExstinguisher>();
                if (player.action)
                {
                    fire_exst.UseItem();
                }
            }
        }
        if(current_cooldown >= 0.0f)
        {
            current_cooldown -= 1 * Time.deltaTime;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ItemSurface>())
        {
            colliding = true;
        }
           
        if (player.action == true && current_cooldown <= 0.0f)
        {    
            current_cooldown = pickup_cooldown;
            if (collision.gameObject.GetComponent<ItemSurface>())
            {
                ItemSurface surface = collision.gameObject.GetComponent<ItemSurface>();
                if (surface.on_fire == false)
                {
                    if (surface.current_item == null && pickup_object != null)
                    {
                        //if you want to place down an item to an empty surface
                        if (surface.AddItem(pickup_object))
                        {
                            pickup_object = null;
                            audio.clip = player.drop;
                            audio.Play();
                        }
                    }
                    else
                    {
                        if (pickup_object)
                        {
                            if (!pickup_object.GetComponent<FireExstinguisher>())
                            {
                                if (surface.Interact(pickup_object))
                                {
                                    //if interact returns true you take the item instead of interacting with it

                                    pickup_object = surface.current_item;
                                    surface.current_item = null;
                                    audio.clip = player.pickup;
                                    audio.Play();
                                }
                            }
                        }
                        else
                        {
                            if (surface.Interact(pickup_object))
                            {
                                //if interact returns true you take the item instead of interacting with it

                                pickup_object = surface.current_item;
                                surface.current_item = null;
                                audio.clip = player.pickup;
                                audio.Play();
                            }
                        }
                    }
                }
            }
            else
            {
                Debug.Log(collision.gameObject.name);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ItemSurface>())
        {
            colliding = false;
        }
    }
}
