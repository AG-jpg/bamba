using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactArea : MonoBehaviour
{
    private bool makesDamage;
    private bool isDetecting;

    public bool GetMakesDamage()
    {
        return makesDamage;
    }

    public void SetMakesDamage(bool newmakesDamage)
    {
        makesDamage = newmakesDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("player"))
        {
            isDetecting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("player"))
        {
            isDetecting = false;
        }
    }

    void Update()
    {
        if(makesDamage)
        {
            if(isDetecting)
            {
                GameManager.instance.player.RecibirDano();
            }

            makesDamage = false;
        }
    }
}
