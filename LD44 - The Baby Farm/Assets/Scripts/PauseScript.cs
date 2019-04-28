using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Resume()
    {
        print("Resume");
        if (paused && Time.timeScale == 0)
        {
            PauseUI.SetActive(false);
            paused = false;
            Time.timeScale = 1;
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    bool paused;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!paused && Time.timeScale == 1)
            {
                PauseUI.SetActive(true);
                paused = true;
                Time.timeScale = 0;
            }
            else if (paused && Time.timeScale == 0)
            {
                PauseUI.SetActive(false);
                paused = false;
                Time.timeScale = 1;
            }
        }
    }
}
