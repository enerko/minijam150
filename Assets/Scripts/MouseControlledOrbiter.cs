using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.Rendering;

// For an object that orbits another object, aimed towards mouse pos
public class MouseControlledOrbiter : MonoBehaviour
{
    public Transform center;
    public float distance = 1;
    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    private LineRenderer lineRenderer;
    private Vector3 direction;
    private Vector3 playerPos;
    private float maxDist = 20;
    public LayerMask layersToIgnore;

    private void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.2f;
        lineRenderer.positionCount = 2;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lineRenderer.colorGradient = gradient;
    }
    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        direction = (mousePos - center.position).normalized;

        transform.position = center.position + direction * distance;
        transform.up = direction;
        DrawLine();

    }

    void DrawLine()
    {
        // Draw a line from player position to first collision point
        lineRenderer.SetPosition(0, playerPos);
        RaycastHit2D hit = Physics2D.Raycast(playerPos, direction, maxDist, ~layersToIgnore);

        if (hit.collider)
        {
            lineRenderer.SetPosition(1, hit.point);
        }
    }
}
