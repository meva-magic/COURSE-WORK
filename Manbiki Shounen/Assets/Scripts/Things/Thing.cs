using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Thing : MonoBehaviour
{
    PointManager pointManager;
    CamShake camShake;
    private CinemachineImpulseSource impulseSource;


    private void Start()
    {
        camShake = GameObject.Find("CamShake").GetComponent<CamShake>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            camShake.CameraShake(impulseSource);
            AudioManager.instance.Play("Tooth");
            pointManager.UpdateScore(1);

            Destroy(gameObject);
        }
    }
}
