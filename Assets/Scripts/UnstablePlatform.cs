using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstablePlatform : MonoBehaviour
{
    private PlayerController player;
    public GameObject originalpoint;
    public Rigidbody2D rb;
    public int Falling = 1;
    public int Stay = 0;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        gameObject.name = "PlatformFalling";
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            rb.gravityScale = Falling;
        }
        else if(collision.CompareTag("Limits"))
        {
            rb.gravityScale = Stay;
            gameObject.transform.position = originalpoint.transform.position;
            rb.gravityScale = Stay;
        }
    }
}