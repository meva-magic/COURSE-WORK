using System.Collections;
using System.Collections.Generic;
using UnityEngine;


internal class ChaseState : State
{
    public float Speed;
    private Transform Player;
    private Transform Enemy;


    public override State RunCurrentState()
    {
        Enemy.position = Vector2.MoveTowards(Enemy.position, Player.position, Speed * Time.deltaTime);
        return this;
    }

    private void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
