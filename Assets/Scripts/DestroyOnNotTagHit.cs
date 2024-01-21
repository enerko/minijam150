using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Projectiles that are destroyed when hitting something that is not a specific thing
public class DestroyOnNotTagHit : MonoBehaviour
{
    public string targetTag;
    public AudioClip sound;  // sound to play when hitting target thing

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.tag != targetTag) {
            Destroy(gameObject);
        } else {
            Globals.PlayClip(sound);
        }
    }
}
