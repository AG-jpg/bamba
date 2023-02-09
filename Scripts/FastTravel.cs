using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FastTravel : MonoBehaviour
{
    public GameObject travelPanel;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            ShowTravel();
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            RestartGame();
        }
    }

    public void ShowTravel()
    {
        travelPanel.SetActive(true);
    }

    public void RestartGame()
    {
        travelPanel.SetActive(false);
    }
}
