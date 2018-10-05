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
    public float baseValue = 100.0f; //base value of a recipe
    public bool itemGet = false; //begins value countdown
    public Text itemTest; //Showing value decrease (test)
    public bool addScore = false;

    [Header("Count Down Values")]
    [SerializeField]
    private Text uiText;
    [SerializeField]
    private float mainTimer;
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

        if (itemGet == true) //decreases value of recipe over time
        {
            baseValue = baseValue -= pointsPerSecond * Time.deltaTime;

            if (addScore == true)
            {
                scoreCount = scoreCount + baseValue;
                baseValue = 100;
                addScore = false;
                itemGet = false;
            }
        }

        // timer -= 1* Time.deltaTime;
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");
        uiText.text = "Time Left: " + minutes + " : " + seconds;

        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }
        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
        }

        //display score values vvv
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);
        itemTest.text = "Value = " + Mathf.Round(baseValue);
        endScoreT.text = "Score: " + Mathf.Round(scoreCount);
        endHScoreT.text = "Highscore: " + Mathf.Round(highScoreCount);

        if (gameOver == true) //spawns end card
        {
            gameUI.gameObject.SetActive(false);
            endCard.gameObject.SetActive(true);

            //I know the following looks like cancer... i'll clean it up after Friday merge
            if (scoreCount >= 0 && scoreCount <= 99) //No stars
            {
                oneStar.gameObject.SetActive(false);
                twoStar.gameObject.SetActive(false);
                threeStar.gameObject.SetActive(false);
            }
            if (scoreCount >= 100 && scoreCount <= 199) //One star
            {
                oneStar.gameObject.SetActive(true);
                twoStar.gameObject.SetActive(false);
                threeStar.gameObject.SetActive(false);
            }
            if (scoreCount >= 200 && scoreCount <= 299) //Two star
            {
                oneStar.gameObject.SetActive(true);
                twoStar.gameObject.SetActive(true);
                threeStar.gameObject.SetActive(false);
            }
            if (scoreCount >= 300) //Three star
            {
                oneStar.gameObject.SetActive(true);
                twoStar.gameObject.SetActive(true);
                threeStar.gameObject.SetActive(true);
            }
        }


    }
}

