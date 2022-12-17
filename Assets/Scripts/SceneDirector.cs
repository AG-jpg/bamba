using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    public static SceneDirector instance;
    public GameObject vidasUI;
    public GameObject coinsUI;
    public GameObject player;
    public PlayerController controller;
    
    /// Awake is called when the script instance is being loaded.
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

    /// Start is called on the frame when a script is enabled just before
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    /// Update is called every frame, if the MonoBehaviour is enabled.
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if(scene.name == "Main")
        {
            StartGame();
        }else if(scene.name == "Menu")
        {
            vidasUI.SetActive(false);
            coinsUI.SetActive(false);
            player.SetActive(false);
        }else if(scene.name == "Inter")
        {
            vidasUI.SetActive(false);
            coinsUI.SetActive(false);
            player.SetActive(false);
        }else if(scene.name == "Game Over")
        {
            vidasUI.SetActive(false);
            coinsUI.SetActive(false);
            player.SetActive(false);
        }
    }

    public void StartGame()
    {
        controller.enabled = true;
        vidasUI.SetActive(true);
        coinsUI.SetActive(true);
    }
}
