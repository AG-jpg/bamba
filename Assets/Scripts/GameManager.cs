using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject vidasUI;

    private void Awake() 
    {
        instance = this;
    }
}
