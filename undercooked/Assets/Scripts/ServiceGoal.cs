using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServiceGoal : MonoBehaviour {

    public List<Utensil> goal_list;

    public List<Utensil> reference_list;

    public float service_item_timer = 10.0f;
    public float current_timer = 10.0f;

    public GameObject[] uiboxes;
    public bool[] service;

    private void Start()
    {
        for (int i = 0; i < uiboxes.Length; i++)
        {
            uiboxes[i].gameObject.SetActive(false);
        }
    }

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
        if (Input.GetKey(KeyCode.K))
        {
            //cheat for completing service (service bool's on inspector)
            for (int j = 0; j < 4; j++)
            {
                if (service[j])
                {
                    this.gameObject.GetComponent<ScoreManager>().addScore[j] = true;
                    RemoveGoalItem(j);
                }
            }
        }
    }

    public void AddNewGoal()
    {
        int next_empty_slot = 0;
        for (int i = 0; i < 4; i++)
        {
            if (!uiboxes[i].activeInHierarchy)
            {
                uiboxes[i].SetActive(true);
                next_empty_slot = i;
                break;
            }
        }
        if (goal_list.Count < 4)
        {
            int random_num = Random.Range(0, reference_list.Count);
            goal_list.Add(reference_list[random_num]);

            Text temp = uiboxes[next_empty_slot].GetComponentInChildren<Text>();

            temp.text = reference_list[random_num].gameObject.name;
           
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
                            
                            return false;
                        }
                    }
                    gameObject.GetComponent<ScoreManager>().addScore[i] = true;
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
