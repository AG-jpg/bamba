using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAttack : MonoBehaviour
{
    private Boss boss;

    private void Awake()
    {
        boss = GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!boss.isAttacking)
        {
            boss.rb.velocity = Vector2.zero;
        }

        if(boss.distance > boss.attackArea)
        {
            boss.ActivateState(boss.chaseState);
        }
    }
}
