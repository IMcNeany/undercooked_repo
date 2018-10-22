using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareSurface : ItemSurface {

    public AudioClip chopping;
    public ProgressionBar progressBar;
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public override bool AddItem(GameObject obj)
    {
        if(!obj.GetComponent<FoodItem>())
        {
            return false;
        }
        else
        {
            return base.AddItem(obj);
        }
    }

    public override bool Interact(GameObject obj)
    {
        if (current_item)
        {
            if (current_item.GetComponent<FoodItem>())
            {
                FoodItem food_item = current_item.GetComponent<FoodItem>();

                switch (food_item.type)
                {
                    case FoodType.Bun:
                    case FoodType.Meat:
                        //cant prepare these items, so pick em up
                        return true;
                    case FoodType.Lettuce:
                    case FoodType.Mushroom:
                    case FoodType.Onion:
                    case FoodType.Tomato:
                        //can prepare these items so continue
                        progressBar.gameObject.SetActive(true);
                        break;
                }
                if (food_item.prepared)
                {
                    progressBar.gameObject.SetActive(false);
                    return true;
                }
                else
                {
                    progressBar.CalculateProgress(food_item.GetCurrentPrep(), food_item.prepare_counter);
                    audio.clip = chopping;
                    audio.Play();
                    food_item.PrepareFood();
                    return false;
                }
            }
        }
        return true;
    }
}
