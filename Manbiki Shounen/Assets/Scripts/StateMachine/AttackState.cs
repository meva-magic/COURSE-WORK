using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class AttackState : State
{
    public override State RunCurrentState()
    {
        Debug.Log("Boom bitch!");
        return this;
    }
}
