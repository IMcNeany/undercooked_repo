using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
        public int player = 0;
public void Player1()
    {
        SceneManager.LoadScene("Level1");
        player = 1;
    }
  public void Player2()
    {
        SceneManager.LoadScene("Level2");
        player = 2;
    }
}
