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
            instance.StartCoroutine(ChangeScene(levels[currLevel + 1]));
            currLevel++; 
        }

        if (tag == "Player")
        {
            instance.StartCoroutine(ChangeScene(levels[currLevel]));
        }
    }

    private static IEnumerator ChangeScene(string scene)
    {
        yield return new WaitForSeconds(2);
        LoadScene(scene);
    }

    // Load the given scene and reset the appropriate static vars
    public static void LoadScene(string sceneName) {
        // Reset any appropriate static variables if needed

        currentEnemies = 0;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
