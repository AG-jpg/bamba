using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject pausePanel;
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }
}
