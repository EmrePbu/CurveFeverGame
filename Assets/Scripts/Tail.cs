using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(LineRenderer))]
public class Tail : MonoBehaviour
{
    public float pointSpacing = 0.1f;
    public List<Vector2> points = new List<Vector2>();
    LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        points = new List<Vector2>();
        SetPoint();
    }

    void Update()
    {
        if (Vector3.Distance(points.Last(), transform.position) > pointSpacing)
        {
            SetPoint();
        }
    }

    private void SetPoint()
    {
        points.Add(transform.position);
        line.positionCount = points.Count;
        line.SetPosition(points.Count - 1, transform.position);
    }
}
