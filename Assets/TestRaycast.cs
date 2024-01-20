using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRaycast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.one;

        Debug.Log(Physics2D.Raycast(Vector3.zero, direction, 10).collider);
        Debug.DrawRay(Vector3.zero, direction* 10, Color.red);
    }
}
