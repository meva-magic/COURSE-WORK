using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class IdleState : State
{
    public bool canSeePlayer;
    public ChaseState chaseState;

    public override State RunCurrentState()
    {
        if (canSeePlayer)
        {
            return chaseState;
        }

        else
        {
            return this;
        }
    }
}
