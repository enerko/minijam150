using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTagHit : MonoBehaviour
{
    public string target;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == target)
        {
            // if enemy is destroyed...
            if (tag == "Enemy") {
                Globals.currentEnemies--;
                Globals.CheckWin();
            }

            Destroy(gameObject);
        }
    }
}
