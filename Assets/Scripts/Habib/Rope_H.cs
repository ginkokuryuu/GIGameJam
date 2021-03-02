using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope_H : MonoBehaviour
{
    [SerializeField] private GameObject linkPrefab = null;
    [SerializeField] private int numberOfLinks = 5;
    [SerializeField] private Rigidbody2D player = null;
    [SerializeField] private GameObject endPrefab = null;
    [SerializeField] private float ropeLen = 0.3f;
    [SerializeField] private Vector2 anchorVal = new Vector2();
    [SerializeField] private Vector2 connAnchorVal = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        GenerateRope();
    }

    void GenerateRope()
    {
        Rigidbody2D prevRB = player;
        for (int i = 0; i < numberOfLinks; i++)
        {
            GameObject theObject;
            if(i == numberOfLinks - 1)
            {
                theObject = Instantiate(endPrefab, transform.position - new Vector3(0, i * ropeLen, 0), transform.rotation);
            }
            else
            {
                theObject = Instantiate(linkPrefab, transform.position - new Vector3(0, i * ropeLen, 0), transform.rotation);
            }
            SpringJoint2D joint = theObject.GetComponent<SpringJoint2D>();
            joint.connectedBody = prevRB;

            if (i == 0)
            {
                joint.anchor = Vector2.zero;
                joint.connectedAnchor = Vector2.zero;
            }
            else
            {
                joint.anchor = anchorVal;
                joint.connectedAnchor = connAnchorVal;
            }

            prevRB = theObject.GetComponent<Rigidbody2D>();
        }
    }
}
