using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Action : MonoBehaviour {

    private Player player;
    public GameObject pickup_object;

    public void Start()
    {
        player = GetComponentInParent<Player>();
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

        if(collision.gameObject.GetComponent<Pickup>())
        {
            
            if (player.action)
            {
                if (pickup_object == null)
                {
                    pickup_object = collision.gameObject;
                }
                else
                {
                    pickup_object = null;
                }
                
            }

        }
    }

}
