using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public GameObject checkpoint;

    [Header ("Audio")]
    private AudioSource audioSource;
    [SerializeField] private AudioClip fall;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            audioSource.PlayOneShot(fall);
            StartCoroutine(WaitTime());
            collision.transform.position = checkpoint.transform.position;
            collision.GetComponent<PlayerController>().RecibirDano();
        }else  if(collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
