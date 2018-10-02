using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookSurface : ItemSurface {

    //no interact because you can pickup/place items/utensils whenever, the cooking happens when a utensil with food is added to the surface

    public override void Update()
    {
        base.Update();
        CookItems();
    }
    public void CookItems()
    {
        if(current_item.GetComponent<Utensil>())
        {
            Utensil current_utensil = current_item.GetComponent<Utensil>();

            if(current_utensil.current_food_items.Count > 0)
            {
                //start cooking if food is in the utensil
                current_utensil.cook_time -= 1 * Time.deltaTime;
                if (current_utensil.cook_time <= 0.0f)
                {
                    current_utensil.cooked = true;
                }
                else if(current_utensil.cook_time <= -5.0f)
                {
                    current_utensil.burnt = true;
                }
            } 
        }
    }
}
