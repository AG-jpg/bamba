using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{
    public PlayerController player;
    public GameManager gamemanager;

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
            
            PositionHeart();
            PlayerController.instance.AddLife();
        }

        Destroy(gameObject);
    }

    public void PositionHeart()
    {
        
        if(player.vidas == 4)
        {
            GameManager.instance.ShowLifeFive();
        }
        else if(player.vidas == 3)
        {
            GameManager.instance.ShowLifeFour();
        }
        else if(player.vidas == 3)
        {
            GameManager.instance.ShowLifeThree();
        }
        else if(player.vidas == 2)
        {
            GameManager.instance.ShowLifeThree();
        }
        else if(player.vidas == 1)
        {
            GameManager.instance.ShowLifeTwo();
        }
    }
}
