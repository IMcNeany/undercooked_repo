using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceInteraction : MonoBehaviour {
    public bool itemHeld = false;
    Transform item;
    Pickup pickup;
    bool startTimer;
    float timer = 0.5f;
    float time = 0.0f;
    bool interactable = true;


	// Use this for initialization
	void Start () {
		if(GetComponent<Pickup>())
        {
            pickup = GetComponent<Pickup>();
            itemHeld = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(startTimer)
        {
            time += Time.deltaTime;

            if(time >= timer)
            {
                startTimer = false;
                interactable = true;
                time = 0.0f;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("player entered");
        ActionRequired(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        ActionRequired(collision);
    }

    void ActionRequired(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        if (interactable)
        {
            //can't take an item
            if (player != null)
            {
                if (player.action)
                {
                    if (itemHeld && player.GetItemHeld())
                    {
                        Debug.Log("items both held");
                        return;
                    }
                    if (!itemHeld && !player.GetItemHeld())
                    {
                        Debug.Log("items both not held");
                        return;
                    }
                    if (!itemHeld && player.GetItemHeld())
                    {


                        item = player.transform.GetChild(0);
                        item.SetParent(this.gameObject.transform);

                        itemHeld = true;
                        player.SetItemHeld(false);
                        item.transform.localPosition = new Vector3(0, 0, -1);
                        item.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                        interactable = false;
                        startTimer = true;
                        return;
                    }
                    if (itemHeld && !player.GetItemHeld())
                    {
                        item = this.gameObject.transform.GetChild(0);
                        item.SetParent(player.transform);
                        itemHeld = false;
                        player.SetItemHeld(true);
                        item.transform.localPosition = new Vector3(0, 0, -1);
                        item.transform.localScale = new Vector3(1.0f, 0.5f, 0.1f);
                        interactable = false;
                        startTimer = true;
                        return;
                    }
                }
            }
        }
    }
}
