using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();

        // Retrieve the ScoreManager component from the ScoreManager script in the My Game scene
        ScoreManager scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        if (scoreManager != null)
        {
            // Retrieve the score and update the scoreText object
            int score = scoreManager.GetScore();
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogError("ScoreManager component not found in scene.");
        }
    }
}