using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {
    bool holdingItem;
    public GameObject itemPrefab;
	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckObjectHolding(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        CheckObjectHolding(collision);
    }

    void CheckObjectHolding(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {

            Player player = collision.GetComponent<Player>();
            holdingItem = player.GetItemHeld();
            if (Input.GetKey(KeyCode.E))
            {
                //check if player is already holding an item
                if (holdingItem)
                {
                    //do nothing and break out
                    return;
                }

                if (!holdingItem)
                {

                    //set player to holding item
                    //GameObject item = Instantiate(itemPrefab, player.transform.position, player.transform.rotation);
                    //item.transform.SetParent(player.transform);
                    //item.transform.position = new Vector3(item.transform.position.x, item.transform.position.y, -1);

                    player.SetItemHeld(true);
                }

            }

        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    //edited item spawn to work with spawnsurface
    public GameObject SpawnItem()
    {
        GameObject item = Instantiate(itemPrefab, transform.position, transform.rotation) as GameObject;
        return item;
    }
}
