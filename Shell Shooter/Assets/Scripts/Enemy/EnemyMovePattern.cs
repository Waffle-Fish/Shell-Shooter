using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class EnemyMovePattern : MonoBehaviour
{
    [TitleGroup("Dev Controls")]
    [Button]
    private void UpdatePattern() {
        UpdateLineRendererPositions();
    }

    [Button]
    private void HidePattern() {
        foreach (Point p in points)
        {
            p.SpriteRenderer.enabled = false;
        }
        lineRenderer.widthMultiplier = 0f;
    }

    [Button]
    private void RevealPattern() {
        foreach (Point p in points)
        {
            p.SpriteRenderer.enabled = true;
        }
        lineRenderer.widthMultiplier = 0.1f;
    }

    private List<Point> points = new();
    private List<Vector3> positions = new();
    LineRenderer lineRenderer;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        UpdateLineRendererPositions();
    }

    public void UpdateLineRendererPositions() {
        points.Clear();
        positions.Clear();
        GetComponentsInChildren<Point>(points);
        foreach (Point point in points)
        {
            positions.Add(point.transform.position);
        }

        if (!lineRenderer) lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = positions.Count;
        lineRenderer.SetPositions(positions.ToArray());
        lineRenderer.widthMultiplier = 0.1f;
    }

}
