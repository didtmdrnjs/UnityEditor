using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerControll : MonoBehaviour
{
    public Animator animator;

    private float x_move;
    public float move_speed;
    private bool isGround;
    private float jump_power;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        move_speed = 5f;
        jump_power = 8f;
    }

    private void Update()
    {
        Move();
        animationParameter();
    }

    private void Move()
    {
        x_move = Input.GetAxis("Horizontal");

        if (x_move > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (x_move < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        animator.SetBool("isWalk", x_move != 0);

        transform.position += new Vector3(x_move * move_speed * Time.deltaTime, 0, 0);
    }

    private void animationParameter()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isAttack", true);
        }
        else
        {
            animator.SetBool("isAttack", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            GetComponent<Rigidbody2D>().velocity += Vector2.up * jump_power;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
