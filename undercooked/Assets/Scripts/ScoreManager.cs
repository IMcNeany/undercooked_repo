using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("Score Values")]
    public Text scoreText; //Showing current score
    public Text highScoreText; //Showing current high score
    public float scoreCount; //score value
    public float highScoreCount; //highscore value
    private float pointsPerSecond = 1; //increase in score per second (may be irrelevant)
    public bool scoreIncreasing; //check score is increasing (may be irrelevant)

    [Header("Score Values for Cooking")]
    public bool[] addScore; //check to add the base value
    public float[] baseValue; //current score of the ticket
    public GameObject[] ticket; //ref of the tickets
    public int t_count = 4; //total ticket count

    [Header("Count Down Values")]
    [SerializeField]
    private Text uiText;
    [SerializeField]
    private float mainTimer = 100.0f;
    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    [Header("End Card")]
    public bool gameOver = false;
    public GameObject gameUI;
    public GameObject endCard;
    public Text endScoreT;
    public Text endHScoreT;
    public GameObject oneStar;
    public GameObject twoStar;
    public GameObject threeStar;

    // Use this for initialization
    void Start()
    {
        timer = mainTimer;
        gameUI.gameObject.SetActive(true);
        endCard.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GameTimer();

        t_count = GameObject.FindGameObjectsWithTag("Ticket").Length;
        ReduceItemValue();

        FormatTimer();

        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }
        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
        }

        DisplayText();

        if (gameOver) //spawns end card
        {
            EndCardUI();
        }
    }

    private void GameTimer()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= 1 * Time.deltaTime;
            uiText.text = timer.ToString("F");
            gameOver = false;
        }
        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0.00";
            timer = 0.0f;
            gameOver = true;
        }
    }

    private void ReduceItemValue()
    {
        for (int i = 0; i < 4; i++)
        {
            if (ticket[i].activeInHierarchy)
            {
                baseValue[i] -= pointsPerSecond * Time.deltaTime;

                if(baseValue[i] <= 0)
                {
                    baseValue[i] = 0;
                    ticket[i].SetActive(false);
                    this.gameObject.GetComponent<ServiceGoal>().service[i] = false;
                    this.gameObject.GetComponent<ServiceGoal>().RemoveGoalItem(i);
                    baseValue[i] = 100.0f;
                }

                if (addScore[i])
                {
                    scoreCount += baseValue[i];
                    baseValue[i] = 100.0f;
                    addScore[i] = false;
                    ticket[i].SetActive(false);
                    this.gameObject.GetComponent<ServiceGoal>().service[i] = false;
                }
            }
        }
    }

    private void FormatTimer()
    {
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");
        uiText.text = "Time Left: " + minutes + " : " + seconds;
    }

    private void EndCardUI()
    {
        gameUI.gameObject.SetActive(false);
        endCard.gameObject.SetActive(true);
        scoreCount = Mathf.RoundToInt(scoreCount);

        if (scoreCount >= 200)
        {
            oneStar.gameObject.SetActive(true);
        }
        if (scoreCount >= 400)
        {
            twoStar.gameObject.SetActive(true);
        }
        if (scoreCount >= 500)
        {
            threeStar.gameObject.SetActive(true);
        }
    }

    private void DisplayText()
    {
        //display score values vvv
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);
        //itemTest.text = "Value = " + Mathf.Round(baseValue);
        endScoreT.text = "Score: " + Mathf.Round(scoreCount);
        endHScoreT.text = "Highscore: " + Mathf.Round(highScoreCount);
    }
}

