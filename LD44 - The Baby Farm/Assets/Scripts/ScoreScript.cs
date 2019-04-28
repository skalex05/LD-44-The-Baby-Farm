using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public int Score;
    public TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Score > PlayerPrefs.GetInt("Highscore",0))
        {
            PlayerPrefs.SetInt("Highscore", Score);
        }
        Text.text = Score.ToString();
    }
}
