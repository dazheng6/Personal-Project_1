using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    private void Start()
    {
        // Find the button with the "RestartGame" tag and register its onClick event
        GameObject startGame = GameObject.FindGameObjectWithTag("StartGame");
        startGame.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(LoadMyGameScene);
    }

    private void LoadMyGameScene()
    {
        // Load the "My Game" scene
        SceneManager.LoadScene("My Game");
    }
}
