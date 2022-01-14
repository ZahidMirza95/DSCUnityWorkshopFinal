using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Animator animator;
    SpriteRenderer spriteRenderer;
    //Old implementation
    /*bool leftInput;
    bool rightInput;*/
    float moveInput;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        animator.SetBool("movingX", rigidbody2D.velocity.x != 0);
        if (moveInput < 0) spriteRenderer.flipX = true;
        else if (moveInput > 0) spriteRenderer.flipX = false;
        //Old implementation
        /*
        if (leftInput) spriteRenderer.flipX = true;
        else if (rightInput) spriteRenderer.flipX = false;
        */
    }
    void Update()
    {
        //Old Implementation
        /*leftInput = Input.GetKey(KeyCode.LeftArrow);
        rightInput = Input.GetKey(KeyCode.RightArrow);*/
        moveInput = Input.GetAxisRaw("Horizontal");
    }
}
