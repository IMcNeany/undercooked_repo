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
    Fish,
    Chips
};


public class FoodItem : Pickup {

    public FoodType type;
    public bool prepared = false;
    public float prepare_timer = 3.0f;

    public Sprite unpreped_sprite;
    public Sprite preped_sprite;


    public void SetPrepared()
    {
        prepared = true;
        pickup_sprite = preped_sprite;
    }

    public void Interact()
    {
        if(!prepared)
        {
            prepare_timer -= 1 * Time.deltaTime;
            if(prepare_timer <= 0.0f)
            {
                SetPrepared();
                prepare_timer = 0.0f;
            }
        }
    }

    public override void PlaceObject(GameObject obj)
    {
        //To do add utensil stuff
        base.PlaceObject(obj);

        //temporary function until counters/player/endgoal is added

        //if obj is empty

        //add obj

        //else


        if (obj.GetComponent<FoodItem>())
        {

            FoodItem obj_item = obj.GetComponent<FoodItem>();
            if (prepared && obj_item.prepared)
            {
                //if the placement already has a prepared item, combine to make a product
                //then delete the two items after product has been made
                GameObject product_obj = Instantiate(Resources.Load("Product Prefab"), obj.transform.position, obj.transform.rotation) as GameObject;

                Product product = product_obj.GetComponent<Product>();
                product.AddItem(obj_item.type);
                product.AddItem(type);

                Destroy(obj_item.gameObject);
                Destroy(gameObject);
            }
        }
        else if (obj.GetComponent<Product>() && prepared)
        {
            //if placement has a product, add item to it
            obj.GetComponent<Product>().AddItem(type);
            Destroy(gameObject);
        }
        else
        {
            //add food to counter
            transform.position = obj.transform.position;
        }
    }

    public FoodType GetFoodType(FoodItem food)
    {
        return food.type;
    }
    
    
}
