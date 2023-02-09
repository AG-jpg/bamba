using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRepeat : MonoBehaviour
{
    public AudioListener listener;
    
   private void Awake() 
    {
        listener = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioListener>();

        if(listener.enabled == true)
        {
            Console.Write("There is a Listener");
        } else
        {
            listener.enabled = false;
        }
    }
}
