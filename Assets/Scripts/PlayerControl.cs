using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb2D;
    Animator animator;

    [SerializeField]
    float speed = default;

    [SerializeField]
    float acceleration = default;

    [SerializeField]
    float deceleration = default;

    Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InputControl();
    }

    void InputControl()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 scale = transform.localScale;
        if (moveInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = Math.Abs(scale.x);
        }
        else if (moveInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -Math.Abs(scale.x);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
            animator.SetBool("Walk", false);

        }
        transform.localScale = scale;
        gameObject.transform.Translate(velocity * Time.deltaTime);
    }
}
