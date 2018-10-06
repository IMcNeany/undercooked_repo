using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UtensilType
{
    Plate,
    Pan,
    Pot
};

[System.Serializable]
public class AllowedFood
{
    public FoodType type;
    public bool allowed;
}

public class Utensil : Pickup {

    public UtensilType type;
    public List<AllowedFood> allowed_foods;
    public List<FoodItem> current_food_items;
    public float cook_time = 10.0f;
    public float current_cooking_time = 0.0f;
    public bool cooked = false;
    public bool burnt = false;
    public float burnt_timer = 15.0f;

    public void Update()
    {
        for(int i = 0; i < current_food_items.Count; i++)
        {
            current_food_items[i].gameObject.transform.position = transform.position;
        }
    }

    public bool AddFood(FoodItem item)
    {
        if (current_food_items.Count < 3)
        {
            current_food_items.Add(item);
            return true;
        }
        return false;
    }

    public void EmptyFood()
    {
        current_food_items.Clear();
    }

    public UtensilType GetUtensilType(Utensil utensil)
    {
        return utensil.type;
    }
}
