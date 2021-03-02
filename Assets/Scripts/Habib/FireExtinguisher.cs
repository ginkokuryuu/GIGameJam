using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    [SerializeField] private Transform followPos = null;
    [SerializeField] private GameObject waterSpray = null;
    private Vector3 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        waterSpray.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
            waterSpray.SetActive(true);
        else if (Input.GetMouseButtonUp(0))
            waterSpray.SetActive(false);

        LookAtMouse();
        UpdatePosition();
    }

    void UpdatePosition()
    {
        transform.position = followPos.position;
    }

    protected void LookAtMouse()
    {
        float angle = AngleBetweenPoints(mousePosition, transform.position);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    protected float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
