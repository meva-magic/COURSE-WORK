using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    public float Speed;
    private Vector2 moveVelocity;
    [SerializeField] private Rigidbody2D rb;
    CamShake camShake;
    private CinemachineImpulseSource impulseSource;


    private void Start()
    {
        camShake = GameObject.Find("CamShake").GetComponent<CamShake>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }
    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        moveVelocity = moveInput.normalized * Speed;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            camShake.CameraShake(impulseSource);
            //Time.timeScale = 0;
        }
    }
}
