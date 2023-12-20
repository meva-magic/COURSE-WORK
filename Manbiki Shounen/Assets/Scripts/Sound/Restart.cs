using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject RestartPanel;
    public bool isGameOver;
    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        SceneManager.LoadScene("Sample Scene");
        RestartPanel.SetActive(true);
    }

    public void StartGame()
    {
        isGameOver = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Start()
    {
        RestartPanel.SetActive(true);
    }

    private void Update()
    {
        if(isGameOver == true && Input.GetButtonDown("Jump"))
        {
            StartGame();
        }

        else
        {
            GameOver();
        }
    }
}
