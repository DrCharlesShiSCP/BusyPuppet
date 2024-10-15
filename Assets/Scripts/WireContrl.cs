using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireControl : MonoBehaviour
{
    public GameObject[] set1; // Array for the first set of objects
    public GameObject[] set2; // Array for the second set of objects

    private LineRenderer[] lineRenderers;

    void Start()
    {
        // Ensure both arrays are of equal length
        if (set1.Length != set2.Length)
        {
            Debug.LogError("The two sets of objects must have the same number of elements!");
            return;
        }

        // Initialize LineRenderers array
        lineRenderers = new LineRenderer[set1.Length];

        // For each pair, create a LineRenderer and set its properties
        for (int i = 0; i < set1.Length; i++)
        {
            // Create a new GameObject to hold the LineRenderer
            GameObject lineObject = new GameObject("LineRenderer_" + i);
            lineObject.transform.SetParent(this.transform);

            // Add a LineRenderer component
            LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();

            // Store the LineRenderer in the array for easy reference
            lineRenderers[i] = lineRenderer;

            // Set LineRenderer properties (adjust as needed)
            lineRenderer.startWidth = 0.05f;
            lineRenderer.endWidth = 0.05f;
            lineRenderer.material = new Material(Shader.Find("Sprites/Default")); // Use a simple material

            // Set the positions for this LineRenderer
            lineRenderer.positionCount = 2;
        }
    }

    void Update()
    {
        // Update each LineRenderer to connect corresponding objects in set1 and set2
        for (int i = 0; i < lineRenderers.Length; i++)
        {
            if (set1[i] != null && set2[i] != null)
            {
                lineRenderers[i].SetPosition(0, set1[i].transform.position);
                lineRenderers[i].SetPosition(1, set2[i].transform.position);
            }
        }
    }
}
