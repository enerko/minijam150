using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add this component to objects with a maximum lifespan
public class Lifespan : MonoBehaviour
{
    public float lifeSpan;  //seconds
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeSpan);
    }
}
