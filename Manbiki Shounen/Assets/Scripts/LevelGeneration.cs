using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] Things;

    private void Start()
    {
        int rand = Random.Range(0, Things.Length);
        Instantiate(Things[rand], transform.position, Quaternion.identity);
    }
}
