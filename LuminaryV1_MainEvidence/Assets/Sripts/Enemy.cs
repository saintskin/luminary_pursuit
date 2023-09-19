using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public AudioClip deathSound; // Assign the death sound in the Inspector
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth=maxHealth;
         audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int amount)
    {
        
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
