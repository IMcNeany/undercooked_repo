using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public int playerNumber = 1;

    private float Horizontal = 0.0f;
    private float Vertical = 0.0f;
    public bool actionKey;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float keyH = Input.GetAxis("Horizontal_" + playerNumber);
        float keyV = Input.GetAxis("Vertical_" + playerNumber);

        if (keyH != 0 || keyV != 0)
        {
            Horizontal = keyH;
            Vertical = keyV;
        }
        else
        {
            Horizontal = Input.GetAxis("Joy_Horizontal_" + playerNumber);
            Vertical = Input.GetAxis("Joy_Vertical_" + playerNumber);
        }

        actionKey = Input.GetButton("Action_" + playerNumber);

        Debug.Log(new Vector2(Horizontal, Vertical));
    }

    public float getHorizontal()
    {
        return Horizontal;
    }

    public float getVertical()
    {
        return Vertical;
    }
}