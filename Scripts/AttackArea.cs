using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision) 
    {
        if(collision.CompareTag("Enemy"))
        {
            Debug.Log("Daño");
        }
    }
}
