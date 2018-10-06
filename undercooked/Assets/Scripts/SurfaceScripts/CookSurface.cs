﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookSurface : ItemSurface {

    //no interact because you can pickup/place items/utensils whenever, the cooking happens when a utensil with food is added to the surface

    public override bool AddItem(GameObject obj)
    {
        if(obj.GetComponent<Utensil>())
        {
            if (obj.GetComponent<Utensil>().type != UtensilType.Plate)
            {
                base.AddItem(obj);
                return true;
            }
        }
        return false;
    }

    public override void Update()
    {
        base.Update();
        CookItems();
    }
    public void CookItems()
    {
        if (current_item)
        {
            if (current_item.GetComponent<Utensil>())
            {
                Utensil current_utensil = current_item.GetComponent<Utensil>();
                
                if (current_utensil.current_food_items.Count > 0)
                {
                    //start cooking if food is in the utensil
                    current_utensil.current_cooking_time += 1 * Time.deltaTime;
                    if (current_utensil.current_cooking_time >= current_utensil.cook_time)
                    {
                        current_utensil.cooked = true;
                    }
                    else if (current_utensil.current_cooking_time >= current_utensil.burnt_timer)
                    {
                        current_utensil.burnt = true;
                    }
                }
            }
        }
    }
}
