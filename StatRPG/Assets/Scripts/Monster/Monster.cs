using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Alive
{
    protected Animator animator;
    protected GameManager gameManager;

    private void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = GameManager.Instance;
        HP = 100;
        PhysicsDamage = 1;
        StartCoroutine(RandomMove(gameObject));
    }

    private void Update()
    {
        if (HP <= 0)
        {
            gameManager.player.SkillPoint++;
            Destroy(gameObject);
        }
    }

    public override void Hit(float Damage)
    {
        HP -= Damage;
    }

    IEnumerator RandomMove(GameObject Monster)
    {
        yield return new WaitForSeconds(0.15f);
        float Distance = gameManager.player.transform.position.x - Monster.transform.position.x;
        if (Math.Abs(Distance) > 5)
        {
            int randomMove = UnityEngine.Random.Range(0, 3);
            if (randomMove == 0)
            {
                Monster.transform.position += new Vector3(-0.1f, 0, 0);
                if (this.name == "Duck")
                {
                    Monster.transform.localScale = new Vector3(0.2f, 0.2f, 1);
                }
                else if (this.name == "SliderMan")
                {
                    Monster.transform.localScale = new Vector3(3, 3, 1);
                }
                else
                {
                    Monster.transform.localScale = new Vector3(0.5f, 0.5f, 1);
                }
                animator.SetBool("isMove", true);
            }
            else if (randomMove == 1)
            {
                Monster.transform.position += new Vector3(0.1f, 0, 0);
                if (this.name == "Duck")
                {
                    Monster.transform.localScale = new Vector3(-0.2f, 0.2f, 1);
                }
                else if (this.name == "SliderMan")
                {
                    Monster.transform.localScale = new Vector3(-3, 3, 1);
                }
                else
                {
                    Monster.transform.localScale = new Vector3(-0.5f, 0.5f, 1);
                }
                animator.SetBool("isMove", true);
            }
            else
            {
                animator.SetBool("isMove", false);
            }
            StartCoroutine(RandomMove(Monster));
        }
        else
        {
            if (Distance < 0)
            {
                Monster.transform.position += new Vector3(-0.2f, 0, 0);
                if (this.name == "Duck")
                {
                    Monster.transform.localScale = new Vector3(0.2f, 0.2f, 1);
                }
                else if (this.name == "SliderMan")
                {
                    Monster.transform.localScale = new Vector3(3, 3, 1);
                }
                else
                {
                    Monster.transform.localScale = new Vector3(0.5f, 0.5f, 1);
                }
                animator.SetBool("isMove", true);
            }
            else
            {
                Monster.transform.position += new Vector3(0.2f, 0, 0);
                if (this.name == "Duck")
                {
                    Monster.transform.localScale = new Vector3(-0.2f, 0.2f, 1);
                }
                else if (this.name == "SliderMan")
                {
                    Monster.transform.localScale = new Vector3(-3, 3, 1);
                }
                else
                {
                    Monster.transform.localScale = new Vector3(-0.5f, 0.5f, 1);
                }
                animator.SetBool("isMove", true);
            }

            if (Math.Abs(Distance) < 1)
            {
                animator.SetBool("isAttack", true);
                GetComponentInChildren<CapsuleCollider2D>().isTrigger = false;
            }
            else
            {
                animator.SetBool("isAttack", false);
                GetComponentInChildren<CapsuleCollider2D>().isTrigger = true;
            }
            StartCoroutine(RandomMove(Monster));
        }
    }
}
