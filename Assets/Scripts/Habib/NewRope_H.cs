using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRope_H : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<RopeSegment> ropeSegments = new List<RopeSegment>();
    [SerializeField] private float ropeSegmentLen = 0.25f;
    [SerializeField] private int segmentLength = 35;
    [SerializeField] private float lineWidth = 0.1f;
    [SerializeField] Vector2 forceGravity = new Vector2(0f, -1f);
    [SerializeField] int simulationCount = 50;
    [SerializeField] private Transform firstPoint = null;
    [SerializeField] private Transform secondPoint = null;
    [SerializeField] private bool usingMouse = false;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        Vector2 ropeStartPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        for (int i = 0; i < segmentLength; i++)
        {
            ropeSegments.Add(new RopeSegment(ropeStartPoint));
            ropeStartPoint.y -= ropeSegmentLen;
        }
    }

    // Update is called once per frame
    void Update()
    {
        DrawRope();
    }

    private void FixedUpdate()
    {
        SimulateRope();
    }

    void DrawRope()
    {
        float lineWide = lineWidth;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        Vector3[] ropePositions = new Vector3[segmentLength];
        for (int i = 0; i < segmentLength; i++)
        {
            ropePositions[i] = ropeSegments[i].currPos;
        }

        lineRenderer.positionCount = ropePositions.Length;
        lineRenderer.SetPositions(ropePositions);
    }

    void SimulateRope()
    {
        //SIMULATIONS
        for (int i = 0; i < segmentLength; i++)
        {
            RopeSegment firstSegment = ropeSegments[i];
            Vector2 velocity = firstSegment.currPos - firstSegment.oldPos;
            firstSegment.oldPos = firstSegment.currPos;
            firstSegment.currPos += velocity;
            firstSegment.currPos += forceGravity * Time.deltaTime;
            ropeSegments[i] = firstSegment;
        }

        //CONSTRAINTS
        for (int i = 0; i < simulationCount; i++)
        {
            this.ApplyConstraints();
        }
    }

    void ApplyConstraints()
    {
        RopeSegment firstSegment = ropeSegments[0];
        RopeSegment endSegment = ropeSegments[segmentLength - 1];

        //follow mouse
        firstSegment.currPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //follow points
        if (!usingMouse)
        {
            firstSegment.currPos = firstPoint.position;
            endSegment.currPos = secondPoint.position;
            ropeSegments[segmentLength - 1] = endSegment;
        }

        ropeSegments[0] = firstSegment;

        for (int i = 0; i < this.segmentLength - 1; i++)
        {
            RopeSegment firstSeg = this.ropeSegments[i];
            RopeSegment secondSeg = this.ropeSegments[i + 1];

            float dist = (firstSeg.currPos - secondSeg.currPos).magnitude;
            float error = Mathf.Abs(dist - this.ropeSegmentLen);
            Vector2 changeDir = Vector2.zero;

            if (dist > ropeSegmentLen)
            {
                changeDir = (firstSeg.currPos - secondSeg.currPos).normalized;
            }
            else if (dist < ropeSegmentLen)
            {
                changeDir = (secondSeg.currPos - firstSeg.currPos).normalized;
            }

            Vector2 changeAmount = changeDir * error;
            if (i != 0)
            {
                firstSeg.currPos -= changeAmount * 0.5f;
                this.ropeSegments[i] = firstSeg;
                secondSeg.currPos += changeAmount * 0.5f;
                this.ropeSegments[i + 1] = secondSeg;
            }
            else
            {
                secondSeg.currPos += changeAmount;
                this.ropeSegments[i + 1] = secondSeg;
            }
        }
    }

    public struct RopeSegment
    {
        public Vector2 currPos;
        public Vector2 oldPos;

        public RopeSegment(Vector2 pos)
        {
            this.currPos = pos;
            this.oldPos = pos;
        }
    }
}
