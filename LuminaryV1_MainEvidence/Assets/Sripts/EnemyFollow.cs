using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float followDistance = 5.0f;
    public float moveSpeed = 3.0f;

    private void Update()
    {
        if (player == null)
        {
            // Make sure you have a reference to the player GameObject
            Debug.LogError("Player reference is missing!");
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > followDistance)
        {
            // Move the enemy towards the player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}
