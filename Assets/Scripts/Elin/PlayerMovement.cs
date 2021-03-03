using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private Rigidbody2D player;

    // public Animator animator;
    Vector2 movement;
    Vector2 defaultPosition;

    void Update()
    {
        // x < 0 -- right
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        // x > 0 -- left
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        // down
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
        }
        // up
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;

        player.AddForce(movement * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);

        // animator.SetFloat("Horizontal", movement.x);
        // animator.SetFloat("Vertical", movement.y);
        // animator.SetFloat("Speed", movement.sqrMagnitude);

    }

}
