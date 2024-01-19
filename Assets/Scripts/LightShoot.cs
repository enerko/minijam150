using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Click to shoot a light projectile from the object towards relative UP
public class LightShoot : MonoBehaviour
{
    public GameObject lightProjectile;  // projectile to shoot
    public float cooldown = 1;
    public float lightSpeed = 50;  // speed of projectile

    private float timer = 0;

    void Start() {
        timer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && (timer >= cooldown))
        {
            timer = 0;
            Vector3 direction = transform.up;

            GameObject newLight = Instantiate(lightProjectile, transform.position, Quaternion.identity);
            newLight.GetComponent<Rigidbody2D>().velocity = direction * lightSpeed;
        }

        timer += Time.deltaTime;
    }
}
