using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBoundary : MonoBehaviour
{
    public float boundaryRadius = 30f;

    void FixedUpdate()
    {
        Vector3 playerPosition = transform.position;
        float distanceFromCenter = Vector3.Distance(playerPosition, Vector3.zero);

        if (distanceFromCenter > boundaryRadius)
        {
            Vector3 directionToCenter = Vector3.Normalize(Vector3.zero - playerPosition);
            Vector3 newPosition = Vector3.zero + (directionToCenter * boundaryRadius);
            transform.position = newPosition;
        }
    }
}