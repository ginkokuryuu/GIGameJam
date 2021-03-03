using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D player;
    [SerializeField] private SpriteRenderer sprite;

    private Animator animator;
    private bool isMoving = false;

    // public Animator animator;
    Vector2 movement;
    Vector2 defaultPosition;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animator = sprite.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;

        if(movement.magnitude >= 0.1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        animator.SetBool("isWalking", isMoving);

        // x < 0 -- right
        if (movement.x == -1f)
        {
            sprite.flipX = true;
        }
        // x > 0 -- left
        else if (movement.x == 1f)
        {
            sprite.flipX = false;
        }

        player.AddForce(movement * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);

        // animator.SetFloat("Horizontal", movement.x);
        // animator.SetFloat("Vertical", movement.y);
        // animator.SetFloat("Speed", movement.sqrMagnitude);

    }

}
