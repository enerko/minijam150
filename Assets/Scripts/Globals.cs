using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Globals
{
    public static int currentEnemies = 0;  // gets initialized on load

    private static Checkpoint lastCheckpoint;
    private static List<string> levels = new List<string> { "Level 1", "Level 2" };
    private static int currLevel = 0;

    public static void UpdateLastCheckpoint(Checkpoint checkpoint)
    {
        lastCheckpoint = checkpoint;
    }

    public static void CheckWin()
    {
        if (currentEnemies == 0)
        {
            currLevel = (currLevel + 1) % levels.Count;
            LoadScene(levels[currLevel]);
        }
    }

    // Load the given scene and reset the appropriate static vars
    public static void LoadScene(string sceneName) {
        // Reset any appropriate static variables if needed

        currentEnemies = 0;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
