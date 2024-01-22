using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// If this component is in something, the player can press R to restart the current level
public class RestartOnR : MonoBehaviour
{
    public AudioClip reloadSound;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            Globals.PlayClip(reloadSound);
            Globals.RestartCurrentLevel(0);
        }
    }
}
