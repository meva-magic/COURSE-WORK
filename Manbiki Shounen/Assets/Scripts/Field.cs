using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Field : MonoBehaviour
{
    IdleState idleState;

    public float Radius;
    public float Angle;

    public GameObject PlayerRef;

    public LayerMask PlayerMask;
    public LayerMask WallMask;

    void Start()
    {
        PlayerRef = GameObject.FindGameObjectWithTag("Player");
        idleState = GameObject.FindGameObjectWithTag("Idle State").GetComponent<IdleState>();

        StartCoroutine(FieldRoutine());
    }

    private IEnumerator FieldRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;

            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeCheck = Physics.OverlapSphere(transform.position, Radius, PlayerMask);

        if(rangeCheck.Length != 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.position, directionToTarget) < Angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, WallMask))
                {
                    IdleState.canSeePlayer = true;
                }
                else
                {
                    IdleState.canSeePlayer = false;
                }
            }

            else
            {
                IdleState.canSeePlayer = false;
            }
        }
        else if(IdleState.canSeePlayer)
        {IdleState.canSeePlayer = false;}
    }
}
