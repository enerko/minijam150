using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightShoot : MonoBehaviour
{
    public GameObject lightProjectile;  // projectile to shoot
    public float lightSpeed = 50;  // speed of projectile

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 playerPos = transform.position;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector3 direction = (mousePos - playerPos).normalized;

            GameObject newLight = Instantiate(lightProjectile, playerPos, Quaternion.identity);
            newLight.GetComponent<Rigidbody2D>().velocity = direction * lightSpeed;
            Debug.Log(newLight.GetComponent<Rigidbody2D>().velocity.magnitude);
        }
    }
}
