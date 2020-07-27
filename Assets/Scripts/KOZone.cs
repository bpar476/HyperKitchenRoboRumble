using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KOZone : MonoBehaviour
{
    public int nextScene;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            RestartLevel();
        }
        else
        {
            EndLevel();
        }

    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void EndLevel()
    {
        SceneManager.LoadScene(nextScene);
    }
}
