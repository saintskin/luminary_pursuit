using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolEnemy : MonoBehaviour
{
   public GameObject enemyPrefab;          // Reference to the enemy prefab.
    public int poolSize = 10;               // The initial size of the object pool.
    public string markerTag = "EnemyMarker"; // The tag for the markers where enemies can spawn.

    private List<GameObject> objectPool;
    private GameObject[] spawnMarkers;       // Array to store spawn marker GameObjects.

    private void Start()
    {
        // Find all GameObjects with the specified tag.
        spawnMarkers = GameObject.FindGameObjectsWithTag(markerTag);

        InitializeObjectPool();
    }

    private void InitializeObjectPool()
    {
        objectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = InstantiateEnemy(Vector3.zero, Quaternion.identity);
            DeactivateEnemy(enemy);
        }
    }

    private GameObject InstantiateEnemy(Vector3 position, Quaternion rotation)
    {
        GameObject enemy = Instantiate(enemyPrefab, position, rotation);
        enemy.SetActive(false);
        return enemy;
    }

    public GameObject GetEnemy(Vector3 position, Quaternion rotation)
    {
        foreach (GameObject enemy in objectPool)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.transform.position = position;
                enemy.transform.rotation = rotation;
                enemy.SetActive(true);
                return enemy;
            }
        }

        GameObject newEnemy = InstantiateEnemy(position, rotation);
        objectPool.Add(newEnemy);
        newEnemy.SetActive(true);
        return newEnemy;
    }

    public void DeactivateEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
    }

    // Method to spawn an enemy at a random marker position.
    public void SpawnEnemyAtRandomMarker()
    {
        if (spawnMarkers.Length > 0)
        {
            // Choose a random marker from the array.
            int randomIndex = Random.Range(0, spawnMarkers.Length);
            Vector3 markerPosition = spawnMarkers[randomIndex].transform.position;

            // Spawn the enemy at the selected marker's position.
            GameObject newEnemy = GetEnemy(markerPosition, Quaternion.identity);
            // You can add additional enemy-specific setup here if needed.
        }
        else
        {
            Debug.LogWarning("No spawn markers found with the specified tag.");
        }
    }
}
