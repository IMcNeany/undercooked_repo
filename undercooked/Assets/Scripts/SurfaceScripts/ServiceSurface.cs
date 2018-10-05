using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceSurface : ItemSurface {

    public override void AddItem(GameObject obj)
    {
        CheckItem(obj);
    }

    public void CheckItem(GameObject obj)
    {
        if(obj.GetComponent<Utensil>())
        {
            Utensil utensil = current_item.GetComponent<Utensil>();

            switch(utensil.type)
            {

                case UtensilType.Pan:
                    break;
                case UtensilType.Pot:
                    break;

                case UtensilType.Plate:
                    current_item = obj;
                    break;    
            }
        }
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
