using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public GameObject startpoint;
    private PlayerController player;

    private void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.transform.position = startpoint.transform.position;
    }
}
