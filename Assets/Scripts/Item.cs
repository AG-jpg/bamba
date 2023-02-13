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
            PlayerController.instance.AddLife();
        }

        Destroy(gameObject);
    }
}
