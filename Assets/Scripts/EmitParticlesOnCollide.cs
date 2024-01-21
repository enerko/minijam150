using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitParticlesOnCollide : MonoBehaviour
{
    public ParticleSystem particles;

    void OnCollisionEnter2D(Collision2D collision)
    {
        particles.Play();
    }
}
