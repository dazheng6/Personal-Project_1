using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f; // speed at which the enemy moves

    // Update is called once per frame
    void Update()
    {
        // move the enemy forward along the z-axis
        Vector3 direction = new Vector3(0f, 0f, -1f);
        transform.Translate(direction * speed * Time.deltaTime);

        // check if the enemy has fallen below the y-threshold
        if (transform.position.y < 0f)
        {
            // if the enemy has fallen below the threshold, set its y-position to 0 to prevent it from falling further
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        }
        
        if (transform.positin.z < 40f)
        {
            Destroy(gameObject);
        }
    }
}