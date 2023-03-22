using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // the enemy object to spawn
    public float minSpawnInterval = 1f; // minimum time between spawns
    public float maxSpawnInterval = 4f; // maximum time between spawns
    public float spawnRangeX = 5f; // range of x-axis positions to spawn enemies
    public float spawnLocationRangeZ = 15f;
    public List<Color> enemyColors; // list of enemy colors to choose from

    private float spawnTimer; // timer for spawning enemies

    void Update()
    {
        // count down the spawn timer
        spawnTimer -= Time.deltaTime;

        // if the spawn timer has reached 0 or less
        if (spawnTimer <= 0f)
        {
            // reset the spawn timer to a random value between the min and max spawn intervals
            spawnTimer = Random.Range(minSpawnInterval, maxSpawnInterval);

            // choose a random position on the x axes to spawn the enemy
            float spawnX = transform.position.x + Random.Range(-spawnRangeX, spawnRangeX);

            // choose a random color for the enemy
            Color enemyColor = enemyColors[Random.Range(0, enemyColors.Count)];

            // spawn the enemy object at the chosen position and with the chosen color
            GameObject enemyObject = Instantiate(enemyPrefab, new Vector3(spawnX, transform.position.y, spawnLocationRangeZ), Quaternion.identity);
            MeshRenderer renderer = enemyObject.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.material.color = enemyColor;
            }
        }
    }
}