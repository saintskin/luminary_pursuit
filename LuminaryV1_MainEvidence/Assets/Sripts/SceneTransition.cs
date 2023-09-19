using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
   public string nextSceneName; // Name of the scene to transition to.
    public int requiredOrbs = 10; // Adjust the number of orbs required.

    private int collectedOrbs = 0;

    // Call this method when an orb is collected.
    public void CollectOrb()
    {
        collectedOrbs++;

        // Check if the player has collected all required orbs.
        if (collectedOrbs >= requiredOrbs)
        {
            EndGame();
        }
    }
private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EndGame();
        }
    }

private void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
