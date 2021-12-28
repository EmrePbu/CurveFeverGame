using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent (typeof(EdgeCollider2D))]
public class Tail : MonoBehaviour
{
    public Transform snake;
    public float pointSpacing = 0.1f;
    public List<Vector2> points = new List<Vector2>();

    LineRenderer line;
    EdgeCollider2D edgeCollider;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        points = new List<Vector2>();
        SetPoint();
    }

    void Update()
    {
        if (Vector3.Distance(points.Last(), snake.position) > pointSpacing)
        {
            SetPoint();
        }
    }

    private void SetPoint()
    {
        if (points.Count > 1)
        {
            edgeCollider.points = points.ToArray<Vector2>();
        }
        points.Add(snake.position);
        line.positionCount = points.Count;
        line.SetPosition(points.Count - 1, snake.position);

    }
}
 