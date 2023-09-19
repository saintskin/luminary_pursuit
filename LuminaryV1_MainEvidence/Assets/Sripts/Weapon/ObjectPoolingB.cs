using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingB : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int poolSize = 20;

    private List<GameObject> bulletPool;

    private void Start()
    {
        bulletPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    public GameObject GetBullet()
    {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (!bulletPool[i].activeInHierarchy)
            {
                return bulletPool[i];
            }
        }
        return null;
    }
}
