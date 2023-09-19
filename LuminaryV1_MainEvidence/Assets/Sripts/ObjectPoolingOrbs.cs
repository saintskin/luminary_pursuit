using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingOrbs : MonoBehaviour
{
      public GameObject collectibleItemPrefab; // Reference to the collectible item prefab.
    public int poolSize = 10;                // The initial size of the object pool.
    public string markerTag = "CollectibleMarker"; // The tag for the markers where collectible items can appear.

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
            GameObject collectibleItem = InstantiateCollectibleItem(Vector3.zero, Quaternion.identity);
            DeactivateCollectibleItem(collectibleItem);
        }
    }

    private GameObject InstantiateCollectibleItem(Vector3 position, Quaternion rotation)
    {
        GameObject collectibleItem = Instantiate(collectibleItemPrefab, position, rotation);
        collectibleItem.SetActive(false);
        return collectibleItem;
    }

    public GameObject GetCollectibleItem(Vector3 position, Quaternion rotation)
    {
        foreach (GameObject collectibleItem in objectPool)
        {
            if (!collectibleItem.activeInHierarchy)
            {
                // Set the position and rotation of the collectible item before activating it.
                collectibleItem.transform.position = position;
                collectibleItem.transform.rotation = rotation;
                collectibleItem.SetActive(true);
                return collectibleItem;
            }
        }

        // If no inactive collectible item is found, create a new one and add it to the pool.
        GameObject newCollectibleItem = InstantiateCollectibleItem(position, rotation);
        objectPool.Add(newCollectibleItem);
        newCollectibleItem.SetActive(true);
        return newCollectibleItem;
    }

    public void DeactivateCollectibleItem(GameObject collectibleItem)
    {
        collectibleItem.SetActive(false);
    }

    // Method to spawn a collectible item at a random marker position.
    public void SpawnCollectibleItemAtRandomMarker()
    {
        if (spawnMarkers.Length > 0)
        {
            // Choose a random marker from the array.
            int randomIndex = Random.Range(0, spawnMarkers.Length);
            Vector3 markerPosition = spawnMarkers[randomIndex].transform.position;

            // Spawn the collectible item at the selected marker's position.
            GameObject newCollectibleItem = GetCollectibleItem(markerPosition, Quaternion.identity);
            // You can add additional collectible item-specific setup here if needed.
        }
        else
        {
            Debug.LogWarning("No spawn markers found with the specified tag.");
        }
    }
}

