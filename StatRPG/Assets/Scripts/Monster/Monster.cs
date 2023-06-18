using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Alive
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        if (HP <= 0)
        {
            gameManager.player.SkillPoint++;
            Destroy(gameObject);
        }
    }
}
