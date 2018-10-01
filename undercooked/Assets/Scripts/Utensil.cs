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
    public FoodItem current_food;

    public override void PlaceObject(GameObject obj)
    {
        base.PlaceObject(obj);
        //nasty if else's
        if(obj.GetComponent<FoodItem>())
        {
            //check item then add to utensil
            
        }
        else if(obj.GetComponent<Product>())
        {
            //check if item can be added to product
        }
        else if(obj.GetComponent<Utensil>())
        {
            //adding cooked food to a plate
        }
        else
        {
            //add product to counter
        }
    }

    public void AddFood(FoodItem food)
    {
        //TO DO
        //lovely long switch statements for each type of utensil and what food can/cant be placed on it
    }

    public UtensilType GetUtensilType(Utensil utensil)
    {
        return utensil.type;
    }
}
