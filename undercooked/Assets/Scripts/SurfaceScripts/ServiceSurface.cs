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
            Utensil utensil = current_item.GetComponent<Utensil>();

            switch(utensil.type)
            {
                case UtensilType.Pan:
                case UtensilType.Pot:
                    return false;
                   
                case UtensilType.Plate:
                    current_item = obj;
                    return true; 
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
