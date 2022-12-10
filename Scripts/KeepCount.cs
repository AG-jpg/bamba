using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepCount : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
