using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("AddPoint", 1f, 1f); // Call AddPoint() every second
    }

    void AddPoint()
    {
        if (player != null)
        {
            score++;
            scoreText.text = "Score: " + score;
        }
        else
        {
            CancelInvoke(); // Stop calling AddPoint() when player is destroyed
            PlayerPrefs.SetInt("Score", score); // Store the score value
            SceneManager.LoadScene("Game Over"); // Load Game Over scene
        }
    }
    public int GetScore()
    {
        return score;
    }
}