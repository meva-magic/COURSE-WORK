using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

internal class IdleState : State
{
    public ChaseState chaseState;
    static public bool canSeePlayer;

    public float Speed;
    public float StartWaitTime;

    private float waitTime;
    private int randomSpot;

    public Transform Enemy;
    public Transform[] MoveSpots;


    public override State RunCurrentState()
    {
        if (canSeePlayer)
        {
            return chaseState;
        }

        else
        {
            Enemy.position = Vector2.MoveTowards(Enemy.position, MoveSpots[randomSpot].position, Speed * Time.deltaTime);

            if(Vector2.Distance(Enemy.transform.position, MoveSpots[randomSpot].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, MoveSpots.Length);
                    waitTime = StartWaitTime;
                }

                else{waitTime -= Time.deltaTime;}
            }
            return this;
        }
    }

    private void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
    }
}