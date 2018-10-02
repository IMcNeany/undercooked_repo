using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSurface : MonoBehaviour {

    public GameObject current_item;

    public void Update()
    {
        if(current_item)
        {
            current_item.transform.position = transform.position;
        }
    }

    public virtual void AddItem(GameObject obj)
    {
        current_item = obj;
        current_item.transform.position = transform.position;
    }

    public virtual bool Interact()
    {
        return true;
    }

}
