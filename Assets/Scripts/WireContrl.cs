using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireControl : MonoBehaviour
{
    public GameObject[] set1;
    public GameObject[] set2;

    private LineRenderer[] lineRenderers;

    void Start()
    {
        if (set1.Length != set2.Length)
        {
            Debug.LogError("The two sets of objects must have the same number of elements!");
            return;
        }

        lineRenderers = new LineRenderer[set1.Length];

        for (int i = 0; i < set1.Length; i++)
        {
            GameObject lineObject = new GameObject("LineRenderer_" + i);
            lineObject.transform.SetParent(this.transform);

            LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();

            lineRenderers[i] = lineRenderer;

            lineRenderer.startWidth = 0.02f;
            lineRenderer.endWidth = 0.02f;
            lineRenderer.material = new Material(Shader.Find("Sprites/Default")); 

            lineRenderer.positionCount = 2;
        }
    }

    void Update()
    {
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
