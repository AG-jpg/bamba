using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject ziman;
    private PlayerController player;
    private BoxCollider2D bc;
    public bool IsPaused;
    public bool chat;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        bc = GetComponent<BoxCollider2D>();
        ziman.SetActive(true);
        IsPaused = false;
        chat = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            chat = true;
        }
    }

    private void Update()
    {
        if (IsPaused)
        {
            Time.timeScale = 0;
            TakeAction();
        }

        if(chat && Input.GetKeyDown(KeyCode.DownArrow))
        {
            Time.timeScale = 0;
            Talk();
        }
    }

    public void Talk()
    {
        dialogueBox.SetActive(true);
        IsPaused = true;
    }

    private void TakeAction()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Time.timeScale = 1;
            IsPaused = false;
            chat = false;
            dialogueBox.SetActive(false);
            ziman.SetActive(false);
            player.AddLife();
            Destroy(bc);
        }
    }
}
