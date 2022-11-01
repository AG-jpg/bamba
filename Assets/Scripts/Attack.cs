using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //Object
    public GameObject particles;

    //Sounds
    [Header ("Audio")]
    private AudioSource audioSource;
    [SerializeField] private AudioClip stomp;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            audioSource.PlayOneShot(stomp);
            Instantiate(particles, transform.position, transform.rotation);
        }
    }
}
