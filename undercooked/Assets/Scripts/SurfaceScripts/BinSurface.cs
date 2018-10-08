using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinSurface : ItemSurface {


    public override bool AddItem(GameObject obj)
    {
        if(obj.GetComponent<Utensil>())
        {
            Utensil utensil = obj.GetComponent<Utensil>();
            for(int i = 0; i < utensil.current_food_items.Count; i++)
            {
                utensil.current_food_items.RemoveAt(i);
            }
            foreach (Transform child in obj.transform)
            {
                Destroy(child.gameObject);
            }
        }
        else
        {
            Destroy(obj);
        }
        return false;
    }
}
