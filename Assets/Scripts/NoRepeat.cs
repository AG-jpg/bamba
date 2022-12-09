using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRepeat : MonoBehaviour
{
    public static NoRepeat instance;
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
}
