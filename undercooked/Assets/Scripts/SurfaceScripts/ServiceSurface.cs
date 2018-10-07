using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceSurface : ItemSurface {

    public ServiceGoal service_goal;

    public void Start()
    {
        service_goal = GameObject.Find("ScoreManager").GetComponent<ServiceGoal>();
    }

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
            if (current_item.GetComponent<Utensil>())
            {
                if(service_goal.CheckAddedItem(current_item.GetComponent<Utensil>()))
                {
                    Debug.Log("yeet");
                    Destroy(current_item);
                }
                else
                {
                    Debug.Log("Nope");
                    Destroy(current_item);
                }
            }
        }
    }
}
