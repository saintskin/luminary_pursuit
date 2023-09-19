using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5; // Adjust the maximum health as needed
    private int currentHealth;

    public Image [] bars;
    public Sprite fullBar;
    public Sprite emptyBar;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        foreach (Image img in bars)
        {
            img.sprite = emptyBar;
        }
        for (int i= 0; i < maxHealth; i++)
        {
            bars[i].sprite = fullBar;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    
}
