using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceGoal : MonoBehaviour {

    public List<Utensil> goal_list;

    public List<Utensil> reference_list;

    public float service_item_timer = 10.0f;
    public float current_timer = 10.0f;

    private void Update()
    {
        current_timer += 1 * Time.deltaTime;
        if(current_timer >= service_item_timer)
        {
            AddNewGoal();
            current_timer = 0.0f;
        }

        if(Input.GetKeyDown(KeyCode.J))
        {
            //test
            goal_list.RemoveAt(goal_list.Count - 1);
        }
    }

    public void AddNewGoal()
    {
        if(reference_list.Count < 4)
        {
            int random_num = Random.Range(0, reference_list.Count);
            goal_list.Add(reference_list[random_num]);
        }
    }

    public bool CheckAddedItem(Utensil item)
    {
        for(int i = 0; i < goal_list.Count; i++)
        {
            if(item.type == goal_list[i].type)
            {
                if (item.current_food_items.Count == goal_list[i].current_food_items.Count)
                {
                    for (int y = 0; y < goal_list[i].current_food_items.Count; y++)
                    {
                        if (item.current_food_items[y].type != goal_list[i].current_food_items[y].type)
                        {
                            RemoveGoalItem(i);
                            return false;
                        }
                    }
                    return true;
                }
            }
        }
        return false;
    }

    public void RemoveGoalItem(int num)
    {
        goal_list.RemoveAt(num);
    }

}
