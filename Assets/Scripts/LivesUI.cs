using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public PlayerController player;

    [Header("Hearts")]
    public GameObject[] hearts;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    //Heart Position
    public void PositionHeart()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(player.vidas > i);
        }
    }
}