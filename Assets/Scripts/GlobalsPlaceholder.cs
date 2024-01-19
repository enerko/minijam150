using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Some global stuff managing game state and static vars i guess
public class Globals
{
    public static bool s_GameIsPaused = false;

    // Load the given scene and reset the appropriate static vars
    public static void LoadScene(string sceneName) {
        Time.timeScale = 1f;
        s_GameIsPaused = false;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
