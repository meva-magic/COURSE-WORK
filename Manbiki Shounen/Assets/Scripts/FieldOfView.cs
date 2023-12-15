using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float Radius = 5;
    public float Angle = 40f;
    public float RotationSpeed;

    public LayerMask PlayerLayer;
    public LayerMask WallLayer;

    public GameObject PlayerRef;
    IdleState idleState;

    private void Start()
    {
        PlayerRef = GameObject.FindGameObjectWithTag("Player");
        idleState = GameObject.FindGameObjectWithTag("Idle State").GetComponent<IdleState>();

        StartCoroutine(FieldCheck());
    }

    private void Update(){transform.Rotate(Vector3.forward * RotationSpeed * Time.deltaTime);}

    private IEnumerator FieldCheck()
    {
        WaitForSeconds wait = new WaitForSeconds(0.5f);

        while(true)
        {
            yield return wait;
            Field();
        }
    }

    private void Field()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, Radius, PlayerLayer);

        if (rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;

            if (Vector2.Angle(transform.up, directionToTarget) < Angle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, WallLayer))
                {
                    IdleState.canSeePlayer = true;
                }

                else{IdleState.canSeePlayer = false;}
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, Radius);

        Vector3 Angle01 = DirectionFromAngle(-transform.eulerAngles.z, -Angle / 2);
        Vector3 Angle02 = DirectionFromAngle(-transform.eulerAngles.z, Angle / 2);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Angle01 * Radius);
        Gizmos.DrawLine(transform.position, transform.position + Angle02 * Radius);

        if (IdleState.canSeePlayer)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, PlayerRef.transform.position);
        }
    }

    private Vector2 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
