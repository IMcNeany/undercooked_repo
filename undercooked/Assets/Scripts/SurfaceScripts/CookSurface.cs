using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookSurface : ItemSurface {

    //no interact because you can pickup/place items/utensils whenever, the cooking happens when a utensil with food is added to the surface
    public ProgressionBar progress_bar;
    public override bool AddItem(GameObject obj)
    {
        
        if (obj.GetComponent<Utensil>())
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
                    progress_bar.gameObject.SetActive(true);
                    //start cooking if food is in the utensil
                    current_utensil.current_cooking_time += 1 * Time.deltaTime;
                    progress_bar.CalculateProgress(current_utensil.current_cooking_time, current_utensil.cook_time);

                    if (current_utensil.current_cooking_time >= current_utensil.cook_time)
                    {
                        for(int i = 0; i < current_utensil.current_food_items.Count; i++)
                        {
                            current_utensil.current_food_items[i].cooked = true;
                            current_utensil.current_food_items[i].GetComponent<SpriteRenderer>().sprite = current_utensil.current_food_items[i].preped_sprite;
                          
                        }
                    }
                    if(current_utensil.current_cooking_time > current_utensil.cook_time + 2)
                    {
                        progress_bar.gameObject.SetActive(false);
                    }

                    if (current_utensil.current_cooking_time >= current_utensil.burnt_timer)
                    {
                        for(int i = 0; i < current_utensil.current_food_items.Count; i++)
                        {
                            current_utensil.current_food_items[i].burnt = true;
                            current_utensil.current_food_items[i].GetComponent<SpriteRenderer>().color = Color.black;
                        }
                    }

                }
                else
                {
                    progress_bar.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            progress_bar.gameObject.SetActive(false);
        }

    }
}
