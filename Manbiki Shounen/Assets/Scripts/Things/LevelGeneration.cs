using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
    public GameObject[] Things;

    private void Start()
    {
        int rand = Random.Range(0, Things.Length);
        Instantiate(Things[rand], transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
