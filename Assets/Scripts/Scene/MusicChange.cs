using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChange : MonoBehaviour
{
    public GameObject dialogueBox;
    private BoxCollider2D bc;

    [Header ("Audio")]
    public AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bc = GetComponent<BoxCollider2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            audioSource.Stop();
            dialogueBox.SetActive(true);
            Time.timeScale = 0;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            dialogueBox.SetActive(false);
            Destroy(bc);
        } 
    }
}