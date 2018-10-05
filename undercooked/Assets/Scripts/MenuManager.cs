using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Main Menu Swap")]
    public GameObject playerSelect;
    public GameObject levelSelect;
    [Header("Player Value to Pass")]
    public int player = 0;
    [Header("Check for Game Start")]
    public bool gameStart = false;

    public void singlePlayer()
    {
        playerSelect.gameObject.SetActive(false);
        levelSelect.gameObject.SetActive(true);
        gameStart = true;
        player = 1;
    }
    public void multiPlayer()
    {
        playerSelect.gameObject.SetActive(false);
        levelSelect.gameObject.SetActive(true);
        gameStart = true;
        player = 2;
    }
    public void level1()
    {
        if (gameStart == true)
        {
            SceneManager.LoadScene("Level1");
        }
        else
        {
            gameStart = false;
        }
    }
    public void level2()
    {
        if (gameStart == true)
        {
            SceneManager.LoadScene("Level2");
        }
        else
        {
            gameStart = false;
        }
    }
}
