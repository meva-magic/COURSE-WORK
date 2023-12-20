using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float Speed;
    public float RotationSpeed;
    private Vector2 moveVelocity;
    [SerializeField] private Rigidbody2D rb;
    CamShake camShake;
    Restart restart;
    private CinemachineImpulseSource impulseSource;


    private void Start()
    {
        camShake = GameObject.Find("CamShake").GetComponent<CamShake>();
        camShake.CameraShake(impulseSource);
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }
    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Rotate(Vector3.forward * -RotationSpeed * Time.deltaTime);
        moveVelocity = moveInput.normalized * Speed;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            AudioManager.instance.Play("Gun");
            camShake.CameraShake(impulseSource);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);            
        }
    }
}
