using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSurface : MonoBehaviour {

    public GameObject current_item;

    public virtual void Update()
    {
        if(current_item)
        {
            current_item.transform.position = transform.position;
        }
    }

    public virtual bool AddItem(GameObject obj)
    {
        current_item = obj;
        current_item.transform.position = transform.position;
        return true;
    }

    public virtual bool Interact(GameObject obj)
    {
        if (current_item != null)
        {
            if(current_item.GetComponent<Utensil>())
            {
                //if pickup obj is null, pickup the utensil
                if (obj != null)
                {
                    if (obj.GetComponent<FoodItem>())
                    {
                        if (FoodToUtenstil(obj, current_item))
                        {
                            return true;
                        }
                        return false;
                    }
                    
                }
            }
            else if(obj != null)
            {
                return false;
            }
        }
        return true;
    }

    public bool FoodToUtenstil(GameObject food_obj, GameObject utensil_obj)
    {
        FoodItem food = food_obj.GetComponent<FoodItem>();
        Utensil utensil = utensil_obj.GetComponent<Utensil>();
        if(utensil.allowed_foods[(int)food.type].allowed == true)
        {
            if(utensil.type == UtensilType.Plate)
            {
                if(food.prepared == true)
                {
                    if (utensil.AddFood(food))
                    {
                        return true;
                    }
                }
            }
            else if(utensil.type == UtensilType.Pan)
            {
                if (utensil.AddFood(food))
                {
                    return true;
                }
            }
            else if (utensil.type == UtensilType.Pot)
            {
                if(food.prepared == false)
                {
                    if (utensil.AddFood(food))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
