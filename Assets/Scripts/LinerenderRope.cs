using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinerenderRope : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public int segmentCount = 20;
    public float ropeLength = 5f;
    public float tension = 0.5f; // 0 = fully relaxed, 1 = fully taut

    public float targetTension = 0.7f;
    private LineRenderer lineRenderer;
    private Vector3[] ropePositions;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = segmentCount;
        ropePositions = new Vector3[segmentCount];

        UpdateRope();
    }

    void Update()
    {
        UpdateRope();
    }

    void UpdateRope()
    {
        Vector3 ropeVector = endPoint.position - startPoint.position;
        float ropeVectorLength = ropeVector.magnitude;
        Vector3 ropeDirection = ropeVector.normalized;

        float sagAmount = Mathf.Lerp(ropeLength - ropeVectorLength, 0, tension);
        Vector3 sagDirection = Vector3.Cross(ropeDirection, Vector3.up).normalized;

        for (int i = 0; i < segmentCount; i++)
        {
            float t = i / (float)(segmentCount - 1);
            Vector3 offset = sagDirection * Mathf.Sin(t * Mathf.PI) * sagAmount;
            ropePositions[i] = Vector3.Lerp(startPoint.position, endPoint.position, t) + offset;
        }

        lineRenderer.SetPositions(ropePositions);
    }
}
