using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Projectiles that are destroyed when hitting ground
public class DestroyOnNotTagHit : MonoBehaviour
{
    public string targetTag;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.tag != targetTag) {
            Destroy(gameObject);
        }
    }
}
