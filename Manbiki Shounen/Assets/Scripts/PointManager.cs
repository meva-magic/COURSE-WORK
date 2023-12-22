using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PointManager : MonoBehaviour
{
    public TMP_Text ScoreText;
    public int Score;


    void Start()
    {
        ScoreText.text = "<SCORE: " + Score + ">";
    }

    public void UpdateScore(int points)
    {
        Score += 1;
        ScoreText.text = "<SCORE: " + Score + ">";

        if (Score == 7)
        { 
            SceneManager.LoadScene("SampleScene");
            IdleState.canSeePlayer = false;
        }
    }
}
