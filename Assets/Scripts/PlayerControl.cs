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

    [SerializeField]
    float jumpPower = default;

    [SerializeField]
    int jumpLimit = 2;

    int jumpCount;

    Joystick joystick;

    JoystickBtn joystickBtn;

    bool isJumping;

    Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
        joystickBtn = FindObjectOfType<JoystickBtn>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        KeyboardControl();
#else
                JoystickControl();
#endif
    }

    void KeyboardControl()
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
        transform.Translate(velocity * Time.deltaTime);

        if (Input.GetKeyDown("space"))
        {
            StartJump();
        }

        if (Input.GetKeyUp("space"))
        {
            StopJump();
        }
    }

    void JoystickControl()
    {
        float moveInput = joystick.Horizontal;
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
        transform.Translate(velocity * Time.deltaTime);

        if (joystickBtn.btnDown == true && isJumping == false)
        {
            isJumping = true;
            StartJump();
        }
        else if (joystickBtn.btnDown == false && isJumping == true)
        {
            isJumping = false;
            StopJump();
        }
    }

    void StartJump()
    {
        if (jumpCount < jumpLimit)
        {
            FindObjectOfType<SoundControl>().Jump();
            rb2D.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            FindObjectOfType<SliderControl>().SliderValue(jumpLimit, jumpCount);
        }

    }

    void StopJump()
    {
        animator.SetBool("Jump", false);
        jumpCount++;
        FindObjectOfType<SliderControl>().SliderValue(jumpLimit, jumpCount);
    }

    public void ResetJump()
    {
        jumpCount = 0;
        FindObjectOfType<SliderControl>().SliderValue(jumpLimit, jumpCount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            FindObjectOfType<GameControl>().GameOver();
        }
    }

    public void GameOver()
    {
        Destroy(gameObject);
    }
}
