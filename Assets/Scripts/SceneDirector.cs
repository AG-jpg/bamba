using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    public GameObject vidasUI;
    public GameObject coinsUI;
    
    /// Awake is called when the script instance is being loaded.
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    /// Update is called every frame, if the MonoBehaviour is enabled.
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if(scene.name == "Menu")
        {
            vidasUI.SetActive(false);
            coinsUI.SetActive(false);
        }else if(scene.name == "Inter")
        {
            vidasUI.SetActive(false);
            coinsUI.SetActive(false);
        }else if(scene.name == "Game Over")
        {
            vidasUI.SetActive(false);
            coinsUI.SetActive(false);
        }
    }
}
