using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public PlayerController player;

    [Header("Hearts")]
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;
    public GameObject Heart5;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

 //Heart Position
    public void PositionHeart()
    {

        if (player.vidas == 5)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
            Heart4.SetActive(true);
            Heart5.SetActive(true);
        }
        else if (player.vidas == 4)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
            Heart4.SetActive(true);
            Heart5.SetActive(false);
        }
        else if (player.vidas == 3)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
            Heart4.SetActive(false);
            Heart5.SetActive(false);
        }
        else if (player.vidas == 2)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(false);
            Heart4.SetActive(false);
            Heart5.SetActive(false);
        }
        else if (player.vidas == 1)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
            Heart4.SetActive(false);
            Heart5.SetActive(false);
        }
        else if (player.vidas == 0)
        {
            Heart1.SetActive(false);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
            Heart4.SetActive(false);
            Heart5.SetActive(false);
        }
    }
}
