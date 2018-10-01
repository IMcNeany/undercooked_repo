using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
        public int player = 0;
public void Player1()
    {
        Application.LoadLevel("Game");
        player = 1;
    }
  public void Player2()
    {
        Application.LoadLevel("Game");
        player = 2;
    }
}
