using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DayScript : MonoBehaviour
{
    public Transform Player;
    public int storksPerDay;
    public float gameOverTransitionTime;
    public TextMeshProUGUI text;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highscore;
    public int Day = 1;
    public int MaxDays;
    public int Storks;
    public float dayTranTime;
    public TextMeshProUGUI DayTranText;
    public Animator GameOver;
    public Animator DayTransition;
    public GameObject MainUI;
    public ScoreScript scoreScript;

    Vector3 StartPos;

    void Awake()
    {
        StartPos = Player.position;
        DayTranText.text = "Day " + Day.ToString();
        DayTransition.SetTrigger("NewDay");
    }

    IEnumerator dayTransition()
    {
        MainUI.SetActive(false);
        DayTranText.text = "Day " + Day.ToString();
        DayTransition.SetTrigger("EndDay");
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1);
        Player.position = StartPos;
        DayTransition.SetTrigger("NewDay");
        yield return new WaitForSecondsRealtime(dayTranTime);
        MainUI.SetActive(true);
        Time.timeScale = 1;
    }

    IEnumerator gameOver()
    {
        MainUI.SetActive(false);
        score.text = "Score: " + scoreScript.Score.ToString();
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
        GameOver.SetTrigger("GameOver");
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(gameOverTransitionTime);
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Storks >= storksPerDay)
        {
            Day++;
            Storks = 0;
            if (Day >= MaxDays)
            {
                StartCoroutine(gameOver());
                return;
            }
            StartCoroutine(dayTransition());
        }
        else
        {
            text.text = "Day " + Day;
        }
    }
}
