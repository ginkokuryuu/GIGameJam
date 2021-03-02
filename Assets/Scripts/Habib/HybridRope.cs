using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HybridRope : MonoBehaviour
{
    [SerializeField] private GameObject linkPrefab = null;
    [SerializeField] private GameObject endPrefab = null;
    [SerializeField] private int numberOfLinks = 5;
    [SerializeField] private Rigidbody2D player = null;
    [SerializeField] private float ropeLen = 0.3f;
    [SerializeField] private Vector2 anchorVal = new Vector2();
    [SerializeField] private Vector2 connAnchorVal = new Vector2();
    [SerializeField] private float ropeWidth = 0.1f;
    [SerializeField] private float colliderRad = 0.5f;
    private LineRenderer lineRenderer;
    List<GameObject> generatedLinks = new List<GameObject>();

    public int NumberOfLinks { get => numberOfLinks; set => numberOfLinks = value; }

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        GenerateRope();
    }

    private void Update()
    {
        DrawRope();
    }

    void GenerateRope()
    {
        Rigidbody2D prevRB = player;
        for (int i = 0; i < numberOfLinks; i++)
        {
            GameObject theObject;
            if(i == numberOfLinks - 1)
                theObject = Instantiate(endPrefab, transform.position - new Vector3(0, i * ropeLen, 0), transform.rotation);
            else
                theObject = Instantiate(linkPrefab, transform.position - new Vector3(0, i * ropeLen, 0), transform.rotation);
            SpringJoint2D joint = theObject.GetComponent<SpringJoint2D>();
            CircleCollider2D circleCollider = theObject.GetComponent<CircleCollider2D>();
            joint.connectedBody = prevRB;

            if(circleCollider)
                circleCollider.radius = colliderRad;

            joint.anchor = anchorVal;
            joint.connectedAnchor = connAnchorVal;

            prevRB = theObject.GetComponent<Rigidbody2D>();
            generatedLinks.Add(theObject);
        }
    }

    void DrawRope()
    {
        lineRenderer.startWidth = ropeWidth;
        lineRenderer.endWidth = ropeWidth;

        Vector3[] pointPositions = new Vector3[numberOfLinks + 1];
        pointPositions[0] = transform.position;
        for (int i = 0; i < numberOfLinks; i++)
        {
            pointPositions[i + 1] = generatedLinks[i].transform.position;
        }

        lineRenderer.positionCount = numberOfLinks + 1;
        lineRenderer.SetPositions(pointPositions);
    }
}
