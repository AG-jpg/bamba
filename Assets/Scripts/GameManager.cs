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
    public Item item;
    public GameObject pausePanel;

    [Header("Coins Panel")]
    public int coins;
    public Text textCoin;

    [Header("Audio")]
    private AudioSource audioSource;
    [SerializeField] private AudioClip chimes;

     private void Awake() 
    {

        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this.gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void UpdateCoinCounter()
    {
        coins++;
        textCoin.text = coins.ToString();
    }

    public void CoinLife()
    {
        if(coins == 100)
        {
            audioSource.PlayOneShot(chimes);
            item.PositionHeart();
            player.AddLife();
            coins = 0;
        }
    }

    /// Update is called every frame, if the MonoBehaviour is enabled.
    private void Update()
    {
        CoinLife();
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

    public void CoinCountRestart()
    {
        coins = 0;
        textCoin.text = coins.ToString();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}