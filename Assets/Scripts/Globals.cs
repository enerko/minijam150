using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Globals
{
    private static Checkpoint lastCheckpoint;
    private static List<string> levels = new List<string> { "Level 1", "Level 2" };
    private static int currLevel = 0;

    public static void UpdateLastCheckpoint(Checkpoint checkpoint)
    {
        lastCheckpoint = checkpoint;
    }

    public static void CheckWin()
    {
        Debug.Log(GameObject.FindGameObjectsWithTag("Enemy"));
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            SceneManager.LoadScene(levels[currLevel + 1]);
            currLevel++;
        }
    }
}
