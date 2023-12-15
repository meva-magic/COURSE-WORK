using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class ChaseState : State
{
    public float Speed;
    private Transform Player;
    public GameObject Enemy;


    public override State RunCurrentState()
    {
        Enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position, Player.position, Speed * Time.deltaTime);
        return this;
    }

    private void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
