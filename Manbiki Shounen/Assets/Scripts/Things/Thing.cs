using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnThing : MonoBehaviour
{
    public GameObject[] Things;
    private int value = 1;

    private void Start()
    {
        int rand = Random.Range(0, Things.Length);
        Instantiate(Things[rand], transform.position, Quaternion.identity);
    }
}
