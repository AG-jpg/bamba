using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    private Vector3 direction;
    private PlayerController player;
    private Rigidbody2D rb;
    private int IndexActual = 0;

    public float movementVelocity;
    public List<Transform> points = new List<Transform>();
    public bool waiting;
    public float waitingTime;

    private void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    {
        WaypointsMove();
    }

    private void WaypointsMove()
    {
        direction = (points[IndexActual].position - transform.position).normalized;

        if(!waiting)
        {
            transform.position = (Vector2.MoveTowards(transform.position, points[IndexActual].position, movementVelocity * Time.deltaTime));
        }

        if(Vector2.Distance(transform.position, points[IndexActual].position) <= 0.7f)
        {
            if(!waiting)
            {
                StartCoroutine(Wait());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if(collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Platform"))
         {
            player.transform.parent = transform;
         }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Platform"))
         {
            player.transform.parent = null;
         }
    }

    private IEnumerator Wait()
    {
        waiting = true;
        yield return new WaitForSeconds(waitingTime);
        waiting = false;
        
        IndexActual++;

        if(IndexActual >= points.Count)
        {
            IndexActual = 0;
        }
    }

}
