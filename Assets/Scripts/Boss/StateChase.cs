using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChase : MonoBehaviour
{
    private Boss boss;

   private void Awake()
   {
    boss = GetComponent<Boss>();
   }

       private void CambiarVista(float direccionX)
    {
        if (direccionX < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (direccionX > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private void Update()
    {
        if(boss.distance <= boss.attackArea)
        {
            boss.ActivateState(boss.attackState);
        }
        else
        {
            if(!boss.isAttacking && !boss.isKO)
            {
                Movement();
            }
        }
    }

    private void Movement()
    {
        if(boss.distance <= boss.detectionArea)
        {
            Vector3 direccion = (transform.position - boss.player.transform.position).normalized;
            CambiarVista(-direccion.x);
            boss.rb.velocity = new Vector3(-direccion.x * boss.speedMovement, boss.rb.velocity.y);
        }
    }
}
