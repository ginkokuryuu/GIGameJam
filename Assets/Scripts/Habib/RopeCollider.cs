using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCollider : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField] HybridRope rope;
    EdgeCollider2D edgeCollider;

    Vector3 points;
    Vector2[] points2;

    private void Start()
    {
        points2 = new Vector2[rope.NumberOfLinks + 1];

        lineRenderer = rope.GetComponent<LineRenderer>();

        edgeCollider = this.gameObject.AddComponent<EdgeCollider2D>();

        getNewPositions();

        edgeCollider.points = points2;
    }

    private void Update()
    {
        getNewPositions();

        edgeCollider.points = points2;
    }

    void getNewPositions()
    {
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            points = lineRenderer.GetPosition(i);
            points2[i] = new Vector2(points.x, points.y);
        }
    }
}
