using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public TMP_Text ScoreText;
    Thing thing;
    public int Score;

    void Start()
    {
        ScoreText.text = "<SCORE " + Score + ">";
        thing = GameObject.FindGameObjectWithTag("Thing").GetComponent<Thing>();
    }

    public void UpdateScore(int points)
    {
        Score += 1;
        ScoreText.text = "<SCORE " + Score + ">";
    }
}
