using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
   Enemy enemyHealth;
   KillCount killCount;
    // Start is called before the first frame update
    void Start()
    {
      GameObject killCountObject = GameObject.Find("KCO");
    if (killCountObject != null)
    {
        killCount = killCountObject.GetComponent<KillCount>();
    }
    else
    {
        // Handle the case where "KCO" GameObject is not found
        Debug.LogError("GameObject 'KCO' not found.");
    }
    }

  private int damage = 1;

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemyHealth = collision.gameObject.GetComponent<Enemy>();
            if (enemyHealth!= null)
            {
               enemyHealth.TakeDamage(damage);
            }
        }

        gameObject.SetActive(false);
        killCount.AddKill();
    }
}
