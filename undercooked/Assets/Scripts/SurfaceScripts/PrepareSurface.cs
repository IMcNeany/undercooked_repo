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
                FoodItem food_item = current_item.GetComponent<FoodItem>();

                switch (food_item.type)
                {
                    case FoodType.Bun:
                    case FoodType.Chips:
                    case FoodType.Fish:
                    case FoodType.Meat:
                        //cant prepare these items, so pick em up
                        return true;
                    case FoodType.Lettuce:
                    case FoodType.Mushroom:
                    case FoodType.Onion:
                    case FoodType.Tomato:
                        //can prepare these items so continue
                        break;
                }
                if (food_item.prepared)
                {
                    return true;
                }
                else
                {
                    food_item.PrepareFood();
                    return false;
                }
            }
        }
        return true;
    }
}
