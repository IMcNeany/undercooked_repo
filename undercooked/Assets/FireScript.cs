using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

    public float fire_timer = 0.0f;
    public GameObject fire_prefab;
    public bool spread_fire = true;
    public void Update()
    {
        fire_timer += 1 * Time.deltaTime;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (fire_timer > 5.0f && spread_fire)
        {
            if (collision.GetComponent<ItemSurface>())
            {
                ItemSurface surface = collision.GetComponent<ItemSurface>();
                if (surface.fire == null)
                {
                    GameObject new_fire = Instantiate(fire_prefab, collision.transform.position, collision.transform.rotation) as GameObject;
                    new_fire.name = "Fire";
                    new_fire.transform.parent = surface.transform;
                    new_fire.GetComponent<FireScript>().fire_timer = 0.0f;
                    surface.fire = new_fire;
                }
            }
        }

        if(fire_timer > 5.1f)
        {
            spread_fire = false;
        }
    }
}
