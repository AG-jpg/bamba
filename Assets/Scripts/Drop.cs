using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject Life;
    public Rigidbody2D rb;
    private SpriteRenderer rend;
    public int Falling = 1;

    public int Order = 1;


    private void Awake()
    {
        rb = Life.GetComponent<Rigidbody2D>();
        rend = Life.GetComponent<SpriteRenderer>();
    }

        private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Life"))
        {
            rend.sortingOrder = Order;
            rb.gravityScale = Falling;
        }
    }
}
