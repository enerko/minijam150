using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.Rendering;
using System;

// For an object that orbits another object, aimed towards mouse pos
public class MouseControlledOrbiter : MonoBehaviour
{
    public Transform center;
    public float distance = 1;
    private Vector3 direction;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        direction = (mousePos - center.position).normalized;

        transform.position = center.position + direction * distance;
        transform.up = direction;
        
    }
}
