using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public PlayerController player;
    public GameObject heart;
    public GameObject heartExtra;

    //Positions
    private Vector2 positionThree;
    private Vector2 positionTwo;
    private Vector2 positionOne;

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
            player.AddLife();
        }
        
        Destroy(gameObject);
    }

    public void PositionHeart()
    {
        positionThree = new Vector2(-760f, 372.4404f);
        positionTwo = new Vector2(-840f, 372.4404f);
        positionOne = new Vector2(-920f, 372.4404f);
        
        if(player.vidas == 4)
        {
            heartExtra.SetActive(true);
        }
        else if(player.vidas == 3)
        {
            heart.SetActive(true);
            heart.transform.localPosition = positionThree;
        }
        else if(player.vidas == 2)
        {
            heart.SetActive(true);
            heart.transform.localPosition = positionTwo;
        }
        else if(player.vidas == 1)
        {
            heart.SetActive(true);
            heart.transform.localPosition = positionOne;
        }
    }
}
