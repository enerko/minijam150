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
    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    private LineRenderer lineRenderer;
    private Vector3 direction;
    private float maxDist = 30;
    public LayerMask layersToIgnore;
    private GameObject prismPath;
    private List<LineRenderer> lines = new List<LineRenderer>();

    private void Start()
    {
        lineRenderer = MakeLineRenderer(gameObject);
        lineRenderer.positionCount = 2;

        SetDefaultColor(lineRenderer);
    }

    LineRenderer MakeLineRenderer(GameObject gameObject)
    {
        LineRenderer newLR = gameObject.AddComponent<LineRenderer>();
        newLR.material = new Material(Shader.Find("Sprites/Default"));
        newLR.widthMultiplier = 0.1f;
        return newLR;
    }
    // Update is called once per frame
    void Update()
    {
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
        lineRenderer.SetPosition(0, transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxDist, ~layersToIgnore);

        if (hit.collider)
        {
            lineRenderer.SetPosition(1, hit.point);

            if (hit.collider.gameObject.tag == "Mirror")
            {
                ResetLineRenderer();

                lineRenderer.positionCount = 3;

                // Calculate angle between vectors, then apply a transformation
                Vector3 normal = hit.normal;
                double between = AngleBetweenVectors(normal, direction);
                Vector2 reflected = RotateCounterClockwise(between, normal);

                // If normal comes after direction in the circle then clockwise rotation, otherwise counterclockwise
                if ((Vector2.SignedAngle(normal, direction) < 0))
                {
                    reflected = RotateClockwise(between, normal);
                }

                lineRenderer.SetPosition(2, hit.point + 1 * reflected);
            }
            else if (hit.collider.gameObject.tag == "Prism")
            {
                // Split the path into two with the collision point as the origin 
                ChangeColor(lineRenderer);
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(1, hit.point);

                if (lines.Count == 0)
                {
                    GameObject line1 = new GameObject("Line1");
                    LineRenderer prismRendererL = MakeLineRenderer(line1);
                    prismRendererL.positionCount = 2;

                    GameObject line2 = new GameObject("Line2");
                    LineRenderer prismRendererR = MakeLineRenderer(line2);
                    prismRendererR.positionCount = 2;

                    lines.Add(prismRendererL);
                    lines.Add(prismRendererR);
                }
                float angle = 90;

                Vector2 dirUp = Quaternion.AngleAxis(angle / 2, new Vector3(0, 0, 1)) * direction;
                Vector2 dirDown = Quaternion.AngleAxis(-angle / 2, new Vector3(0, 0, 1)) * direction;

                List<Vector2> positions = new List<Vector2> { dirUp, dirDown };

                for (int i = 0; i < lines.Count; i++)
                {
                    lines[i].SetPosition(0, hit.point);
                    lines[i].SetPosition(1, positions[i] + hit.point);
                    SetDefaultColor(lines[i]);
                }

            }
            else

            {
                ResetLineRenderer();
            }

        }
            
    }

    private void ResetLineRenderer()
    {
        lineRenderer.positionCount = 2;
        if (lines.Count != 0)
        {
            Destroy(lines[0].gameObject);
            Destroy(lines[1].gameObject);
            lines.Clear();
        }
        SetDefaultColor(lineRenderer);
    }


    private void SetDefaultColor(LineRenderer lr)
    {
        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 0.5f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c1, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(0.0f, 1.0f) }
        );
        lr.colorGradient = gradient;
    }

    private void ChangeColor(LineRenderer lr)
    {
        float alpha = 0.5f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c1, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lr.colorGradient = gradient;
    }

    double AngleBetweenVectors(Vector2 vec1, Vector2 vec2)
    {
        // this is not signed, causing a bug 
        float dot = vec1.x * vec2.x + vec1.y * vec2.y;
        double rad = Math.Acos(dot);
        return Math.PI - rad;
    }

    Vector2 RotateCounterClockwise(double angle, Vector2 vec)
    {
        Vector2 rotated = new Vector2((float)(Math.Cos(angle) * vec.x - Math.Sin(angle) * vec.y), (float)(Math.Sin(angle)*vec.x + Math.Cos(angle)*vec.y));
        return rotated;
    }

    Vector2 RotateClockwise(double angle, Vector2 vec)
    {
        Vector2 rotated = new Vector2((float)(Math.Cos(angle) * vec.x + Math.Sin(angle) * vec.y), (float)(-Math.Sin(angle) * vec.x + Math.Cos(angle) * vec.y));
        return rotated;
    }
}
