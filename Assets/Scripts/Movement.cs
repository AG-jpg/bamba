using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
     private Vector3 direction;
    private int IndexActual = 0;

    public float movementVelocity;
    public List<Transform> points = new List<Transform>();
    public bool waiting;
    public float waitingTime;

    public void Move()
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
