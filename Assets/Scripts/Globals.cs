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
    private static int numLevels = 7;
    private static int currLevel = 1;

    private static bool isLoadingScene = false;  // sometimes it loads after a delay, this corresponds to that

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
                // currLevel should go from 1 to numLevels
                currLevel = currLevel % numLevels + 1;
                RestartCurrentLevel(2);
            }
        }

        if (tag == "Player")
        {
            RestartCurrentLevel(2);
        }
    }

    public static void RestartCurrentLevel(float delay) {
        instance.StartCoroutine(LoadSceneAsync("Level " + currLevel, delay));
    }

    private static IEnumerator LoadSceneAsync(string scene, float delay)
    {
        // May only load a single scene asynchronously
        if (isLoadingScene) {
            yield break;
        }

        isLoadingScene = true;
        yield return new WaitForSeconds(delay);
        LoadScene(scene);
    }

    // Load the given scene and reset the appropriate static vars
    public static void LoadScene(string sceneName) {
        // Reset any appropriate static variables if needed
        isLoadingScene = false;
        currentEnemies = 0;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
