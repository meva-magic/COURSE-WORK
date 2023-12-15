using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float Speed;
    public float StartWaitTime;
    
    private float WaitTime;
    private int randomSpot;

    public Transform[] MoveSpots;

    private void Start()
    {
        WaitTime = StartWaitTime; 
        randomSpot = Random.Range(0, MoveSpots.Length);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, MoveSpots[randomSpot].position, Speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, MoveSpots[randomSpot].position) < 0.2f)
        {
            if (WaitTime <= 0)
            {
                randomSpot = Random.Range(0, MoveSpots.Length);
                WaitTime = StartWaitTime;
            }

            else{WaitTime -= Time.deltaTime;}
        }
    }
}
