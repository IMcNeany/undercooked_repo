using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValToPass : MonoBehaviour {

    public int player = 0;
    public GameObject menuManager;
    private GameObject player_2;
    public bool test = true;

	// Use this for initialization
	void Awake () {
        if(GameObject.FindGameObjectsWithTag("GameController").Length == 1)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        menuManager = GameObject.FindGameObjectWithTag("MenuManager");
		if(menuManager)
        {
            player = menuManager.GetComponent<MenuManager>().player;
        }
        else if(player == 2 && test)
        {
            player_2 = Instantiate(GameObject.FindGameObjectWithTag("Player"));
            player_2.GetComponent<InputManager>().playerNumber = 2;
            test = false;
        }
	}
}
