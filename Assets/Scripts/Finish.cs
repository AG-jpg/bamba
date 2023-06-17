using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject balloon;
    public Movement go;

    private void Awake() 
    {
        go = balloon.GetComponent<Movement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            go.Move();
        }
    }

}
