using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerControll : MonoBehaviour
{
    private GameManager gameManager;
    public Animator animator;

    [SerializeField]
    private GameObject Arrow;

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

    private void Start()
    {
        gameManager = GameManager.Instance;
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
        if (Input.GetMouseButtonDown(0) && !GameObject.Find("arrow(Clone)"))
        {
            animator.SetBool("isAttack", true);
            if (gameManager.selectJob.job == "Peasant")
            {
                GameObject NewArrow = Instantiate(Arrow, gameManager.player.gameObject.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                if (gameManager.player.transform.localScale.x > 0)
                {
                    NewArrow.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    NewArrow.GetComponent<ArrowAction>().Rotation = -1;
                }
                else
                {
                    NewArrow.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -90));
                    NewArrow.transform.localScale = new Vector3(-1, 1, 1);
                    NewArrow.GetComponent<ArrowAction>().Rotation = 1;
                }
            }
            else
            {
                GameObject.FindWithTag("Weapon").gameObject.GetComponent<CapsuleCollider2D>().isTrigger = false;
                StartCoroutine(SetCollider(GameObject.FindWithTag("Weapon").gameObject.GetComponent<CapsuleCollider2D>()));
            }
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

    IEnumerator SetCollider(CapsuleCollider2D capsucollider)
    {
        yield return new WaitForSeconds(0.8f);
        capsucollider.isTrigger = true;
    }
}
