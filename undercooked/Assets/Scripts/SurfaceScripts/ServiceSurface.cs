using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceSurface : ItemSurface {

    public override bool AddItem(GameObject obj)
    {
        return CheckItem(obj);
    }

    public bool CheckItem(GameObject obj)
    {
        if(obj.GetComponent<Utensil>())
        {
            Utensil utensil = obj.GetComponent<Utensil>();

            switch(utensil.type)
            {
                case UtensilType.Pan:
                case UtensilType.Pot:
                    return false;
                   
                case UtensilType.Plate:
                    if(utensil.current_food_items.Count > 0)
                    {
                        current_item = obj;
                        return true;
                    }
                    return false;
            }
        }
        return false;
    }

    public override void Update()
    {
        base.Update();
        if(current_item)
        {
            //code here to check order for items they pass in and assign points
        }
    }
}
