using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
    PointManager pointManager;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            pointManager.UpdateScore(1);
        }
    }

    private void Start()
    {
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }
}
