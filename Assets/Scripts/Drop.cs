using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [Header("Drops")]
    public GameObject Balloon;
    public Rigidbody2D rb;
    private SpriteRenderer rend;
    public int Falling = 1;
    public int Order = 1;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

        private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Balloon"))
        {
            rend.sortingOrder = Order;
            rb.gravityScale = Falling;
        }
    }
}
