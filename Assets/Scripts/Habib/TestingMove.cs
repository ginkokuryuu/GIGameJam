using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingMove : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector2 movement;
    [SerializeField] private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey(KeyCode.A))
        // {
        //     rb2d.AddForce(new Vector2(-speed, 0f));
        // }
        // else if (Input.GetKey(KeyCode.D))
        // {
        //     rb2d.AddForce(new Vector2(speed, 0f));
        // }
        // else if (Input.GetKey(KeyCode.S))
        // {
        //     rb2d.AddForce(new Vector2(0, -speed));
        // }
        // else if (Input.GetKey(KeyCode.W))
        // {
        //     rb2d.AddForce(new Vector2(0, speed));
        // }

        // ver 1
        movement.x = Input.GetAxis("Horizontal") * speed;
        movement.y = Input.GetAxis("Vertical") * speed;

        rb2d.AddForce(new Vector2(movement.x, movement.y));

        // ver 2
        // Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // rb2d.AddForce(move * speed);
    }
}
