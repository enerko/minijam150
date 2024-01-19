using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Globals: MonoBehaviour
{
    public static Globals instance;
    public static int currentEnemies = 0;  // gets initialized on load

    private static Checkpoint lastCheckpoint;
    private static List<string> levels = new List<string> { "Level 1", "Level 2" };
    private static int currLevel = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static void UpdateLastCheckpoint(Checkpoint checkpoint)
    {
        lastCheckpoint = checkpoint;
    }

    public static void CheckState(string tag)
    {
        // if enemy is destroyed...
        if (tag == "Enemy")
        {
            currentEnemies--;

            if (currentEnemies == 0) {
                currLevel = (currLevel + 1) % levels.Count;
                instance.StartCoroutine(LoadSceneAsync(levels[currLevel], 2));
            }
        }

        if (tag == "Player")
        {
            instance.StartCoroutine(LoadSceneAsync(levels[currLevel], 2));
        }
    }

    private static IEnumerator LoadSceneAsync(string scene, float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadScene(scene);
    }

    // Load the given scene and reset the appropriate static vars
    public static void LoadScene(string sceneName) {
        // Reset any appropriate static variables if needed

        currentEnemies = 0;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
