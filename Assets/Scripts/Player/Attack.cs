using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //Object
    [Header ("Particles")]
    public GameObject pebbles;
    public GameObject snow;

    //Sounds
    [Header ("Audio")]
    private AudioSource audioSource;
    [SerializeField] private AudioClip stomp;
    [SerializeField] private AudioClip rock;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Golem"))
        {
            audioSource.PlayOneShot(rock);
            Instantiate(pebbles, transform.position, transform.rotation);
        } 
        else if(collision.CompareTag("Snowman"))
        {
            audioSource.PlayOneShot(stomp);
            Instantiate(snow, transform.position, transform.rotation);
        }else if(collision.CompareTag("Boss"))
        {
            audioSource.PlayOneShot(stomp);
            Instantiate(snow, transform.position, transform.rotation);
        }
    }
}