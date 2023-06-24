using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
        gameObject.GetComponent<CapsuleCollider2D>().isTrigger = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Monster>().Hit(gameManager.player.PhysicsDamage);
        }
    }
}
