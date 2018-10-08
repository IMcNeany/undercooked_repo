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
    //public bool itemGet = false; //begins value countdown
    //public Text itemTest; //Showing value decrease (test)
    //public bool[] addScore = { false, false, false, false };
    //public float[] baseValue; //base value of a recipe
    //public GameObject[] tickets;
    //public int ticketCount; //number of active tickets

    public bool[] addScore;
    public float[] baseValue;
    public GameObject[] ticket;
    public int t_count = 4;

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

    private void ReduceItemValue() //[0,0,1,0]
    {
        for(int i = 0; i < 4; i++)
        {
            if(ticket[i].activeInHierarchy)
            {
                baseValue[i] -= pointsPerSecond * Time.deltaTime;
                
                if(addScore[i])
                {
                    scoreCount += baseValue[i];
                    baseValue[i] = 100.0f;
                    addScore[i] = false;
                    ticket[i].SetActive(false);
                    this.gameObject.GetComponent<ServiceGoal>().service[i] = false;
                }
            }
        }

        //for (int i = 0; i < ticketCount; i++) //check for each T
        //{
        //    if (tickets[i].activeInHierarchy) //if active
        //    {
        //        baseValue[i] -= pointsPerSecond * Time.deltaTime; //reduce count

        //        if (addScore[i] == true) //if complete
        //        {
        //            scoreCount = scoreCount + baseValue[i];
        //            addScore[i] = false;
        //            itemGet = false;
        //            tickets[i].SetActive(false);
        //            //addScore, set checks to ! disable T
        //        }
        //    }
        //}

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

        if (scoreCount >= 100)
        {
            oneStar.gameObject.SetActive(true);
        }
        if (scoreCount >= 200)
        {
            twoStar.gameObject.SetActive(true);
        }
        if (scoreCount >= 300)
        {
            threeStar.gameObject.SetActive(true);
        }
    }

    private void DisplayText()
    {
        //display score values vvv
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);
        //itemTest.text = "Value = " + Mathf.Round(baseValue[0]);
        endScoreT.text = "Score: " + Mathf.Round(scoreCount);
        endHScoreT.text = "Highscore: " + Mathf.Round(highScoreCount);
    }
}

