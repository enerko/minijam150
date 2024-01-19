using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Projectiles that are destroyed when hitting ground
public class DestroyOnGroundHit : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.tag == "Ground") {
            Destroy(gameObject);
        }
    }
}
