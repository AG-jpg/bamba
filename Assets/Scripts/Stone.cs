using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
     private Rigidbody2D rb;
    private BoxCollider2D bc;

    public GameObject golem;
    public LayerMask layerFloor;
    public Vector2 direccionFlecha;
    public float radiusCollision = 0.25f;
    public bool touchFloor;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().RecibirDano(-(collision.transform.position - golem.transform.position).normalized);
            Destroy(this.gameObject);
        }
    }

    private void Update() 
    {
        touchFloor = Physics2D.OverlapCircle((Vector2)transform.position, radiusCollision, layerFloor);
        if(touchFloor)
        {
            Destroy(this.gameObject);
            this.enabled = false;
        }

        float angle = Mathf.Atan2(direccionFlecha.y, direccionFlecha.x) * Mathf.Rad2Deg;

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.y, transform.localEulerAngles.x, angle);
    }
}
