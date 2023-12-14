using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    IdleState idleState;
    public float RotationSpeed;
    public float Distance;
    //public LineRenderer lineOfSight;

    public void Start()
    {
        Physics2D.queriesStartInColliders = false;

        idleState = GameObject.FindGameObjectWithTag("Idle State").GetComponent<IdleState>();
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * RotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, Distance);

        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            //lineOfSight.SetPosition(1, hitInfo.point);
            
            if (hitInfo.collider.CompareTag("Player"))
            {
                IdleState.canSeePlayer = true;
            }

            else
            {
                
            }
        }

        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * Distance, Color.green);
            IdleState.canSeePlayer = false;
            //lineOfSight.SetPosition(1, transform.position + transform.right * Distance);
        }

        //lineOfSight.SetPosition(0, transform.position);
    }
}
