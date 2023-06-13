using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactArea : MonoBehaviour
{
    private bool makesDamage;
    private bool isDetecting;
    private PlayerController player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public bool GetMakesDamage()
    {
        return makesDamage;
    }

    public void SetMakesDamage(bool newMakesDamage)
    {
        makesDamage = newMakesDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isDetecting = true;
            //makesDamage = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isDetecting = false;
        }
    }

    void Update()
    {
        if (isDetecting)
        {
            player.RecibirDano((transform.position - player.transform.position).normalized);
        }

        makesDamage = false;
    }
}
