using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject ziman;
    private PlayerController player;
    private BoxCollider2D bc;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        bc = GetComponent<BoxCollider2D>();
        ziman.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            dialogueBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            dialogueBox.SetActive(false);
            ziman.SetActive(false);
            player.AddLife();
            Destroy(bc);
        }

    }
}
