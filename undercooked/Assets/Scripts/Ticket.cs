using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ticket : MonoBehaviour {
    public List<Sprite> ticketImages;
    public List<Image> imageSetters;
    public List<bool> ticketImagesSet;
    public Utensil objectToCreate;
    // Use this for initialization
    void Start () {

       
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.activeSelf == false)
        {
            ticketImages.Clear();
            ticketImagesSet.Clear();
            for (int i = 0; i < ticketImages.Count; i++)
            {
                ticketImagesSet.Add(false);
            }
        }
	}

    private void OnEnable()
    {
        ticketImagesSet.Clear();
        for (int i = 0; i < imageSetters.Count; i++)
        {
            ticketImagesSet.Add(false);
        }
        SetImages();
    }

    protected void SetImages()
    {
        for(int i = 0; i < objectToCreate.allowed_foods.Count; i++)
        {
            for (int j = 0; j < ticketImagesSet.Count; j++)
            {
                if (objectToCreate.allowed_foods[i].type == FoodType.Bun)
                {
                    if(ticketImagesSet[j] == false)
                    {
                        ticketImages.Add(objectToCreate.current_food_items[i].GetComponent<SpriteRenderer>().sprite);
                        ticketImagesSet[j] = true;
                        break;
                    }
                   
                }
                if (objectToCreate.allowed_foods[i].type == FoodType.Lettuce)
                {
                    if (ticketImagesSet[j] == false)
                    {
                        ticketImages.Add(objectToCreate.current_food_items[i].GetComponent<SpriteRenderer>().sprite);
                        ticketImagesSet[j] = true;
                        break;
                    }

                }
                if (objectToCreate.allowed_foods[i].type == FoodType.Meat)
                {
                    if (ticketImagesSet[j] == false)
                    {
                        ticketImages.Add(objectToCreate.current_food_items[i].GetComponent<SpriteRenderer>().sprite);
                        ticketImagesSet[j] = true;
                        break;
                    }
                  
                }
                if (objectToCreate.allowed_foods[i].type == FoodType.Mushroom)
                {
                    if (ticketImagesSet[j] == false)
                    {
                        ticketImages.Add(objectToCreate.current_food_items[i].GetComponent<SpriteRenderer>().sprite);
                        ticketImagesSet[j] = true;
                        break;
                    }
                  
                }
                if (objectToCreate.allowed_foods[i].type == FoodType.Onion)
                {
                    if (ticketImagesSet[j] == false)
                    {
                        ticketImages.Add(objectToCreate.current_food_items[i].GetComponent<SpriteRenderer>().sprite);
                        ticketImagesSet[j] = true;
                        break;
                    }
                 
                }
                if (objectToCreate.allowed_foods[i].type == FoodType.Tomato)
                {
                    if (ticketImagesSet[j] == false)
                    {
                        ticketImages.Add(objectToCreate.current_food_items[i].GetComponent<SpriteRenderer>().sprite);

                        ticketImagesSet[j] = true;
                        break;
                    }
                    
                }
            }
        }

        for(int i = 0; i < imageSetters.Count; i++)
        {
            imageSetters[i].sprite = ticketImages[i];
        }
    }
}
