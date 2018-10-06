using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingPrep : SurfaceInteraction
{
    public GameObject progressBar;
    int index = -1;
    // Use this for initialization
    void Start()
    {
        int index = -1;
        GameObject[] progressionChildren;
        int children = progressBar.transform.childCount;
        for (int i = 0; i < children; i++)
        {
           // progressionChildren[i] = progressBar.gameObject.GetChild(i);
           // progressionChildren[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        FoodItem food = item.gameObject.GetComponent<FoodItem>();

        if (itemHeld && food.prepared == false)
        {
            progressBar.SetActive(true);
        }
        else if (itemHeld && food.prepared == true)
        {
            progressBar.SetActive(false);
        }
    }
}