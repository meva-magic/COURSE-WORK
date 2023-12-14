using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class ChaseState : State
{
    public bool isInAttackRange;

    public AttackState attackState;

    public override State RunCurrentState()
    {
        if (isInAttackRange)
        {
            return attackState;
        }

        else
        {
            return this;
        }
    }
}
