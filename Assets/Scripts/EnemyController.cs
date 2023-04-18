using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public float minY = 1.73f;
    private Transform player;
    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = transform.position;
        player = GameObject.Find("Player").transform;
        SetTargetPosition(player.position);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position.y < minY)
        {
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);
        }
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    public void SetTargetPosition(Vector3 position)
    {
        if (position.y > minY)
        {
            targetPosition = position;
        }
        else
        {
            targetPosition = new Vector3(position.x, minY, position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}