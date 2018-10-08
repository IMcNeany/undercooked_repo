using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FoodType
{
    Bun,
    Meat,
    Lettuce,
    Tomato,
    Onion,
    Mushroom,
};


public class FoodItem : Pickup {

    public FoodType type;
    public bool prepared = false;
    public bool cooked = false;
    public bool burnt = false;
    public int prepare_counter = 3;
    private int current_prepared = 0;
    public Sprite unpreped_sprite;
    public Sprite preped_sprite;


    public void SetPrepared()
    {
        prepared = true;
        pickup_sprite = preped_sprite;
    }


    public void PrepareFood()
    {
        if(!prepared)
        {
            current_prepared += 1;
            if(current_prepared >= prepare_counter)
            {
                SetPrepared();
            }
        }
    }

    public FoodType GetFoodType(FoodItem food)
    {
        return food.type;
    }
    
    
}
