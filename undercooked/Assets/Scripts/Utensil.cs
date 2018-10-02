using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UtensilType
{
    Plate,
    Pan,
    Pot
};

public class Utensil : Pickup {

    public UtensilType type;
    public List<FoodItem> current_food_items;
    public float cook_time = 10.0f;
    public bool cooked = false;
    public bool burnt = false;
    public float burnt_timer = -5.0f;


    public UtensilType GetUtensilType(Utensil utensil)
    {
        return utensil.type;
    }
}
