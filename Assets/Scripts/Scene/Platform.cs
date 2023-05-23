using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlayerController player;
    private bool detectPlayer;

    public bool isJump;
    public BoxCollider2D platformCollider;
    public BoxCollider2D platformTrigger;

    private void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!isJump)
        {
            Physics2D.IgnoreCollision(platformCollider, platformTrigger, true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            if(!isJump)
            {
                Physics2D.IgnoreCollision(platformCollider, player.GetComponent<BoxCollider2D>(), true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(!isJump)
            {
                Physics2D.IgnoreCollision(platformCollider, player.GetComponent<BoxCollider2D>(), false);
            }
    }

}
