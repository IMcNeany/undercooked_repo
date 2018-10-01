using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : Pickup {

    public List<FoodItem> item_list;


    public void AddItem(FoodType type)
    {
        for (int i = 0; i < item_list.Count; i++)
        {
            //check for duplicates and that item is prepared
            
        }
    }

    public void RefreshSprite()
    {
        //loop through list and set sprite depending on its contents
    }

    public override void PlaceObject(GameObject obj)
    {
        //to do add utensil stuff
        base.PlaceObject(obj);

        if(obj.GetComponent<FoodItem>())
        {
            FoodItem obj_item = obj.GetComponent<FoodItem>();
            if(obj_item.prepared)
            {
                AddItem(obj_item.type);
                Destroy(obj);
            }
            //if obj has an item, add item to the current product and place product on obj instead
        }
        else
        {
            //place product on counter/goal
            transform.position = obj.transform.position;
        }
    }
}
