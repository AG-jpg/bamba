using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject vidasUI;
    public PlayerController player;
    public Text textCoin;
    public int coins;
    public GameObject pausePanel;

    private void Awake() 
    {

        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this.gameObject);
        }
        
    }

    public void UpdateCoinCounter()
    {
        coins++;
        textCoin.text = coins.ToString();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void FinishPause()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Menu");
    }
}
