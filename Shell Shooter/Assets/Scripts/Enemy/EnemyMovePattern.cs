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

    // At the end of the list will loop back to the first index
    public bool loop = false;
    private List<Point> points = new();
    public List<Vector3> Positions { get; private set;} = new();
    LineRenderer lineRenderer;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        UpdateLineRendererPositions();
    }
    
    private void Start() {
        HidePattern();
    }

    public void UpdateLineRendererPositions() {
        points.Clear();
        Positions.Clear();
        GetComponentsInChildren<Point>(points);
        foreach (Point point in points)
        {
            Positions.Add(point.transform.position);
        }

        if (!lineRenderer) lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = Positions.Count;
        lineRenderer.SetPositions(Positions.ToArray());
        lineRenderer.widthMultiplier = 0.1f;
    }

}
