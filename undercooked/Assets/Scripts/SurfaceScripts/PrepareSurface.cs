using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareSurface : ItemSurface {


    public override bool Interact()
    {
        if(current_item)
        {
            if(current_item.GetComponent<FoodItem>())
            {
                FoodItem item = current_item.GetComponent<FoodItem>();
                if(item.prepared)
                {
                    return true;
                }
                else
                {
                    item.PrepareFood();
                    return false;
                }
            }
        }
        return true;
    }
}
