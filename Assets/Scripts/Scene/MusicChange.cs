using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChange : MonoBehaviour
{
    public bool IsPaused = false;
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
            IsPaused = false;
            Time.timeScale = 1;
            dialogueBox.SetActive(false);
            Destroy(bc);
        }
    }
}