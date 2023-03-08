using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject Life;
    public Rigidbody2D rb;
    public float Falling = 1;
    private void Awake()
    {
        rb = Life.GetComponent<Rigidbody2D>();
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Life"))
        {
            Life.SetActive(true);
            rb.gravityScale = Falling;
        }
    }
}
