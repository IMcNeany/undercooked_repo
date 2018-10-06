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
    public int prepare_counter = 3;

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
            prepare_counter -= 1;
            if(prepare_counter <= 0)
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
