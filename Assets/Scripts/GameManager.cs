using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject vidasUI;
    public PlayerController player;
    public Text textCoin;
    public int coins;

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
}
