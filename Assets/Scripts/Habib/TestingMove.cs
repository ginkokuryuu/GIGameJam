﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingMove : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddForce(new Vector2(-speed, 0f));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(new Vector2(speed, 0f));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb2d.AddForce(new Vector2(0, -speed));
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rb2d.AddForce(new Vector2(0, speed));
        }
    }
}
