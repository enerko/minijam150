using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Detects a light projectile, destroys it, and spawns two more at a 90 angle
public class Prism : MonoBehaviour
{
    public float angle = 90;

    private float cooldown = 0.3f;  // cooldown to prevent split light from triggering the prism instantly
    private float timer = 0.3f;

    void Update() {
        timer += Time.deltaTime;
    }

    void HandleLight(Collider2D other) {
        if (other.gameObject.tag != "Light" || timer < cooldown) {
            return;
        }

        timer = 0;

        // Must be tagged Light to split
        GameObject light = other.gameObject;
        Vector3 velo = light.GetComponent<Rigidbody2D>().velocity;
        float currSpeed = velo.magnitude;
        Vector3 dir = velo.normalized;
        Vector3 dirUp = Quaternion.AngleAxis(angle / 2, new Vector3(0, 0, 1)) * dir;
        Vector3 dirDown = Quaternion.AngleAxis(-angle / 2, new Vector3(0, 0, 1)) * dir;

        LightShoot.Shoot(light, light.transform.position, dirUp, currSpeed);
        LightShoot.Shoot(light, light.transform.position, dirDown, currSpeed);

        Destroy(light);
    }

    void OnTriggerEnter2D(Collider2D other) {
        HandleLight(other);
    }

    void OnTriggerStay2D(Collider2D other) {
        HandleLight(other);
    }
}
