using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pikes : MonoBehaviour
{
    //Sounds
    [Header ("Audio")]
    private AudioSource audioSource;
    [SerializeField] private AudioClip slam;

    private PlayerController player;

    private void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().RecibirDano(-(collision.transform.position - transform.position).normalized);
            audioSource.PlayOneShot(slam);
        }
    }
}
