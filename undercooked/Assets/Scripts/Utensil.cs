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
    public float burnt_timer = 25.0f;

    public void Update()
    {
        for(int i = 0; i < current_food_items.Count; i++)
        {
            if(current_food_items[i])
            {
                current_food_items[i].gameObject.transform.position = transform.position;
            }
        }     
    }

    private void Start()
    {
        current_food_items.Sort(new CompareFoodItem());
    }


    public bool AddFood(FoodItem item)
    {
        if (current_food_items.Count < 4)
        {
            current_food_items.Add(item);
            item.gameObject.transform.parent = transform;
            current_food_items.Sort(new CompareFoodItem());
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

    class CompareFoodItem : IComparer<FoodItem>
    {
        public int Compare(FoodItem i1, FoodItem i2)
        {
            int type1 = i1 == null ? int.MinValue : (int)i1.type;
            int type2 = i2 == null ? int.MinValue : (int)i2.type;

            return type1.CompareTo(type2);
        }
    }

    public void ResetCookValues()
    {
        current_cooking_time = 0.0f;
    }
}
