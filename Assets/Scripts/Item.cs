using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            AssignItem();
        }
    }

    private void AssignItem()
    {
        if(gameObject.CompareTag("Coin"))
        {
            GameManager.instance.UpdateCoinCounter();
        }else if(gameObject.CompareTag("Life"))
        {
            player.AddLife();
        }
        
        Destroy(gameObject);
    }
}
