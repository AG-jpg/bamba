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

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        bc = GetComponent<BoxCollider2D>();
        ziman.SetActive(true);
        IsPaused = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
                dialogueBox.SetActive(true);
                IsPaused = true;
        }
    }

    private void Update()
    {
        if(IsPaused)
        {
            Time.timeScale = 0;
            TakeAction();
        }
    }


       private void TakeAction()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Time.timeScale = 1;
            IsPaused = false;
            dialogueBox.SetActive(false);
            ziman.SetActive(false);
            player.AddLife();
            Destroy(bc);
        }
    }
}
