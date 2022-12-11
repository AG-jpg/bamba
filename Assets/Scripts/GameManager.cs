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
    public GameObject pausePanel;

    [Header("Coins Panel")]
    public int coins;
    public Text textCoin;

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

    public void FinishPause()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}