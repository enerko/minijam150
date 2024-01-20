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
    public IntValue ammoCounter;

    private float timer = 0;

    void Start() {
        timer = cooldown;
        ammoCounter = GameObject.Find("/AmmoLimit")?.GetComponent<IntValue>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && (timer >= cooldown) && (ammoCounter?.GetValue() > 0))
        {
            timer = 0;
            Vector3 direction = transform.up;

            Shoot(lightProjectile, transform.position, direction, lightSpeed);

            if (ammoCounter) {
                ammoCounter.SetValue(ammoCounter.GetValue() - 1);
            }
        }

        timer += Time.deltaTime;
    }

    public static void Shoot(GameObject prefab, Vector3 origin, Vector3 direction, float speed) {
        GameObject newLight = Instantiate(prefab, origin, Quaternion.identity);
        newLight.GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
