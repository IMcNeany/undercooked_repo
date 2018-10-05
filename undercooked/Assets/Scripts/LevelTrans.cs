using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTrans : MonoBehaviour
{
    private GameObject imortal_joe;

    private void ResetPCount()
    {
        imortal_joe = GameObject.FindGameObjectWithTag("GameController");
        imortal_joe.GetComponent<PlayerValToPass>().player = 0;
        imortal_joe.GetComponent<PlayerValToPass>().test = true;
    }

    public void NextLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void NextLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
        ResetPCount();
    }
}
