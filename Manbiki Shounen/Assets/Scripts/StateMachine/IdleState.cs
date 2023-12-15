using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

internal class IdleState : State
{
    static public bool canSeePlayer;
    public ChaseState chaseState;
    public GameObject Enemy;
    public float Speed;
    public float StartWaitTime;

    private float WaitTime;
    private int randomSpot;

    public Transform[] MoveSpots;

    public override State RunCurrentState()
    {
        if (canSeePlayer)
        {
            return chaseState;
        }

        else
        {
            Enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position, MoveSpots[randomSpot].position, Speed * Time.deltaTime);

            if(Vector2.Distance(Enemy.transform.position, MoveSpots[randomSpot].position) < 0.2f)
            {
                if (WaitTime <= 0)
                {
                    randomSpot = Random.Range(0, MoveSpots.Length);
                    WaitTime = StartWaitTime;
                }

                else{WaitTime -= Time.deltaTime;}
            }
            return this;
        }
    }

    private void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
    }
}
