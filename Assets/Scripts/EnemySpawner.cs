using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Material[] materials;
    public float spawnRadius = 20f;
    public float timeToSpawn = 1.5f;
    public Button startButton;
    public GameObject playerPrefab;
    public GameObject titleScreen;
    public Button restartButton;

    private bool gameStarted = false;
    private bool gameOver = false;

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        restartButton.gameObject.SetActive(false);
    }

    private void StartGame()
    {
        if (!gameStarted)
        {
            gameStarted = true;
            startButton.gameObject.SetActive(false);
            titleScreen.SetActive(false); // Hide the title screen
            SpawnPlayer();
            StartCoroutine(SpawnEnemies());
        }
    }

    private IEnumerator SpawnEnemies()
    {
        while (gameStarted && !gameOver)
        {
            Vector3 randomPosition = Random.onUnitSphere * spawnRadius + transform.position;
            randomPosition.y = 1.73f;
            GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
            Renderer renderer = enemy.GetComponent<Renderer>();
            if (renderer != null && materials.Length > 0)
            {
                renderer.material = materials[Random.Range(0, materials.Length)];
            }
            yield return new WaitForSeconds(timeToSpawn);
        }
    }

    private void SpawnPlayer()
    {
        Instantiate(playerPrefab, new Vector3(0, 1.73f, 0), Quaternion.identity);
    }

    public void RestartGame()
    {
        gameOver = false;
        gameStarted = false;
        restartButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
        titleScreen.SetActive(true);
    }

    public void GameOver()
    {
        gameOver = true;
        StopCoroutine(SpawnEnemies());

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Destroy(player);
        }

        restartButton.gameObject.SetActive(true);
    }
}