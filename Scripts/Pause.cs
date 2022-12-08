using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            PauseGame();
        }
    }

        public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
}
