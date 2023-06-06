using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalk : StateMachineBehaviour
{
    private BossWalk boss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss>();
        if (!boss.isAttacking)
        {
            boss.ActivateState(boss.StateChase);
        }
    }
}
