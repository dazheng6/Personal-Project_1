using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Material[] materials;
    public float spawnRadius = 50f;
    public float timeToSpawn = 1.5f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Vector3 randomPosition = Random.onUnitSphere * spawnRadius + transform.position;
            randomPosition.y = 0f;
            GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
            Renderer renderer = enemy.GetComponent<Renderer>();
            if (renderer != null && materials.Length > 0)
            {
                renderer.material = materials[Random.Range(0, materials.Length)];
            }
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}