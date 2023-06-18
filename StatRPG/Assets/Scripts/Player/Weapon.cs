using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Player
{
    private void Start()
    {
        playerControll = base.playerControll;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Monster>().Hit(PhysicsDamage);
        }
    }
}
