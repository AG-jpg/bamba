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
    public GameObject Heart6;
    public GameObject Heart7;
    public GameObject Heart8;
    public GameObject Heart9;
    public GameObject Heart10;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    //Heart Position
    public void PositionHeart()
    {
        switch (player.vidas)
        {
            case 10:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(true);
                Heart5.SetActive(true);
                Heart6.SetActive(true);
                Heart7.SetActive(true);
                Heart8.SetActive(true);
                Heart9.SetActive(true);
                Heart10.SetActive(true);
                break;

            case 9:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(true);
                Heart5.SetActive(true);
                Heart6.SetActive(true);
                Heart7.SetActive(true);
                Heart8.SetActive(true);
                Heart9.SetActive(true);
                Heart10.SetActive(false);
                break;

            case 8:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(true);
                Heart5.SetActive(true);
                Heart6.SetActive(true);
                Heart7.SetActive(true);
                Heart8.SetActive(true);
                Heart9.SetActive(false);
                Heart10.SetActive(false);
                break;

            case 7:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(true);
                Heart5.SetActive(true);
                Heart6.SetActive(true);
                Heart7.SetActive(true);
                Heart8.SetActive(false);
                Heart9.SetActive(false);
                Heart10.SetActive(false);
                break;

            case 6:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(true);
                Heart5.SetActive(true);
                Heart6.SetActive(true);
                Heart7.SetActive(false);
                Heart8.SetActive(false);
                Heart9.SetActive(false);
                Heart10.SetActive(false);
                break;

            case 5:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(true);
                Heart5.SetActive(true);
                Heart6.SetActive(false);
                Heart7.SetActive(false);
                Heart8.SetActive(false);
                Heart9.SetActive(false);
                Heart10.SetActive(false);
                break;

            case 4:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(true);
                Heart5.SetActive(false);
                Heart6.SetActive(false);
                Heart7.SetActive(false);
                Heart8.SetActive(false);
                Heart9.SetActive(false);
                Heart10.SetActive(false);
                break;

            case 3:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(false);
                Heart5.SetActive(false);
                Heart6.SetActive(false);
                Heart7.SetActive(false);
                Heart8.SetActive(false);
                Heart9.SetActive(false);
                Heart10.SetActive(false);
                break;

            case 2:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(false);
                Heart4.SetActive(false);
                Heart5.SetActive(false);
                Heart6.SetActive(false);
                Heart7.SetActive(false);
                Heart8.SetActive(false);
                Heart9.SetActive(false);
                Heart10.SetActive(false);
                break;

            case 1:
                Heart1.SetActive(true);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                Heart4.SetActive(false);
                Heart5.SetActive(false);
                Heart6.SetActive(false);
                Heart7.SetActive(false);
                Heart8.SetActive(false);
                Heart9.SetActive(false);
                Heart10.SetActive(false);
                break;

            case 0:
                Heart1.SetActive(false);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                Heart4.SetActive(false);
                Heart5.SetActive(false);
                Heart6.SetActive(false);
                Heart7.SetActive(false);
                Heart8.SetActive(false);
                Heart9.SetActive(false);
                Heart10.SetActive(false);
                break;
        }
    }
}
