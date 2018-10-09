using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceSurface : ItemSurface {

    public ScoreManager score_manager;
    public ServiceGoal service_goal;

    public AudioClip incorrect;
    public AudioClip correct;

    private AudioSource audio;

    public void Start()
    {
        audio = GetComponent<AudioSource>();
        service_goal = GameObject.Find("ScoreManager").GetComponent<ServiceGoal>();
    }

    public override bool AddItem(GameObject obj)
    {
        return CheckItem(obj);
    }

    public bool CheckItem(GameObject obj)
    {
        if(obj.GetComponent<Utensil>())
        {
            Utensil utensil = obj.GetComponent<Utensil>();

            switch(utensil.type)
            {
                case UtensilType.Pan:
                case UtensilType.Pot:
                    return false;
                   
                case UtensilType.Plate:
                    if(utensil.current_food_items.Count > 0)
                    {
                        current_item = obj;
                        return true;
                    }
                    return false;
            }
        }
        return false;
    }

    public override void Update()
    {
        base.Update();
        if(current_item)
        {
            if (current_item.GetComponent<Utensil>())
            {
                if(service_goal.CheckAddedItem(current_item.GetComponent<Utensil>()))
                {
                    audio.clip = correct;
                    audio.Play();
                    Destroy(current_item);
                }
                else
                {
                    audio.clip = incorrect;
                    audio.Play();
                    Destroy(current_item);
                }
            }
        }
    }
}
